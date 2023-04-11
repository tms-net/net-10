// See https://aka.ms/new-console-template for more information
Console.WriteLine("Array taksks");

int[] myArray = new int[] { 4, 22, 37, 9, 13, 40, 51 };

int[] result = SolveArrayTask(myArray);

Console.WriteLine(string.Join(", ", result));

int[] SolveArrayTask(int[] nums)
{
    int[] reversedArray = new int[nums.Length];

    for (int i = 0; i < nums.Length; i++)
    {
        reversedArray[i] = nums[nums.Length - 1 - i];
    }

    return reversedArray;
}