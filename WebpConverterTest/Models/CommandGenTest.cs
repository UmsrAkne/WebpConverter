using System.IO;
using NUnit.Framework;
using WebpConverter.Models;

namespace WebpConverterTest.Models
{
    public class CommandGenTest
    {
        [Test]
        public void GetCommandTest()
        {
            var file = new FileInfo("test.webp");
            CommandGen.GetCommand(file);

            var webpFullName = new FileInfo("test.webp").FullName;
            var pngFullName = new FileInfo("test.png").FullName;
            Assert.That(CommandGen.GetCommand(file), Is.EqualTo($"-o \"{pngFullName}\" \"{webpFullName}\""));
        }

        [Test]
        public void GetCommandTest_出力先指定()
        {
            var file = new FileInfo(@"c:\temp\test.webp");
            var dir = new DirectoryInfo(@"c:\temp2");
            var command = CommandGen.GetCommand(file, dir);

            Assert.That(command, Is.EqualTo(@"-o ""c:\temp2\test.png"" ""c:\temp\test.webp"""));
        }
    }
}