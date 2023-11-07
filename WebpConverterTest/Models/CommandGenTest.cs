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
            Assert.That(CommandGen.GetCommand(file), Is.EqualTo($"--o \"{pngFullName}\" \"{webpFullName}\""));
        }
    }
}