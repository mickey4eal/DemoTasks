namespace CareerPassportDemo
{
    public class User
    {
        public User(string firstName, string lastName, DateTime dateOfBirth, string sortCode, string accountNumber, Account account)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            SortCode = sortCode;
            AccountNumber = accountNumber;
            Account = account ?? throw new ArgumentNullException(nameof(account));
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }
        //public string Phone { get; set; }
        //public string PhoneNumber { get; set; }
        //public bool EmailConfirmed { get; set; }
        //public bool PasswordConfirmed { get; set; }
        //public bool PhoneConfirmed { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public Account Account { get; set; }
    }

    enum AccountType
    {
        CurrentAccount,
        SavingsAccount,
        PremiumAccount
    }
}
