// See https://aka.ms/new-console-template for more information
Console.WriteLine("Array taksks");

//Ввод массива
uint arraySize;
Console.WriteLine("Введите размерность массива:");

while (!UInt32.TryParse(Console.ReadLine(), out arraySize))
{
    Console.WriteLine("Введен неверный формат данных! Повторите попытку ввода размерности массива!");
}

int[] myArray = new int[arraySize];

for (int n = 0; n < myArray.Length; n++)
{
    Console.WriteLine($"Введите элемента {n + 1} массива:");

    while (!Int32.TryParse(Console.ReadLine(), out myArray[n]))
    {
        Console.WriteLine("Введен неверный формат данных! Повторите попытку ввод элемента массива!");
    }
}
//Исходный массив
Console.WriteLine("\nSource array:");
DataOutput(myArray);

Console.WriteLine("\nArrayReverse");
DataOutput(ArrayReverse(myArray));

Console.WriteLine("\nOddNumbers");
DataOutput(OddNumbers(myArray));


Console.WriteLine("\nEvenNumbers");
DataOutput(EvenNumbers(myArray));




//Вывод массивов в консоль
void DataOutput(int[] arr)
{
    foreach (int i in arr)
        Console.Write(i + " ");
}


//---------------------task1-----------------------------------------------//

int[] ArrayReverse(int[] nums)
{
    int[] temp = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        temp[i] = nums[nums.Length - 1 - i];
    }
    return temp;
}

//--------------------task2---------------------------------------------------//

int[] OddNumbers(int[] nums)
{
    int oddNum = 0;
    int[] temp = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] % 2 != 0)
        {
            temp[oddNum++] = nums[i];
        }
    }
    Array.Resize(ref temp, oddNum);
    return temp;
}

int[] EvenNumbers(int[] nums)
{
    int EvenNum = 0;
    int[] temp = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        if (nums[i] % 2 == 0)
        {
            temp[EvenNum++] = nums[i];
        }
    }
    Array.Resize(ref temp, EvenNum);
    return temp;
}

//----------------------------------task3-----------------------------------------------------////