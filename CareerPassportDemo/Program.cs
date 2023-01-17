// See https://aka.ms/new-console-template for more information

using CareerPassportDemo;
using CareerPassportDemo.Helpers;

var printerService = new PrinterService();
var mathsOperator = new SimpleMathsOperations();
var classRegister = new ClassRegister();
var multiples = new Multiples();
var acct = new Account();
var bank = new Bank();

printerService.Print("Hello, World!");

var numA = 7.5;
var numB = 9.0;
printerService.Print($"Addition of {numA} and {numB} is {mathsOperator.AddNumbers(numA, numB)}\n");
printerService.Print($"Subtraction of {numA} and {numB} is {mathsOperator.SubtractNumbers(numA, numB)}\n");
printerService.Print($"Multiplication of {numA} and {numB} is {mathsOperator.MultiplyNumbers(numA, numB)} \n");
printerService.Print($"Division of {numA} and {numB} is {mathsOperator.DivideNumbers(numA, numB)} \n");
printerService.Print($"Square of {numA} is {mathsOperator.SquareNumber(numA)} \n");
printerService.Print($"Square of {numB} is {mathsOperator.SquareNumber(numB)} \n");

classRegister.AddStudent(student: "Grace Jones");
classRegister.AddStudents(students: new string[] { "Ronald Sterling", "Dax Jefferson", "Arinze Chukwu", "Don Draper", "Peggy Sue" });
var students = classRegister.GetStudents();
printerService.Print($"There are {students.Count()} registered in the class.\nHere are their names:\n");
students.ToList().ForEach(x => printerService.Print($"{x}\n"));

var sumOfMultiplesOfThreeUpToHundred = multiples.SumOfMultiples(3, 100);
printerService.Print($"Sum Of Multiples Of Three Up To Hundred is {sumOfMultiplesOfThreeUpToHundred}\n");
var sumOfMultiplesOfThreeAndFiveUpToHundred = multiples.SumOfMultiples(new int[] { 3, 5 }, 100);
printerService.Print($"Sum Of Multiples Of Three and Five Up To Hundred is {sumOfMultiplesOfThreeAndFiveUpToHundred}\n");

var accumulateResult = new Accumulate().AccumulateOperations(new int[] { 1, 2, 3, 4, 5 }, x => x * x);
printerService.Print($"Accumulate Results\n");
accumulateResult.ToList().ForEach(x => printerService.Print($"{x}\n"));

acct.Deposit(DateTime.UtcNow, 800);
acct.Withdraw(DateTime.UtcNow, 100);
acct.Withdraw(DateTime.UtcNow, 150);
acct.ShowBankStatement();

var acctNumberA = "1284393293";
var sortCodeA = "12-23-34";
var sortCodeB = "12-23-35";
var acctNumberB = "1284393295";
var userA = AccountHelper.GenerateNewUser("Joe", "Gee", DateTime.Today.AddYears(-19), acctNumberA, sortCodeA, AccountHelper.GenerateNewAccount(acctNumberA), AccountType.CurrentAccount);
var userB = AccountHelper.GenerateNewUser("Zoe", "Zee", DateTime.Today.AddYears(-25), acctNumberB, sortCodeB, AccountHelper.GenerateNewAccount(acctNumberB), AccountType.CurrentAccount);
bank.CreateUserAccount(userA);
bank.CreateUserAccount(userB);
bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 5000);
bank.BankUsers.First().Account.Withdraw(DateTime.UtcNow, 2000);
bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 6000);
bank.BankUsers.First().Account.Withdraw(DateTime.UtcNow, 2500);
bank.BankUsers.First().Account.Deposit(DateTime.UtcNow, 2934);
bank.BankUsers.Last().Account.Deposit(DateTime.UtcNow, 5000);
bank.BankUsers.Last().Account.Withdraw(DateTime.UtcNow, 2000);
bank.BankUsers.Last().Account.Deposit(DateTime.UtcNow, 6000);
bank.BankUsers.Last().Account.Withdraw(DateTime.UtcNow, 2500);
bank.BankUsers.Last().Account.Deposit(DateTime.UtcNow, 2934);
bank.TransferFunds(sortCodeA, acctNumberA, sortCodeB, acctNumberB, 1000);
printerService.Print("Account A");
bank.BankUsers.First().Account.ShowBankStatement();
printerService.Print("Account B");
bank.BankUsers.Last().Account.ShowBankStatement();

public class PrinterService
{
    public void Print(object word)
    {
        Console.WriteLine(word);
    }
}

public class SimpleMathsOperations
{
    public double AddNumbers(double x, double y) => x + y;

    public double SubtractNumbers(double x, double y) => x - y;

    public double MultiplyNumbers(double x, double y) => x * y;

    public double DivideNumbers(double x, double y) => x / y;

    public double SquareNumber(double x) => x * x;
}

//Level 1
//- Working with Arrays/ Lists: Student / Class Room Register => Record given values and print in console
public class ClassRegister
{
    private readonly List<string> _students;

    public ClassRegister()
    {
        _students = new List<string>();
    }

    public void AddStudent(string student) => _students.Add(student);

    public void AddStudents(IEnumerable<string> students) => _students.AddRange(students);

    public IEnumerable<string> GetStudents() => _students;
}

//-Simple Maths Operations => Sum of Multiple lvl 1 and 2
public class Multiples
{
    public int SumOfMultiples(int n, int max) => Enumerable.Range(1, max - 1).Where(p => p % n == 0).Sum();

    public int SumOfMultiples(IEnumerable<int> multiples, int max) => Enumerable.Range(1, max - 1).Where(p => multiples.Any(q => q > 0 && p % q == 0)).Sum();
}

//Accumulate
public class Accumulate
{
    public IEnumerable<int> AccumulateOperations(IEnumerable<int> collection, Func<int, int> func) => collection.Select(value => func(value));
}

//Level 3
//- Bank / ATM Kata(Task)
//> Given a client makes a deposit(s) / withdrawal(s)
//> Print their bank statement

public class Account : AccountBase
{
}

//Level 4/5
//- Level Bank Account Kata
//> Create Account
//> Deposit/ Withdraw
//> Transfer funds
//> Account Statement
//> Statement Printing
//> Statement Filters

public class Bank : AbstractBank
{
}

//Level 5/6
//- Banking System
//> Create Bank(s)
//> Create Account in Bank(s)
//> Deposit / Withdraw from Account in Bank(s)
//> Transfer funds between Account in Bank(s)
//> Account Statement
//> Statement Printing
//> Statement Filters

public class BankingGroup
{
    //Is this required
}