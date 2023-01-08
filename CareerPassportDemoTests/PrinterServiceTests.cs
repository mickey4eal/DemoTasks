using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CareerPassportDemoTests
{
    [TestClass()]
    public class PrinterServiceTests
    {
        private PrinterService _helloWorld;

        public PrinterServiceTests()
        {
            _helloWorld = new ();
        }

        [TestMethod()]
        public void PrintWordTest()
        {
            var currentConsoleOut = Console.Out;

            using (var consoleOutput = new ConsoleOutput())
            {
                _helloWorld.Print("Hello, World!");

                Assert.AreEqual("Hello, World!\r\n", consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}