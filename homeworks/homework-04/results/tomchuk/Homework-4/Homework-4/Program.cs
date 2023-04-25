// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

public class Program
{
    public static void Main()
    {

        int[] myArray = new int[] { 4, 22, 37, 9, 13, 40, 51 };

        int[] result = SolveArrayTask(myArray);

        foreach (int i in result)
        {
            Console.WriteLine(i);
        }
    }

    static int[] SolveArrayTask(int[] nums)
    {
        Array.Reverse(nums);
        return nums;
    }

}