// See https://aka.ms/new-console-template for more information
var printerService = new PrinterService();
printerService.Print("Hello, World!");
//Console.WriteLine("Hello, World!");


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