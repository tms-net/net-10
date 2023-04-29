using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace KlindyukLesson3_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Launch();

        }

        private static void Launch()
        {
            try
            {
                Console.WriteLine("Select the arithmetic operation:");
                Console.WriteLine("1 - Addition\n" + "2 - Subtraction\n"
                                + "3 - Multiplication\n" + "4 - Division\n"
                                + "5 - Exponentiation\n" + "6 - Remainder of the division\n" + "7 - Division with remainder");
                Console.Write("Your select: ");
                byte select = Convert.ToByte(Console.ReadLine());
                if (select <= 7 && select > 0)
                {
                    Console.WriteLine("Input first number:");
                    int firstNumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input second number:");
                    int secondNumber = Convert.ToInt32(Console.ReadLine());
                    SelectOperation(select, firstNumber, secondNumber);
                }
                else
                {
                    Console.WriteLine("You select a wrong value... Try again...\n");
                    Launch();
                }
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("You select a wrong value or divide by zero... Try again...\n");
                Launch();
            }

        }

        private static void SelectOperation(byte opereation, int firstNumber, int secondNumber)
        {
            switch (opereation)
            {
                case 1:
                    Console.WriteLine($"Result: {firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                    break;
                case 2:
                    Console.WriteLine($"Result: {firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                    break;
                case 3:
                    Console.WriteLine($"Result: {firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                    break;
                case 4:
                    Console.WriteLine($"Result: {firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                    break;
                case 5:
                    Console.WriteLine($"Result: {firstNumber} ^ {secondNumber} = {Math.Pow(firstNumber, secondNumber)}");
                    break;
                case 6:
                    Console.WriteLine($"Result: {firstNumber} % {secondNumber} = {firstNumber % secondNumber}");
                    break;
                case 7:
                    Console.WriteLine($"Result: {firstNumber} / {secondNumber} = {firstNumber / (secondNumber * 1.0f)}");
                    break;
            }
            Repeat();
        }

        private static void Repeat()
        {
            Console.WriteLine("Do you want to repeat select operation? [Y / N]");
            String select = Console.ReadLine().ToUpper();
            Console.WriteLine();
            if (select.Equals("Y"))
            {
                Launch();
            }
            else if (select.Equals("N"))
            {
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Wrong value");
                Repeat();
            }
            Console.ReadKey();
        }
    }
}
