// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Array taksks");

Console.Write("Enter array length:");

int[] myArray = new int[Int32.Parse(Console.ReadLine())];

for(int i = 0; i < myArray.Length; i++)
{
    Console.Write($"Enter {i+1} element:");
    myArray[i]=Int32.Parse(Console.ReadLine());
}

Console.Write("Enter shift:");

int shift = Int32.Parse(Console.ReadLine());

int[] result = SolveArrayTask(myArray,shift);

int[] SolveArrayTask(int[] nums,int shift)
{  
    throw new NotImplementedException();
}

