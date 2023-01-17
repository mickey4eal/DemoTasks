namespace CareerPassportDemo.Helpers
{
    public static class AccountHelper
    {
        public static User GenerateNewUser(
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

        public static Account GenerateNewAccount(string acctNumber) =>
            new Account()
            {
                AccountNumber = acctNumber
            };
    }
}
