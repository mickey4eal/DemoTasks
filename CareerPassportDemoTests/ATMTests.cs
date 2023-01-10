using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CareerPassportDemoTests
{
    [TestClass()]
    public class ATMTests
    {
        private Account? _atm;
        private const string header = "Date  |   Amount  |   Balance ";

        [TestMethod()]
        public void DepositTest()
        {
            //Arrange
            _atm = new();

            //Act
            _atm.Deposit(DateTime.UtcNow, 100);
            _atm.Deposit(DateTime.UtcNow, 500);

            //Assert
            Assert.AreEqual(600, _atm.Balance);
        }

        [TestMethod()]
        [DataRow(0)]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentException), "Invalid Amount")]
        public void DepositTestThrowsErrorWhenAmountIsZeroOrNegative(double amount)
        {
            //Arrange
            _atm = new();

            //Act
            _atm.Deposit(DateTime.UtcNow, amount);
        }

        [TestMethod()]
        public void WithdrawTest()
        {
            //Arrange
            _atm = new();

            //Act
            _atm.Deposit(DateTime.UtcNow, 800);
            _atm.Withdraw(DateTime.UtcNow, 100);
            _atm.Withdraw(DateTime.UtcNow, 350);

            //Assert
            Assert.AreEqual(350, _atm.Balance);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Insufficient Funds in Account.")]
        public void WithdrawTestThrowsExceptionWhenBalanceIsZero()
        {
            //Arrange
            _atm = new();

            //Act
            _atm.Withdraw(DateTime.UtcNow, 800);
        }

        [TestMethod()]
        public void ShowBankStatementPrintsHeaderWithEmptyTransactions()
        {
            //Arrange
            _atm = new();
            var currentConsoleOut = Console.Out;

            //Act and Assert
            using (var consoleOutput = new ConsoleOutput())
            {
                _atm.ShowBankStatement();

                Assert.AreEqual(header+"\r\n", consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod()]//To be Fixed. Why do I need to remove the whitespaces
        public void ShowBankStatementPrintsAllTransactions()
        {
            //Arrange
            _atm = new();
            var currentConsoleOut = Console.Out;

            //Act
            _atm.Deposit(new DateTime(2023, 6, 1, 7, 47, 0), 800);
            _atm.Withdraw(new DateTime(2023, 6, 1, 7, 47, 0), 100);
            _atm.Withdraw(new DateTime(2023, 6, 1, 7, 47, 0), 150);
            Assert.AreEqual(550, _atm.Balance);
            Assert.AreEqual(currentConsoleOut, Console.Out);

            using (var consoleOutput = new ConsoleOutput())
            {
                _atm.ShowBankStatement();
                var expected = @"Date  |   Amount  |   Balance 
                01/06/2023 07:47:00  |   800  |   800 
                01/06/2023 07:47:00  |   100  |   700 
                01/06/2023 07:47:00  |   150  |   550 ";
                expected = expected.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", string.Empty);
                var cleanOutput = consoleOutput.GetOuput().Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", string.Empty);

                //Assert.AreEqual(expected, consoleOutput.GetOuput());
                Assert.AreEqual(expected, cleanOutput);
            }
        }
    }
}