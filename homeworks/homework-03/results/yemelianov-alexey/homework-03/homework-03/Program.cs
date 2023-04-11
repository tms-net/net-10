using System;

class Program
{
    static void Main(string[] args)
    {
        double num1, num2, result;
        char operations;

        Console.WriteLine("Выберите операцию (+, -, *, /, ^, %)");
        operations = Convert.ToChar(Console.ReadLine());

        Console.WriteLine("Введите первое число:");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите второе число:");
        num2 = Convert.ToDouble(Console.ReadLine());

        switch (operations)
        {
            case '+':
                result = num1 + num2;
                Console.WriteLine($"{num1} + {num2} = {result}");
                break;
            case '-':
                result = num1 - num2;
                Console.WriteLine($"{num1} - {num2} = {result}");
                break;
            case '*':
                result = num1 * num2;
                Console.WriteLine($"{num1} * {num2} = {result}");
                break;
            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Ошибка. Деление на 0.");
                }
                else
                {
                    result = num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {result}");
                }
                break;
            case '^':
                if (num1 == 0 && num2 < 0)
                {
                    Console.WriteLine("Ошибка. Возведение 0 в отрицательную степень.");
                }
                else
                {
                    result = Math.Pow(num1, num2);
                    Console.WriteLine($"{num1} ^ {num2} = {result}");
                }
                break;
            case '%':
                result = num1 % num2;
                Console.WriteLine($"Остаток при делении {num1} на {num2} = {result}");
                break;
            default:
                Console.WriteLine("Что-то пошло не так.");
                break;

        }
    }
}