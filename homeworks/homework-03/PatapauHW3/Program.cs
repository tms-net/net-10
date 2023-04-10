namespace PatapauHW3
{
    internal class Program
    {
        private static bool work = true;
        static void Main(string[] args)
        {
            //(выполняется пока не введина команда exit для завершения работы)
            while (work)
            {
                DataInput();
            }
        }

        private static void DataInput()
        {
            double firstNumber, secondNumber;
            bool newNumber = false;
            //Ввод первого числа
            Console.WriteLine("Введите первое число");
            while (!double.TryParse(Console.ReadLine(), out firstNumber))
            {
                Console.WriteLine("Введен неверный формат данных! Повторите попытку ввода первого числа!");
            }
            //Ввод второго числа
            Console.WriteLine("Введите второе число");
            while (!double.TryParse(Console.ReadLine(), out secondNumber))
            {
                Console.WriteLine("Введен неверный формат данных! Повторите попытку ввода второго числа!");
            }
            //Выбор операции над числами(выполняется пока не введина команда newNumber для ввода новых значений)
            while (!newNumber)
            {
                //exit - выход из программы, newNumber - ввод новых значений чисел
                Console.WriteLine("Выберите операцию над числами( + , - , / , * , % , ^ , exit - завершить работу, newNumber - ввод новых значений чисел)");
                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "exit":
                        work = false;
                        newNumber = true;
                        Console.WriteLine("Работа программы завершена. Нажмите любую клавишу для закрытия консоли.");
                        break;
                    case "newNumber":
                        newNumber = true;
                        break;
                    default:
                        Console.WriteLine("Результат операции. " + Calculate(operation, firstNumber, secondNumber));
                        break;
                }
            }
        }
        //функция возвращающая значение после выполнения операции на числами
        private static string Calculate(string operation, double firstNumber, double secondNumber)
        {
            return operation switch
            {
                "+" => $"{firstNumber + secondNumber}",
                "-" => $"{firstNumber - secondNumber}",
                "/" => secondNumber == 0 ? "На ноль делить нельзя!" : $"{firstNumber / secondNumber}",
                "*" => $"{firstNumber * secondNumber}",
                "%" => secondNumber == 0 ? "На ноль делить нельзя!" : $"{firstNumber % secondNumber}",
                "^" => $"{Math.Pow(firstNumber, secondNumber)}",
                _ => "Введина неизвестная операция!"
            };
        }
    }
}