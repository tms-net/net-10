using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator

{ internal class calculator1
    {
        static void Main(string[] args)
        {
            double firsnumber, seconnumber;
            Console.WriteLine("Введите первое значение и нажмите enter");
            firsnumber = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе значение и нажмите enter");
        seconnumber = double.Parse(Console.ReadLine());
            bool calc = true;
            while (calc)
            {
                Console.WriteLine("Выберите операцию которую хотите произвести: '+', '-', '*', '/', '^' ");
                char operation = Convert.ToChar(Console.ReadLine());
                double result;
                switch (operation)
                {
                    case '+':
                        {
                            result = firsnumber + seconnumber;
                            Console.WriteLine($"{firsnumber} + {seconnumber}={result}");
                            break;
                        }
                    case '-':
                        {
                            result = firsnumber - seconnumber;
                            Console.WriteLine($"{firsnumber} - {seconnumber}={result}");
                            break;
                        }
                    case '*':
                        {
                            result = firsnumber * seconnumber;
                            Console.WriteLine($"{firsnumber} * {seconnumber}={result}");
                            break;
                        }
                    case '/':
                        {
                            result = firsnumber / seconnumber;
                            Console.WriteLine($"{firsnumber} / {seconnumber}={result}");
                            break;
                        }
                    case '^':
                        {
                            result = Math.Pow(firsnumber, seconnumber);
                            Console.WriteLine($"{firsnumber} ^ {seconnumber}={result}");
                            break;
                        }
                    default:
                        {
                        Console.WriteLine("Ошибка!");
                            break;
                        }
                }
                break;

            }
            Console.ReadKey();
        }
    }
}