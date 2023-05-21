namespace PatapauHW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            bool newNumbers;
            double firstNumber, secondNumber;
            string operation;
 
            while (isRunning)
            {
                newNumbers = false;
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
                while (!newNumbers)
                {
                    //exit - выход из программы, newNumber - ввод новых значений чисел
                    Console.WriteLine("Выберите операцию над числами( + , - , / , * , % , ^ , exit - завершить работу, newNumber - ввод новых значений чисел)");
                    operation = Console.ReadLine();

                    switch (operation)
                    {
                        case "exit":
                            isRunning = false;
                            newNumbers = true;
                            Console.WriteLine("Работа программы завершена. Нажмите любую клавишу для закрытия консоли.");
                            break;
                        case "newNumber":
                            newNumbers = true;
                            break;
                        case "+":
                        case "-":
                        case "/":
                        case "*":
                        case "^":
                        case "%":
                            Console.WriteLine("Результат операции. " + Calculate(operation, firstNumber, secondNumber));
                            break;
                        default:
                            Console.WriteLine("Введена неизвестная операция! Попробуйте повторить попытку.");
                            break;
                    }
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
                _ => "Введена неизвестная операция!"
            };
        }
    }
}