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

            //2)
            //      Найдите четные (нечетные) элементы массива
            //         Пример:
            //         Исходный массив: nums = [1,2,3,4]
            //         Результат выполнения: [2,4]

            //инициализация массива
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //вывод массива
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine("enter what do you want to find:\n" +
                "1)Odd numbers\n" +
                "2)Not odd numbers");
            string chooseMessage = Console.ReadLine();
            //вызов метода,который находит четные числа.
            if (chooseMessage =="1")
                findOddNumbersInArray(array);
            //вызов метода,который находит не четные числа.
            if (chooseMessage =="2")
                findNotOddNumbersInArray(array);





        

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