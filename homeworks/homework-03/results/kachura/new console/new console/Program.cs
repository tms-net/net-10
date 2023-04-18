using System;

Console.WriteLine($"Choose operation:\n" +
    $"1 - Sum;\n" +
    "2 - Substraction;\n" +
    "3 - Multiply;\n" +
    "4 - Divide;\n" +
    "5 - Exp;\n" +
    "6 - Log;\n" +
    "7 - Lg;\n");

var option = Input.ReadInt();
int a;
int b;

switch (option)
{
    case 1:
        Console.WriteLine("Enter a = ");
        a = Input.ReadInt();
        Console.WriteLine("Enter b = ");
        b = Input.ReadInt();
        Console.WriteLine($"The result: {a} + {b} = {Maths.Sum(a, b)}");
        break;

    case 2:
        Console.WriteLine("Enter a = ");
        a = Input.ReadInt();
        Console.WriteLine("Enter b = ");
        b = Input.ReadInt();
        Console.WriteLine($"The result: {a} - {b} = {Maths.Substraction(a, b)}");
        break;

    case 3:
        Console.WriteLine("Enter a = ");
        a = Input.ReadInt();
        Console.WriteLine("Enter b = ");
        b = Input.ReadInt();
        Console.WriteLine($"The result: {a} * {b} = {Maths.Multiply(a, b)}");
        break;

    case 4:
        Console.WriteLine("Enter a = ");
        a = Input.ReadInt();
        Console.WriteLine("Enter b = ");
        b = Input.ReadInt();
        Console.WriteLine($"The result: {a} / {b} = {Maths.Divide(a, b)}");
        break;

    case 5:
        Console.WriteLine("Enter a = ");
        a = Input.ReadInt();
        Console.WriteLine("Enter n = ");
        b = Input.ReadInt();
        Console.WriteLine($"The result: {a}^{b} = {Maths.Exp(a, b)}");
        break;

    case 6:
        Console.WriteLine("Enter base a = ");
        a = Input.ReadInt();
        Console.WriteLine("Enter b = ");
        b = Input.ReadInt();
        Console.WriteLine($"The result: log{a}({b}) = {Maths.Log(a, b)}");
        break;

    case 7:
        Console.WriteLine("Enter b = ");
        b = Input.ReadInt();
        Console.WriteLine($"The result: log({b}) = {Maths.Log(b)}");
        break;
}

//class reads input 
public static class Input
{
    public static int ReadInt()
    {
        int input = Convert.ToInt32(Console.ReadLine());

        return input;
    }
}

//class with math functions
public static class Maths
{
    public static int Sum(int a, int b)
    {
        var result = a + b;

        return result;
    }

    public static int Substraction(int a, int b)
    {
        var result = a - b;

        return result;
    }

    public static int Multiply(int a, int b)
    {
        int result = a * b;

        return result;
    }

    public static double Divide(int a, int b)
    {
        double result = 0;

        if (a > 0 && b > 0)
            result = a / b;

        return result;
    }

    public static double Exp(int a, int n)
    {
        double result = 1;
        int pow = Math.Abs(n);

        if (pow > 1)
        {
            for (int i = 0; i < pow; i++)
            {
                if (n > 0)
                    result *= a;
                else
                    result /= a;
            }
        }
        else
            result = Math.Pow(a, n);

        return result;
    }

    public static int Log(int a, int b)
    {
        int result = 1;
        double temp = b;

        if (b > 0 && a > 0)
        {
            while (temp != a)
            {
                result++;
                temp /= a;
            }
        }

        return result;
    }

    public static int Log(int b)
    {
        int result = 1;
        int temp = b;

        if (b > 0)
        {
            while (temp != 10)
            {
                result++;
                temp /= 10;
            }
        }

        return result;
    }
}