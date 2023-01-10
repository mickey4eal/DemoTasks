// See https://aka.ms/new-console-template for more information

namespace CareerPassportDemo
{
    public abstract class AbstractBank
    {
        private readonly List<User> _bankUsers;

        protected AbstractBank()
        {
            _bankUsers = new List<User>();
        }

        public void CreateUserAccount(User user)
        {
            if(UserIsValid(user))
            {
                _bankUsers.Add(user);
            }
            else
            {
                throw new ArgumentException("User Not Valid.");
            }
        }

        private bool UserIsValid(User user)
        {
            return true;
        }

        public void TransferFunds(
            string recipientSortCode, 
            string recipientAccountNumber,
            string sendersSortCode,
            string sendersAccountNumber,
            double amount)
        {
            var recipient = FindUser(recipientSortCode, recipientAccountNumber);
            var sender = FindUser(sendersSortCode, sendersAccountNumber);

            if (recipient == null || sender == null)
                throw new NullReferenceException();

            if (recipient.Account.CanWithdraw(amount))
            {
                recipient.Account.Withdraw(DateTime.UtcNow, amount);
                sender.Account.Deposit(DateTime.UtcNow, amount);//To Do: Add details of sender (i.e. Full Name) to Statement 
            }
        }

        private User? FindUser(
            string sortCode,
            string acountNumber)
        {
            return _bankUsers.FirstOrDefault(x => x.AccountNumber == acountNumber && x.SortCode == sortCode);
        }
    }
}