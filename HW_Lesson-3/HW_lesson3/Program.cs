internal class Program
{
    private static void Main(string[] args)
    {
        int a;
        int b;
        int result;
        string operation;

        Console.WriteLine("Программа, может выполнить арифметические вычисления с двумя числами.\n");

       
            Console.Write("Код операций:\n1 - Сложение\n2 - Вычитание\n3 - Возведение с степень\n4 - Умножение\n5 - Деление\n");
            Console.Write("Выберите Вашу операцию:");
            operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    Console.Write("Введите первую переменную:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    b = Convert.ToInt32(Console.ReadLine());
                    result = a + b;
                    Console.WriteLine($"Решение: {a} + {b} = {result}");
                    break;
                case "2":
                    Console.Write("Введите первую переменную:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    b = Convert.ToInt32(Console.ReadLine());
                    result = a - b;
                    Console.WriteLine($"Решение: {a} - {b} = {result}");
                    break;
                case "3":
                    Console.Write("Введите первую переменную:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите степень переменной:");
                    b = Convert.ToInt32(Console.ReadLine());
                    result = (int)Math.Pow(a, b);
                    Console.WriteLine($"Решение: {a} + {b} = {result}");
                    break;
                case "4":
                    Console.Write("Введите первую переменную:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    b = Convert.ToInt32(Console.ReadLine());
                    result = a * b;
                    Console.WriteLine($"Решение: {a} * {b} = {result}");
                    break;
                case "5":
                    Console.Write("Введите первую переменную:");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    b = Convert.ToInt32(Console.ReadLine());
                    result = a / b;
                    Console.WriteLine($"Решение: {a} / {b} = {result}");
                    break;
                default:
                    Console.WriteLine($"Вы ввели:{operation}. Такой команды не сущейтвует, введите коректный код операции:\n1 - Сложение\n2 - Вычитание\n3 - Возведение с степень\n");
                    break;
            }
        Console.ReadLine();
    }
}