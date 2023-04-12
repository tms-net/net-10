//  Обратный Массив

/*  using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введи числа через пробел: ");
        string input = Console.ReadLine();
        string[] elements = input.Split(' ');

        int[] nums = new int[elements.Length];
        for (int i = 0; i < elements.Length; i++)
        {
            nums[i] = int.Parse(elements[i]);
        }

        Array.Reverse(nums);

        Console.WriteLine("Результат: " + string.Join(" ", nums));
    }
}
*/

/*    Найдите четные (нечетные) элементы массива
int[] nums = new int[] { 1, 2, 3, 4 };
List<int> evenNumbers = new List<int>();
for (int i = 0; i < nums.Length; i++)
{
    if (nums[i] % 2 == 0)
    {
        evenNumbers.Add(nums[i]);
    }
}
int[] result = evenNumbers.ToArray();
*/


/*  Бегущая сумма массива
  int[] nums = new int[] { 1, 2, 3, 4 };
int[] runningSum = new int[nums.Length];
int sum = 0;
for (int i = 0; i < nums.Length; i++)
{
    sum += nums[i];
    runningSum[i] = sum;
}
*/


/*  поверните массив вправо на k шагов, где k неотрицательное число.
    int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
int k = 3;
int n = nums.Length;
int[] result = new int[n];
for (int i = 0; i < n; i++)
{
    result[(i + k) % n] = nums[i];
}
*/
