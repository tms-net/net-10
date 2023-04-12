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