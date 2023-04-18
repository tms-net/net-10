internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Array taksks");

        int[] myArray = new int[] { 4, 22, 37, 9, 13, 40, 51 };

        int[] result = SolveArrayTask(myArray);
        PrintArray(result);
        Console.WriteLine();
        Sort(myArray);
        Console.WriteLine("\nНайти бегущую сумму массива");
        RunSum(myArray);

        static int[] SolveArrayTask(int[] nums) //Измените порядок массива на противоположный
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

        void PrintArray(int[] Array) //Вывод массива
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write(Array[i] + " ");
            }
        }

        void Sort(int[] Array) //Сортировка массива (Найдите четные (нечетные) элементы массива)
        {
            int j = 0;
            int a = 0;
            int[] EventArray = new int[Array.Length];// Четный массив
            int[] OddArray = new int[Array.Length]; // Нечетный массив
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] % 2 == 0)
                {
                    EventArray[j] = Array[i];
                    j++;
                }    
            }
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] % 2 != 0)
                {
                    OddArray[a] = Array[i];
                    a++;
                }
            }

            Console.WriteLine("Четныйе числа массива:");
            PrintArray(EventArray);
            Console.WriteLine();
            Console.WriteLine("Нечетные числа массива:");
            PrintArray(OddArray);

        }
        void RunSum(int[] Array)//Найти бегущую сумму массива
        {
            int[] NewArray = new int[Array.Length];
            
            for (int i = 0; i < Array.Length; i++)
            {
                int Sum = 0;
                for (int j = 0; j <= i; j++)
                {
                    Sum+= Array[j];
                }
                NewArray[i] = Sum;

            }
            PrintArray(NewArray);
        }
        
        
        Console.ReadLine();
    }
}