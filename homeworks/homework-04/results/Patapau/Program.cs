// See https://aka.ms/new-console-template for more information
Console.WriteLine("Array taksks");

//Ввод массива
uint arraySize;
uint step;
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
if (arraySize > 0)
{
    //Исходный массив
    Console.WriteLine("\nSource array:");
    DataOutput(myArray);

    Console.WriteLine("\nArrayReverse");
    DataOutput(ArrayReverse(myArray));

    Console.WriteLine("\nOddNumbers");
    DataOutput(OddNumbers(myArray));


    Console.WriteLine("\nEvenNumbers");
    DataOutput(EvenNumbers(myArray));

    Console.WriteLine("\nRunArray");
    DataOutput(RunArray(myArray));

    
    Console.WriteLine("\nВведите количество шагов поворота");
    while (!UInt32.TryParse(Console.ReadLine(), out step))
    {
        Console.WriteLine("Ошибка! Повторите попытку количество шагов поворота массива!");
    }

    Console.WriteLine("\nTurnArray");
    DataOutput(TurnArray(myArray));
}
else
{
    Console.WriteLine("Неверная размерность массива");
}
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

int[] RunArray(int[] nums)
{
    int[] temp = new int[nums.Length];
    temp[0] = nums[0];
    for (int i = 1; i < nums.Length; i++)
    {
        temp[i] = nums[i] + temp[i - 1];
    }
    return temp;
}

//---------------------------------task4-------------------------------------------------------////
int[] TurnArray(int[] nums)
{
    int[] temp = new int[nums.Length];
    Array.Copy(nums, temp, nums.Length);
    for (int i = 0; i < nums.Length; i++)
    {
        temp[(i + step) % nums.Length] = nums[i];
    }
    return temp;
}