using System.Collections.Generic;
using System.IO;
using Prism.Mvvm;

namespace WebpConverter.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        public string Title => "webp converter";

        public List<FileInfo> WebpFiles { get; set; }
    }
}