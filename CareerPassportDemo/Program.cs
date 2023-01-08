// See https://aka.ms/new-console-template for more information
var printerService = new PrinterService();
var mathsOperator = new SimpleMathsOperations();
printerService.Print("Hello, World!");

var numA = 7.5;
var numB = 9.0;

printerService.Print($"Addition of {numA} and {numB} is {mathsOperator.AddNumbers(numA, numB)}\n");
printerService.Print($"Subtraction of {numA} and {numB} is {mathsOperator.SubtractNumbers(numA, numB)}\n");
printerService.Print($"Multiplication of {numA} and {numB} is {mathsOperator.MultiplyNumbers(numA, numB)} \n");
printerService.Print($"Division of {numA} and {numB} is {mathsOperator.DivideNumbers(numA, numB)} \n");
printerService.Print($"Square of {numA} is {mathsOperator.SquareNumber(numA)} \n");
printerService.Print($"Square of {numB} is {mathsOperator.SquareNumber(numB)} \n");


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