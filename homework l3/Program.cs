using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkL3
{/*
  * Вам необходимо разработать программу, которая сможет выполнить арифметические вычисления с двумя числами, такие как
- сложение/вычитание
- умножение деление
- возведение числа в степень другого
  */
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstvalue, secondvalue;
            Console.WriteLine("enter the first value");
            firstvalue= double.Parse(Console.ReadLine());
            Console.WriteLine("enter the second value");
            secondvalue= double.Parse(Console.ReadLine());
            bool calc = true;
            while (calc)
            {
                Console.WriteLine("select the operation: '+', '-', '*', '/', '^' ");
                char operation=Convert.ToChar(Console.ReadLine());
                double result;
                switch (operation)
                {
                    case '+':
                        {
                            result = firstvalue + secondvalue;
                            Console.WriteLine($"{firstvalue} + {secondvalue}={result}");
                            break;
                        }
                    case '-':
                        {
                            result = firstvalue - secondvalue;
                            Console.WriteLine($"{firstvalue} - {secondvalue}={result}");
                            break;
                        }
                    case '*':
                        {
                            result = firstvalue * secondvalue;
                            Console.WriteLine($"{firstvalue} * {secondvalue}={result}");
                            break;
                        }
                    case '/':
                        {
                            result = firstvalue / secondvalue;
                            Console.WriteLine($"{firstvalue} / {secondvalue}={result}");
                            break;
                        }
                    case '^':
                        {
                            result = Math.Pow(firstvalue, secondvalue);
                            Console.WriteLine($"{firstvalue} ^ {secondvalue}={result}");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("error");
                            break;
                        }
                }break;

            }
            Console.ReadKey();
        }
    }
}
