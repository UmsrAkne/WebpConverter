using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Prism.Commands;
using Prism.Mvvm;
using WebpConverter.Models;

namespace WebpConverter.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private List<ExFileInfo> webpFiles;

        public string Title => "webp converter";

        // DragAndDropBehavior からデータが入力される。
        public List<ExFileInfo> WebpFiles
        {
            get => webpFiles;
            set => SetProperty(ref webpFiles, value);
        }

        public DelegateCommand ConvertWebpToPngCommand => new DelegateCommand(() =>
        {
        });
    }
}