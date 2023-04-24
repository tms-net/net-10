using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Дан массив целых чисел nums, поверните массив вправо на k шагов, где k неотрицательное число.
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int[] result = new int[nums.Length];
            int k = Convert.ToInt32(Console.ReadLine());
           
            for (int i = 0; i < nums.Length ; i++)
            {
                if (i < k)
                {
                    Console.WriteLine(result[i] = nums[nums.Length - (k - i)]);
                    
                }
                else
                {
                    Console.WriteLine(result[i] = nums[i - k]); 
                }
                                
            }
        }
    }
}
