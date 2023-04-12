using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var rand = new Random();
        double[] arrayOfNumbers = new double[rand.Next(3, 10)];
        double[] operativeArrayOfNumbers = new double[arrayOfNumbers.Length];

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            arrayOfNumbers[i] = Math.Round(rand.NextDouble() * 10, 5);
        }
        operativeArrayOfNumbers = (double[])arrayOfNumbers.Clone();

        Console.WriteLine($"Created array of {arrayOfNumbers.Length} elements: ");
        PrintArray(arrayOfNumbers);

        Array.Reverse(operativeArrayOfNumbers);
        Console.WriteLine("\nReversed array: ");
        PrintArray(operativeArrayOfNumbers);

        Console.ReadLine();
    }

    static void PrintArray(double[] array)
    {
        string outputArray = Convert.ToString(array[0]);
        for (int i = 1; i < array.Length; i++)
        {
            outputArray = outputArray + " " + Convert.ToString(array[i]);
        }  
        Console.WriteLine(outputArray);
    }
}