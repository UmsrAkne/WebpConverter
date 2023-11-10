using System.IO;

namespace WebpConverter.Models
{
    public static class CommandGen
    {
        public static string GetCommand(FileInfo inputFileInfo)
        {
            var exFileInfo = new ExFileInfo(inputFileInfo);
            exFileInfo.SetExtension(".png");

            var option = $"-o \"{exFileInfo.FileInfo.FullName}\"";
            return $"{option} \"{inputFileInfo.FullName}\"";
        }

        public static string GetCommand(FileInfo inputFileInfo, DirectoryInfo outputDirectoryInfo)
        {
            var exFileInfo = new ExFileInfo(inputFileInfo);
            exFileInfo.SetExtension(".png");

            var option = $"-o \"{outputDirectoryInfo.FullName}\\{exFileInfo.FileInfo.Name}\"";
            return $"{option} \"{inputFileInfo.FullName}\"";
        }
    }
}