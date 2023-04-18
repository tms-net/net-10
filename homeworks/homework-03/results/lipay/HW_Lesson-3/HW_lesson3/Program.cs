internal class Program
{
    private static void Main(string[] args)
    {
            double FirstNumber; // Первое число
            double SecondNumber; // Второе число
            double result; // Результат
            string operation; // Выбор операции

            Console.WriteLine("Программа, может выполнить арифметические вычисления с двумя числами.\n");
            Console.Write("Код операций:\n1 - Сложение\n2 - Вычитание\n3 - Возведение с степень\n4 - Умножение\n5 - Деление\n0 - Закончить выполенние программы\n");
            Console.Write("Выберите Вашу операцию:");
            operation = Console.ReadLine();

        switch (operation)
            {
                case "1":
                    Console.Write("Введите первую переменную:");
                    FirstNumber = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    SecondNumber = Convert.ToDouble(Console.ReadLine());
                    result = FirstNumber + SecondNumber;
                    Console.WriteLine($"Решение: {FirstNumber} + {SecondNumber} = {result}");
                    break;
                case "2":
                    Console.Write("Введите первую переменную:");
                    FirstNumber = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    SecondNumber = Convert.ToDouble(Console.ReadLine());
                    result = FirstNumber - SecondNumber;
                    Console.WriteLine($"Решение: {FirstNumber} - {SecondNumber} = {result}");
                    break;
                case "3":
                    Console.Write("Введите первую переменную:");
                    FirstNumber = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите степень переменной:");
                    SecondNumber = Convert.ToDouble(Console.ReadLine());
                    result = (int)Math.Pow(FirstNumber, SecondNumber);
                    Console.WriteLine($"Решение: {FirstNumber}^{SecondNumber} = {result}");
                    break;
                case "4":
                    Console.Write("Введите первую переменную:");
                    FirstNumber = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    SecondNumber = Convert.ToDouble(Console.ReadLine());
                    result = FirstNumber * SecondNumber;
                    Console.WriteLine($"Решение: {FirstNumber} * {SecondNumber} = {result}");
                    break;
                case "5":
                    Console.Write("Введите первую переменную:");
                    FirstNumber = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите вторую переменную:");
                    SecondNumber = Convert.ToDouble(Console.ReadLine());
                    result = FirstNumber / SecondNumber;
                    Console.WriteLine($"Решение: {FirstNumber} / {SecondNumber} = {result}");
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine($"Вы ввели:{operation}. Такой команды не сущейтвует, введите коректный код операции:\n1 - Сложение\n2 - Вычитание\n3 - Возведение с степень\n");
                    break;
            }
    }
}