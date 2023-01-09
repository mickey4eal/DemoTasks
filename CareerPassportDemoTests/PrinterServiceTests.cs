using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CareerPassportDemoTests
{
    [TestClass()]
    public class PrinterServiceTests
    {
        private readonly PrinterService _printer;

        public PrinterServiceTests()
        {
            _printer = new();
        }

        [TestMethod()]
        public void PrintWordTest()
        {
            //Arrange
            var currentConsoleOut = Console.Out;

            //Act and Assert
            using (var consoleOutput = new ConsoleOutput())
            {
                _printer.Print("Hello, World!");

                Assert.AreEqual("Hello, World!\r\n", consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}