using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var rand = new Random();
        int[] arrayOfNumbers = new int[rand.Next(3, 13)];
        int[] operativeArrayOfNumbers = new int[arrayOfNumbers.Length];
        string evenElementsOfArray = "";
        string oddElementsOfArray = "";

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = rand.Next(0, 21);
        }
        operativeArrayOfNumbers = (int[])arrayOfNumbers.Clone();

        Console.WriteLine($"Created array of {arrayOfNumbers.Length} elements: ");
        PrintArray(arrayOfNumbers);

        //First task
        Console.WriteLine("\nReversed array: ");
        Array.Reverse(operativeArrayOfNumbers);
        PrintArray(operativeArrayOfNumbers);

        //Second task        
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            if (arrayOfNumbers[i] % 2 == 0)
            {
                evenElementsOfArray = evenElementsOfArray + " " + Convert.ToString(arrayOfNumbers[i]);
            }
            else
            {
                oddElementsOfArray = oddElementsOfArray + " " + Convert.ToString(arrayOfNumbers[i]);
            }
        }
        Console.WriteLine($"\nEven elements of array:\n{evenElementsOfArray}");
        Console.WriteLine($"\nOdd elements of array:\n{oddElementsOfArray}");

        //Third task
        Array.Reverse(operativeArrayOfNumbers);
        for (int i = 1; i < operativeArrayOfNumbers.Length; i++)
        {
            operativeArrayOfNumbers[i] = operativeArrayOfNumbers[i - 1] + operativeArrayOfNumbers[i];
        }
        Console.WriteLine("\nRunning sum of the array:");
        PrintArray(operativeArrayOfNumbers);

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
                    if (countOfStepsToMoveInArray >= arrayOfNumbers.Length)
                    {
                        countOfStepsToMoveInArray = countOfStepsToMoveInArray % arrayOfNumbers.Length;
                    }
                    if (countOfStepsToMoveInArray != 0)
                    {
                        if (countOfStepsToMoveInArray > 0)
                        {
                            Array.Copy(arrayOfNumbers, arrayOfNumbers.Length - countOfStepsToMoveInArray, operativeArrayOfNumbers, 0, countOfStepsToMoveInArray);
                            Array.Copy(arrayOfNumbers, 0, operativeArrayOfNumbers, countOfStepsToMoveInArray, arrayOfNumbers.Length - countOfStepsToMoveInArray);

                            Console.WriteLine($"\nThe array has moved to {countOfStepsToMoveInArrayString} steps to the right:");
                            PrintArray(operativeArrayOfNumbers);

                            flagOfCorrectChoice = true;
                        }
                        else
                        {
                            Array.Copy(arrayOfNumbers, Math.Abs(countOfStepsToMoveInArray), operativeArrayOfNumbers, 0, arrayOfNumbers.Length + countOfStepsToMoveInArray);
                            Array.Copy(arrayOfNumbers, 0, operativeArrayOfNumbers, arrayOfNumbers.Length + countOfStepsToMoveInArray, Math.Abs(countOfStepsToMoveInArray));

                            Console.WriteLine($"\nThe array has moved to {countOfStepsToMoveInArrayString} steps to the left:");
                            PrintArray(operativeArrayOfNumbers);

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
        Console.ReadLine();
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