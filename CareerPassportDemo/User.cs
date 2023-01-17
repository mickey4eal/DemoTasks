﻿namespace CareerPassportDemo
{
    public class User
    {
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

        public AccountType AccountType { get; set; }
    }

    public enum AccountType
    {
        CurrentAccount,
        SavingsAccount,
        PremiumAccount
    }
}