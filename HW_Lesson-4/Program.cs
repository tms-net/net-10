internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Array taksks");

        int[] myArray = new int[] { 4, 22, 37, 9, 13, 40, 51 };

        int[] result = SolveArrayTask(myArray);

        static int[] SolveArrayTask(int[] nums)
        {
            int j = 0;
            int[] NewArray = new int[nums.Length];
            for (int i = nums.Length - 1; i >= 0; i--)
            {


                NewArray[j] = nums[i];
                j++;
            }
            return NewArray;
        }
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(" " + result[i] + " ");
        }

        Console.ReadLine();



    }
}