﻿namespace hw_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1)Измените порядок массива на противоположный

            //инициализация массива

            Console.WriteLine("enter array length: ");
            int arrLength = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[arrLength];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10);
                Console.Write(array[i]+" ");
            } 
            Console.WriteLine();
            Console.WriteLine(new String('-', 50));
            
            //вызов метода
            ArrayRevers(ref array);
            //вывод измененного массива
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+" ");
            }


            //delay
            //Console.ReadKey();

        }
        /// <summary>
        /// метод делает реверс массива
        /// </summary>
        /// <param name="array"></param>
        static void ArrayRevers(ref int[] array)
        {
            int[] arr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arr[i] = array[array.Length - i - 1];
            }
            array = arr;
        }
    }
}