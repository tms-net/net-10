// See https://aka.ms/new-console-template for more information
Console.WriteLine("Array taksks");

int[] myArray = new int[] { 4, 22, 37, 9, 13, 40, 51 };
int k = 5;

int[] result = SolveArrayTask(myArray, k);

int[] SolveArrayTask(int[] nums, int k)
{
    for (int i = 0; i < k; i++)
    {
        int[] otherArray = new int[nums.Length];
        int lastItem = nums[^1];
        Array.Copy(nums, 0, otherArray, 1, otherArray.Length - 1);
        otherArray[0] = lastItem;
        nums = otherArray;
        var output = string.Join(" ", nums);
        Console.WriteLine(output);
    }
    return nums;
}
