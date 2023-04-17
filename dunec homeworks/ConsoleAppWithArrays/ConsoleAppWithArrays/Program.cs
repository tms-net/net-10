using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        var rand = new Random();
        int[] arrayOfNumbers = new int[rand.Next(3, 13)];
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = rand.Next(0, 21);
        }
        Console.WriteLine($"Created array of {arrayOfNumbers.Length} elements: ");
        PrintArray(arrayOfNumbers);

        Console.WriteLine("\nReversed array: ");
        PrintArray(SolveArrayTask1(arrayOfNumbers));

        Console.WriteLine($"\nEven elements of the array:");
        PrintArray(SolveArrayTask2(arrayOfNumbers, true));
        Console.WriteLine($"\nOdd elements of the array:");
        PrintArray(SolveArrayTask2(arrayOfNumbers, false));

        Console.WriteLine("\nRunning sum of the array:");
        PrintArray(SolveArrayTask3(arrayOfNumbers));

        PrintArray(SolveArrayTask4(arrayOfNumbers));

        Array.Clear(arrayOfNumbers);
        Console.ReadLine();
    }

    public static int[] SolveArrayTask1(int[] array)    //First task 
    {
        int[] operativeArrayOfNumbers = new int[array.Length];
        operativeArrayOfNumbers = (int[])array.Clone();

        Array.Reverse(operativeArrayOfNumbers);

        return operativeArrayOfNumbers;
    }

    public static int[] SolveArrayTask2(int[] array, bool isEven)   //Second task 
    {
        int[] operativeArrayOfNumbers = new int[array.Length];
        int countOfNeedNumber = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0 && isEven)
            {
                operativeArrayOfNumbers[countOfNeedNumber++] = array[i];
            }

            if (array[i] % 2 == 1 && !isEven)
            {
                operativeArrayOfNumbers[countOfNeedNumber++] = array[i];
            }
        }

        return operativeArrayOfNumbers[0..countOfNeedNumber];
    }

    public static int[] SolveArrayTask3(int[] array)    //Third task
    {
        int[] operativeArrayOfNumbers = new int[array.Length];

        operativeArrayOfNumbers[0] = array[0];
        for (int i = 1; i < operativeArrayOfNumbers.Length; i++)
        {
            operativeArrayOfNumbers[i] = operativeArrayOfNumbers[i - 1] + array[i];
        }

        return operativeArrayOfNumbers;
    }

    public static int[] SolveArrayTask4(int[] array)
    {
        int[] operativeArrayOfNumbers = new int[array.Length];
        //Fourth task
        bool flagOfCorrectChoice = false;
        while (!flagOfCorrectChoice)
        {
            string countOfStepsToMoveInArrayString = "";
            int countOfStepsToMoveInArray = 0;
            Console.WriteLine("\nInput count of steps to the right:");
            try
            {
                countOfStepsToMoveInArrayString = Console.ReadLine();
                if (int.TryParse(countOfStepsToMoveInArrayString, out countOfStepsToMoveInArray))
                {
                    if (Math.Abs(countOfStepsToMoveInArray) >= array.Length)
                    {
                        countOfStepsToMoveInArray = countOfStepsToMoveInArray % array.Length;
                    }
                    if (countOfStepsToMoveInArray != 0)
                    {
                        if (countOfStepsToMoveInArray > 0)
                        {
                            Array.Copy(array, array.Length - countOfStepsToMoveInArray, operativeArrayOfNumbers, 0, countOfStepsToMoveInArray);
                            Array.Copy(array, 0, operativeArrayOfNumbers, countOfStepsToMoveInArray, array.Length - countOfStepsToMoveInArray);

                            Console.WriteLine($"\nThe array has moved to {countOfStepsToMoveInArrayString} steps to the right:");

                            flagOfCorrectChoice = true;
                        }
                        else
                        {
                            Array.Copy(array, Math.Abs(countOfStepsToMoveInArray), operativeArrayOfNumbers, 0, array.Length + countOfStepsToMoveInArray);
                            Array.Copy(array, 0, operativeArrayOfNumbers, array.Length + countOfStepsToMoveInArray, Math.Abs(countOfStepsToMoveInArray));

                            Console.WriteLine($"\nThe array has moved to " + countOfStepsToMoveInArrayString.Substring(1, countOfStepsToMoveInArrayString.Length - 1) + " steps to the left:");

                            flagOfCorrectChoice = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nInputed text can't be converted into a whole number or inputted number is bigger than 2,147,483,647");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInputed text isn't correct: " + e.Message);
            }
        }
        return operativeArrayOfNumbers;
    }
    public static void PrintArray(int[] array)
    {
        string outputArray = "";
        for (int i = 0; i < array.Length; i++)
        {
            outputArray = outputArray + " " + Convert.ToString(array[i]);
        }
        Console.WriteLine(outputArray);
    }
}