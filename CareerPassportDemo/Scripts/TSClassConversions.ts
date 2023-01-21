//TypeScript
export class PrinterService {
    public Print(word: string | null): void { }
}

export class SimpleMathsOperations {
    public AddNumbers(x: number, y: number): number {
        return x + y;
    }
    public SubtractNumbers(x: number, y: number): number {
        return x - y;
    }
    public MultiplyNumbers(x: number, y: number): number {
        return x * y;
    }
    public DivideNumbers(x: number, y: number): number {
        return x / y;
    }
    public SquareNumber(x: number): number {
        return x * x;
    }
}


import { TypeInfo } from "@brandless/tsutility";
export class ClassRegister {
    constructor() { }
    public AddStudent(student: string | null): void { }
    public AddStudents(students: string | null): void { }
    public GetStudents(): void { }
}

export class Multiples {
    public SumOfMultiples(n: number, max: number): number {
        return 1;
    }
}