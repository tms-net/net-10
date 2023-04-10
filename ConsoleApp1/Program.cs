using System.Reflection.Emit;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* NUMBER 1
 Вам необходимо разработать программу, 
которая сможет выполнить арифметические вычисления с двумя числами, такие как
- сложение/вычитание
- умножение деление
- возведение числа в степень другого

             */

            //1)

            //проверка на формат
            try
            {
                //ввод 1-ого число
                double num1;
                {
                    Console.WriteLine("enter first number: ");
                    num1 = Convert.ToInt32(Console.ReadLine());
                }

                //проверка введенной операции,
                //будет проверять дотех пор пока не будет введена операция из каталога
                string operation;
                {

                Label1:
                    Console.WriteLine("enter operation(+,-,*,/,^)");
                    operation = Console.ReadLine();
                    if (operation != "+" & operation != "-" & operation != "*" & operation != "/" & operation != "")
                    {
                        Console.WriteLine("incorrect operation,enter again");
                        goto Label1;
                    }
                }

                //ввод 2-ого число
                double num2;
                {
                    Console.WriteLine("enter second number: ");
                    num2 = Convert.ToInt32(Console.ReadLine());
                }

                //в эту переменную будет присвоен результат ариф.операций
                double result = 0;


                Calculate(num1, num2, operation, ref result);
                Console.WriteLine(result);
            }

            catch (FormatException)
            {
                Console.WriteLine("FormatException");

            }




        }
        /// <summary>
        /// арифметические действия над 2-мя числами
        /// </summary>
        /// <param name="num1">1-ое число</param>
        /// <param name="num2">2-ое число</param>
        /// <param name="operation">операция</param>
        /// <param name="result">переменная присвоенния результата</param>
        static void Calculate(double num1, double num2, string operation, ref double result)

        {
            result = 0;
            switch (operation)
            {

                case "+":
                    result = num1 + num2;
                    Console.Write($"{num1} + {num2} = ");
                    break;

                case "-":
                    result = num1 - num2;
                    Console.Write($"{num1} - {num2} = ");
                    break;

                case "*":
                    result = num1 * num2;
                    Console.Write($"{num1} * {num2} = ");
                    break;

                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("division by zero");
                        break;
                    }
                    result = num1 / num2;
                    Console.Write($"{num1} / {num2} = ");

                    break;

                case "^":
                    result = Math.Pow(num1, num2);
                    Console.Write($"{num1} ^ {num2} = ");
                    break;
                default:
                    Console.WriteLine("incorrect operation");
                    break;
            }
        }
    }
}