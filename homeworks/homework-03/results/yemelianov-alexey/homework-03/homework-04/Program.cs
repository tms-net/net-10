namespace homework_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sourceArray = GetRandomArray(GetRandomInt(5, 10));
            Console.WriteLine($"Source array: ");
            Console.WriteLine("[{0}]", string.Join(", ", sourceArray));
            Console.WriteLine($"Reversed array: ");
            Console.WriteLine("[{0}]", string.Join(", ", ReverseArray(sourceArray)));
            Console.WriteLine($"Array of even numbers: ");
            Console.WriteLine("[{0}]", string.Join(", ", GetArrayEvenNumbers(sourceArray)));
            Console.WriteLine($"Array of running sum: ");
            Console.WriteLine("[{0}]", string.Join(", ", GetArrayOfRunningSum(sourceArray)));
            var shiftValue = GetRandomInt(1, 4);
            Console.WriteLine($"Array, shifted to the right by {shiftValue} positions: ");
            Console.WriteLine("[{0}]", string.Join(", ", ShiftArray(sourceArray, shiftValue)));
        }

        static int[] GetRandomArray(int length)
        {
            var newArray = new int[length];

            foreach (var i in Enumerable.Range(0, length)) // Range is here just for the lulz
            {
                newArray[i] = GetRandomInt(-100, 100);
            }

            return newArray;
        }

        static int GetRandomInt(int minValue = int.MinValue, int maxValue = int.MaxValue) => new Random().Next(minValue, maxValue);

        static int[] ReverseArray(int[] sourceArray) => sourceArray.Reverse().ToArray(); // Why not? The easiest way is the best way

        static int[] GetArrayEvenNumbers(int[] sourceArray) => Array.FindAll(sourceArray, arrayElement => arrayElement % 2 == 0);

        static int[] GetArrayOfRunningSum(int[] sourceArray)
        {
            var newArray = new int[sourceArray.Length];
            Array.Copy(sourceArray, newArray, sourceArray.Length);

            for (int arrayElementIndex = 1; arrayElementIndex < newArray.Length; arrayElementIndex++)
            {
                newArray[arrayElementIndex] += newArray[arrayElementIndex - 1];
            }

            return newArray;
        }

        static int[] ShiftArray(int[] sourceArray, int shiftValue)
        {
            var shiftedArray = new int[sourceArray.Length];
            Array.Copy(sourceArray, sourceArray.Length - shiftValue, shiftedArray, 0, shiftValue);
            Array.Copy(sourceArray, 0, shiftedArray, shiftValue, sourceArray.Length - shiftValue);

            return shiftedArray;
        }
    }
}