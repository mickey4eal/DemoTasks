using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CareerPassportDemo.Tests
{
    [TestClass()]
    public class BankTests
    {
        private Bank? _bank;

        [TestMethod()]
        public void CreateUserAccountTest()
        {
            //Arrange
            _bank = new();
            var acctNumber = "1284393293";
            var user = GenerateNewUser("Joe", "Gee", DateTime.Today.AddYears(-19), acctNumber, "12-23-34", GenerateNewAccount(acctNumber), AccountType.CurrentAccount);

            //Act
            _bank.CreateUserAccount(user);

            //Assert
            Assert.AreEqual(1, _bank.BankUsers.Count);
        }

        [TestMethod()]
        public void TransferFundsTest()
        {
            //Arrange
            _bank = new();
            var acctNumberA = "1284393293";
            var sortCodeA = "12-23-34";
            var sortCodeB = "12-23-35";
            var acctNumberB = "1284393295";
            var userA = GenerateNewUser("Joe", "Gee", DateTime.Today.AddYears(-19), acctNumberA, sortCodeA, GenerateNewAccount(acctNumberA), AccountType.CurrentAccount);
            var userB = GenerateNewUser("Zoe", "Zee", DateTime.Today.AddYears(-25), acctNumberB, sortCodeB, GenerateNewAccount(acctNumberB), AccountType.CurrentAccount);
            _bank.CreateUserAccount(userA);
            _bank.CreateUserAccount(userB);
            _bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 5000);

            //Act
            _bank.TransferFunds(sortCodeA, acctNumberA, sortCodeB, acctNumberB, 1000);

            //Assert
            Assert.AreEqual(4000, _bank.BankUsers.First().Account.Balance);
            Assert.AreEqual(1000, _bank.BankUsers.Last().Account.Balance);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "Insufficient Funds in Account.")]
        public void TransferFundsTestThrowsErrorWhenSenderIsNotFound()
        {
            //Arrange
            _bank = new();
            var acctNumberA = "1284393293";
            var sortCodeA = "12-23-34";
            var sortCodeB = "12-23-35";
            var acctNumberB = "1284393295";
            var userA = GenerateNewUser("Joe", "Gee", DateTime.Today.AddYears(-19), acctNumberA, sortCodeA, GenerateNewAccount(acctNumberA), AccountType.CurrentAccount);
            var userB = GenerateNewUser("Zoe", "Zee", DateTime.Today.AddYears(-25), acctNumberB, sortCodeB, GenerateNewAccount(acctNumberB), AccountType.CurrentAccount);
            _bank.CreateUserAccount(userA);
            _bank.CreateUserAccount(userB);
            _bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 5000);

            //Act and Assert
            _bank.TransferFunds(sortCodeA, acctNumberA, sortCodeB, string.Empty, 1000);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "Insufficient Funds in Account.")]
        public void TransferFundsTestThrowsErrorWhenRecipientIsNotFound()
        {
            //Arrange
            _bank = new();
            var acctNumberA = "1284393293";
            var sortCodeA = "12-23-34";
            var sortCodeB = "12-23-35";
            var acctNumberB = "1284393295";
            var userA = GenerateNewUser("Joe", "Gee", DateTime.Today.AddYears(-19), acctNumberA, sortCodeA, GenerateNewAccount(acctNumberA), AccountType.CurrentAccount);
            var userB = GenerateNewUser("Zoe", "Zee", DateTime.Today.AddYears(-25), acctNumberB, sortCodeB, GenerateNewAccount(acctNumberB), AccountType.CurrentAccount);
            _bank.CreateUserAccount(userA);
            _bank.CreateUserAccount(userB);
            _bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 5000);

            //Act and Assert
            _bank.TransferFunds(sortCodeA, string.Empty, sortCodeB, string.Empty, 1000);
        }

        [TestMethod()]
        [DataRow("1284393295", "")]
        [DataRow("", "12-23-35")]
        [ExpectedException(typeof(ArgumentException))]
        public void TransferFundsTestThrowsErrorWhenSenderIsNotFound(string sortCodeB, string acctNumberB)
        {
            //Arrange
            _bank = new();
            var acctNumberA = "1284393293";
            var sortCodeA = "12-23-34";
            var userA = GenerateNewUser("Joe", "Gee", DateTime.Today.AddYears(-19), acctNumberA, sortCodeA, GenerateNewAccount(acctNumberA), AccountType.CurrentAccount);
            var userB = GenerateNewUser("Zoe", "Zee", DateTime.Today.AddYears(-25), acctNumberB, sortCodeB, GenerateNewAccount(acctNumberB), AccountType.CurrentAccount);
            _bank.CreateUserAccount(userA);
            _bank.CreateUserAccount(userB);
            _bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 5000);

            //Act and Assert
            _bank.TransferFunds(sortCodeA, acctNumberA, sortCodeB, acctNumberB, 1000);
        }

        [TestMethod()]
        [DataRow("1284393293", "")]
        [DataRow("", "12-23-34")]
        [ExpectedException(typeof(ArgumentException))]
        public void TransferFundsTestThrowsErrorWhenRecipientIsNotFound(string sortCodeA, string acctNumberA)
        {
            //Arrange
            _bank = new();
            var sortCodeB = "12-23-35";
            var acctNumberB = "1284393295";
            var userA = GenerateNewUser("Joe", "Gee", DateTime.Today.AddYears(-19), acctNumberA, sortCodeA, GenerateNewAccount(acctNumberA), AccountType.CurrentAccount);
            var userB = GenerateNewUser("Zoe", "Zee", DateTime.Today.AddYears(-25), acctNumberB, sortCodeB, GenerateNewAccount(acctNumberB), AccountType.CurrentAccount);
            _bank.CreateUserAccount(userA);
            _bank.CreateUserAccount(userB);
            _bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 5000);

            //Act and Assert
            _bank.TransferFunds(sortCodeA, acctNumberA, sortCodeB, acctNumberB, 1000);
        }

        private User GenerateNewUser(
            string firstName,
            string lastName,
            DateTime dob,
            string acctNumber,
            string sortCode,
            Account account,
            AccountType accountType) =>
            new User
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob,
                AccountNumber = acctNumber,
                SortCode = sortCode,
                Account = account,
                AccountType = accountType
            };

        private Account GenerateNewAccount(string acctNumber) =>
            new Account()
            {
                AccountNumber = acctNumber
            };
    }
}