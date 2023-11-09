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

        public string Title => "webp converter";

        public bool Processing { get => processing; set => SetProperty(ref processing, value); }

        // DragAndDropBehavior からデータが入力される。
        public List<ExFileInfo> WebpFiles
        {
            get => webpFiles;
            set => SetProperty(ref webpFiles, value);
        }

        public DelegateCommand ConvertWebpToPngCommand => new DelegateCommand(() =>
        {
            var webpDecoder = new FileInfo("dwebp.exe");

            if (!webpDecoder.Exists)
            {
                return;
            }

            WebpFiles.ForEach(f =>
            {
                var pr = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = webpDecoder.FullName,
                        Arguments = CommandGen.GetCommand(f.FileInfo),
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
    }
}