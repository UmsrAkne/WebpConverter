using System.Collections.Generic;
using Prism.Mvvm;
using WebpConverter.Models;

namespace WebpConverter.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        public string Title => "webp converter";

        // DragAndDropBehavior からデータが入力される。
        public List<ExFileInfo> WebpFiles { get; set; }
    }
}