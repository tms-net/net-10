internal class Program
{
    private static void Main(string[] args)
    {
        
        int a;
        int b;
        int method;
        double rez;

        Console.Write("Введите первое число: ");
        a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите первое число: ");
        b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Введите номер операции: \n 1) Деление \n 2) Умножение \n 3) Сложение \n 4) Вычитание \n 5) Возведение в степень");
        method = Convert.ToInt32(Console.ReadLine());

        while (method > 5)
        {
            Console.WriteLine("Некорректный выбор пункта ");
            Console.WriteLine($"Введите номер операции: \n 1) Деление \n 2) Умножение \n 3) Сложение \n 4) Вычитание \n 5) Возведение в степень");
            method = Convert.ToInt32(Console.ReadLine());
        }
        
        if (method == 1)
            
        {
            //rez = a / b + (Convert.ToSingle(a) % b);
            //rez = a / b;

            rez = Convert.ToDouble(a) / b;
            Console.WriteLine("Ответ: " + rez);
        }

        else if (method == 2)
        {
            rez = a * b;
            Console.WriteLine("Ответ: " + rez);
        }
        else if (method == 3)
        {
            rez = a + b;
            Console.WriteLine("Ответ: " + rez);
        }
        else if (method == 4)
        {
            rez = a - b;
            Console.WriteLine("Ответ: " + rez);
        }
        else if (method == 5)
        {
            if (b > b / 1 && a > a / 1)
            {
                Console.WriteLine($"Невозможно возвести в степень");
            }
            else
            {
                //var step = 1;
                //for (int i = 0; i < b; i++)
                //{
                //    step = step * a;
                //}
                //rez = step;
                //Console.WriteLine("Ответ: " + rez);
                Console.WriteLine($"{Math.Pow(a, b)}"); // Math.Pow()
            }

        }
        Console.ReadKey();
    }
}