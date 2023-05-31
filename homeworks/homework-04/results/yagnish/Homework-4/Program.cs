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

SolveArrayTask(myArray);

void SolveArrayTask(int[] nums)
{
    Console.WriteLine("Choose the operation:");
    Console.WriteLine("1.Reverse array");
    Console.WriteLine("2.Even numbers");
    Console.WriteLine("3.Begushaya array sum:)");
    Console.WriteLine("4.Array rotation");
    int choise =Int32.Parse(Console.ReadLine());
    switch (choise)
    {
        case 1:
            Console.Write("Reverse array:{0}",String.Join(",",nums.Reverse().ToArray()));
            break;
        case 2:
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0;i<nums.Length;i++)
                if (nums[i] % 2 == 0)
                    list.AddLast(nums[i]);
            Console.WriteLine("Even array numbers: {0}",String.Join(",",list.ToArray()));
            break;
        case 3:
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            Console.WriteLine("Running sum: {0}", String.Join(",", nums.ToArray()));
            break;
        case 4:
            Console.Write("Enter shift:");
            int shift = Int32.Parse(Console.ReadLine());
            int[] res = new int[nums.Length];
            Array.Copy(nums, nums.Length - shift, res, 0, shift);
            Array.Copy(nums, 0, res, shift, nums.Length - shift);
            Console.WriteLine("Shifted array: {0}", String.Join(",", res.ToArray()));
            break;
        default:
            Console.WriteLine("unsupported expression");
            break;
    }
}

