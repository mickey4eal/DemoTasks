﻿// See https://aka.ms/new-console-template for more information
using System.Security.Claims;

var printerService = new PrinterService();
var mathsOperator = new SimpleMathsOperations();
var classRegister = new ClassRegister();
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