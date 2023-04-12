using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace hw_4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ////1)Измените порядок массива на противоположный

            ////инициализация массива

            //Console.WriteLine("enter array length: ");
            //int arrLength = Convert.ToInt32(Console.ReadLine());

            //int[] array = new int[arrLength];
            //Random random = new Random();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = random.Next(10);
            //    Console.Write(array[i]+" ");
            //} 
            //Console.WriteLine();
            //Console.WriteLine(new String('-', 50));

            ////вызов метода
            //ArrayRevers(ref array);
            ////вывод измененного массива
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write(array[i]+" ");
            //}

            ////2)
            ////      Найдите четные (нечетные) элементы массива
            ////         Пример:
            ////         Исходный массив: nums = [1,2,3,4]
            ////         Результат выполнения: [2,4]

            ////инициализация массива
            //int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ////вывод массива
            //foreach (var item in array)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine("enter what do you want to find:\n" +
            //    "1)Odd numbers\n" +
            //    "2)Not odd numbers");
            //string chooseMessage = Console.ReadLine();
            ////вызов метода,который находит четные числа.
            //if (chooseMessage =="1")
            //    findOddNumbersInArray(array);
            ////вызов метода,который находит не четные числа.
            //if (chooseMessage =="2")
            //    findNotOddNumbersInArray(array);

            ////3)
            ////       Найти бегущую сумму массива
            ////Пример:
            ////Исходный массив: nums = [1, 2, 3, 4]
            //// Результат выполнения: [1,3,6,10] // [1,1+2,1+2+3,1+2+3+4]
            ////Объяснение:
            //// Бегущая сумма массива - это массив,
            //// который хранит сумму всех элементов до текущего элемента в
            //// исходном массиве(включая его).

            ////инициал. массива
            //int[] array = { 1, 2, 3, 4, 5 };
            ////вывод массива
            //foreach (var item in array)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();
            ////присваивание метода,который ещет бегущую сумму массива
            //int[] runArraySum = RunnigArraySum(array);
            ////выводим новый массив
            //foreach (var item in runArraySum)
            //{
            //    Console.Write($"{item} ");
            //}

    //        //4)-1
    ////Дан массив целых чисел nums, поверните массив вправо на k шагов, где k неотрицательное число.
    ////Пример:
    ////  Исходный массив: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
    ////  Результат выполнения: [5,6,7,1,2,3,4]
    //// Объяснение:
    ////        поверните на 1 шаг вправо: [7,1,2,3,4,5,6]
    ////    поверните на 2 шага вправо: [6,7,1,2,3,4,5]
    ////    поверните на 3 шага вправо: [5,6,7,1,2,3,4]
    //        //инициализация массива

    //        int[] array = { 1, 3, 43, 2, 4 };
    //        int k = 3;
    //        //присвоение новому массиву результат метода,который 
    //        //берет массив:
    //        //1)делает реверс
    //        //2)делает реверс чисел от нуля до k
    //        //3)делает реверс от k до (длинны массива минус k)
    //        int[] newArray = solveArrayTask(array, k);


    //        //4)-2
    //        //int temp = 0;
    //        //for (int i = 0; i <array.Length; i++)
    //        //{
    //        //    Console.WriteLine();
    //        //    for (int j = 0; j < k; j++)
    //        //    {
    //        //        temp = array[i];
    //        //        array[i] =array[array.Length-1-j];
    //        //        array[array.Length-1-j] = temp;
    //        //    }

    //        //}

        }
        /// <summary>
        /// метод ищет бегущую сумму массива
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int[] RunnigArraySum(int[] array)
        {
            int sum = 0;
            int[] runArraySum = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j <= array[i]; j++)
                {
                    sum+=j;
                    runArraySum[i] = sum;
                }
                sum=0;
            }
            return runArraySum;
        }

        static int[] solveArrayTask(int[] array, int k)
        {
            Array.Reverse(array);

            Array.Reverse(array, 0, k);

            Array.Reverse(array, k, array.Length-k);
            return array;
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
        /// <summary>
        /// находит четные числа
        /// </summary>
        /// <param name="array"></param>
        static void findOddNumbersInArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]%2==0)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
        /// <summary>
        /// находит не четные числа
        /// </summary>
        /// <param name="array"></param>
        static void findNotOddNumbersInArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]%2!=0)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
    }
}