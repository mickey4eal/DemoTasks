// See https://aka.ms/new-console-template for more information

public class AccountBase
{
    private const string header = "Date  |   Amount  |   Balance ";
    private readonly List<string> _statement;
    private double _balance;
    private double _accountNumber;

    public AccountBase()
    {
        _statement = new List<string>() { header };
        _balance = 0;
    }

    public IEnumerable<string> AccountStatement { get => _statement; }
    public double Balance { get => _balance; }
    public double AccountNumber { get => _accountNumber; set => _accountNumber = value; }

    public void AddTransaction(DateTime dateTime, double amount) => _statement.Add($"{dateTime}  |   {amount}  |   {Balance} ");

    public void Deposit(DateTime dateTime, double amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            AddTransaction(dateTime, amount);
        }
        else
        {
            throw new ArgumentException("Invalid Amount");
        }
    }

    public void ShowBankStatement()
    {
        var printer = new PrinterService();
        AccountStatement.ToList().ForEach(x => printer.Print($"{x}"));
    }

    public void Withdraw(DateTime dateTime, double amount)
    {
        if (CanWithdraw(amount))
        {
            _balance -= amount;
            AddTransaction(dateTime, amount);
        }
        else
        {
            throw new ArgumentException("Insufficient Funds in Account.");
        }
    }

    public bool CanWithdraw(double amount) => (_balance - amount) >= 0;
}