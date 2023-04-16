using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_lesson_4_v1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Измените порядок массива на противоположный
             
            int[] nums= {1, 2, 3, 4};

            Console.WriteLine("Array output");

            for (int i = nums.Length - 1; i >= 0 ; i--)
            {
                Console.WriteLine(nums[i]);
            }
            Console.ReadLine();
        }
    }
}
