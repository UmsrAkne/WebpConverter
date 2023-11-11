using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using WebpConverter.Models;

namespace WebpConverter.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private List<ExFileInfo> webpFiles = new List<ExFileInfo>();
        private bool processing;
        private string decoderLocation = string.Empty;
        private string outputDirectoryPath = string.Empty;

        public MainWindowViewModel()
        {
            DecoderLocation = new FileInfo("dwebp.exe").FullName;
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public string Title => "webp converter";

        public bool Processing { get => processing; set => SetProperty(ref processing, value); }

        public string DecoderLocation
        {
            get => decoderLocation;
            set => SetProperty(ref decoderLocation, value);
        }

        // DragAndDropBehavior からデータが入力される。
        public List<ExFileInfo> WebpFiles
        {
            get => webpFiles;
            set
            {
                if (value != null && value.Count > 0)
                {
                    OutputDirectoryPath = value.FirstOrDefault()?.FileInfo.Directory?.FullName;
                }

                SetProperty(ref webpFiles, value);
            }
        }

        public string OutputDirectoryPath
        {
            get => outputDirectoryPath;
            set => SetProperty(ref outputDirectoryPath, value);
        }

        public DelegateCommand ConvertWebpToPngCommand => new DelegateCommand(() =>
        {
            var webpDecoder = new FileInfo(DecoderLocation);

            if (!webpDecoder.Exists)
            {
                return;
            }

            var destDir = Path.IsPathRooted(OutputDirectoryPath) ? new DirectoryInfo(OutputDirectoryPath) : null;
            if (destDir != null && !destDir.Exists)
            {
                destDir = null;
            }

            WebpFiles.ForEach(f =>
            {
                var arg = destDir == null
                    ? CommandGen.GetCommand(f.FileInfo)
                    : CommandGen.GetCommand(f.FileInfo, destDir);

                var pr = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = webpDecoder.FullName,
                        Arguments = arg,
                        WindowStyle = ProcessWindowStyle.Hidden,
                    },
                    EnableRaisingEvents = true,
                };

                pr.Exited += (sender, e) =>
                {
                    f.Converted = true;
                    if (WebpFiles.All(w => w.Converted))
                    {
                        Processing = false;
                    }
                };

                Processing = true;
                pr.Start();
            });
        });

        public DelegateCommand ClearCommand => new DelegateCommand(() =>
        {
            WebpFiles = new List<ExFileInfo>();
        });
    }
}