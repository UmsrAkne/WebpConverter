using System.IO;
using Prism.Mvvm;

namespace WebpConverter.Models
{
    public class ExFileInfo : BindableBase
    {
        private FileInfo fileInfo;
        private bool converted;

        public ExFileInfo(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }

        public string Name => FileInfo.Name;

        public bool Converted { get => converted; set => SetProperty(ref converted, value); }

        public FileInfo FileInfo { get => fileInfo; set => SetProperty(ref fileInfo, value); }

        /// <summary>
        ///     内部で保持している FileInfo を入力した拡張子のファイルに書き換えます。
        /// </summary>
        /// <param name="extension"> . を含む拡張子を小文字で入力します。 例 : .mp3 .wav </param>
        public void SetExtension(string extension)
        {
            FileInfo = new FileInfo(
                $"{FileInfo.DirectoryName}\\{Path.GetFileNameWithoutExtension(FileInfo.FullName)}{extension}");

            RaisePropertyChanged(nameof(Name));
        }
    }
}