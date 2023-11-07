using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using WebpConverter.ViewModels;

namespace WebpConverter.Models
{
    // ReSharper disable once UnusedType.Global
    public class DragAndDropBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            // ファイルをドラッグしてきて、コントロール上に乗せた際の処理
            AssociatedObject.PreviewDragOver += AssociatedObject_PreviewDragOver;

            // ファイルをドロップした際の処理
            AssociatedObject.Drop += AssociatedObject_Drop;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewDragOver -= AssociatedObject_PreviewDragOver;
            AssociatedObject.Drop -= AssociatedObject_Drop;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            // ファイルパスの一覧の配列
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (((Window)sender).DataContext is MainWindowViewModel vm && files != null)
            {
                vm.WebpFiles =
                    files.Where(f => Path.GetExtension(f) == ".webp")
                        .Select(f => new FileInfo(f)).ToList();
            }
        }

        private void AssociatedObject_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
        }
    }
}