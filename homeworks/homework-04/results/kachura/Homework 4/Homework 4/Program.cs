//Task 1
int[] array = { 1, 2, 3, 4, 5, 6 };

Console.WriteLine("Task 1.\nReversed Array is: ");
foreach(int num in Array.Reverse(array))
{
    Console.Write($"{num} ");
}


//Task 2
int[] array2 = { 1, 2, 3, 4, 5, 6, -3, 11, 109 };

Console.WriteLine("\n\nTask 2.\nEven nubmers are: ");
foreach(int num in Array.FindEvenNumbers(array2))
{
    Console.Write($"{num} ");
}

Console.WriteLine("\nOdd numbers are: ");
foreach (int num in Array.FindOddNumbers(array2))
{
    Console.Write($"{num} ");
}


//Task 3
int[] array3 = { 1, 2, 3, 3, 4};

Console.WriteLine("\n\nTask 3.\nRunning sum array is: ");
foreach(int num in Array.RunningSum(array3))
{
    Console.Write($"{num} ");
}


//Tesk 4
int[] array4 = { 1, 2, 3, 4, 5, 6, 7 };
int k = 3;

Console.WriteLine("\n\nTask 4.\nMoved array is: ");
foreach (int num in Array.MoveNumbersInArray(array4, k))
{
    Console.Write($"{num} ");
}



public static class Array
{
    //changes order of array members to the reversed one
    public static int[] Reverse(int[] origArray)
    {
        if(origArray.Count() > 1)
        {
            int[] reversedArray = origArray;
            int temp;

            for(int i = 0; i < origArray.Count() / 2; i++)
            {
                temp = origArray[origArray.Count() - 1 - i];
                reversedArray[origArray.Count() - 1 - i] = origArray[i];
                reversedArray[i] = temp;
            }

            return reversedArray;
        }

        return origArray;
    }

    //find even numbers in an array
    public static int[] FindEvenNumbers(int[] origArray)
    {
        int[] temp = new int[origArray.Count()];
        int numberOfEvenNumbs = 0;

        for (int i = 0; i < origArray.Count(); i++)
        {
            if (origArray[i] % 2 == 0)
            {
                temp[numberOfEvenNumbs] = origArray[i];
                numberOfEvenNumbs++;
            }
        }

        int[] resultArray = new int[numberOfEvenNumbs];
        for(int i = 0; i < numberOfEvenNumbs; i++)
        {
            resultArray[i] = temp[i];
        }

        return resultArray;
    }

    //find odd numbers in an array
    public static int[] FindOddNumbers(int[] origArray)
    {
        int[] temp = new int[origArray.Count()];
        int numberOfOddNumbs = 0;

        for (int i = 0; i < origArray.Count(); i++)
        {
            if (origArray[i] % 2 != 0)
            {
                temp[numberOfOddNumbs] = origArray[i];
                numberOfOddNumbs++;
            }
        }

        int[] resultArray = new int[numberOfOddNumbs];
        for (int i = 0; i < numberOfOddNumbs; i++)
        {
            resultArray[i] = temp[i];
        }

        return resultArray;
    }

    //running sum of array
    public static int[] RunningSum(int[] origArray)
    {
        int[] runningSumArray = new int[origArray.Count()];

        for(int i = 0; i < origArray.Count(); i++)
        {
            if(i == 0)
            {
                runningSumArray[i] = origArray[i];
            }
            else
            {
                runningSumArray[i] = runningSumArray[i - 1] + origArray[i];
            }    
        }

        return runningSumArray;
    }

    public static int[] MoveNumbersInArray(int[] origArray, int k)
    {
        for(int j = 0; j < k; j++)
        {
            int temp = 0;
            int temp2 = 0;
            int lastNum = origArray[origArray.Count() - 1];
            for(int i = 0; i < origArray.Count() - 1; i++)
            {
                if(i == 0)
                {
                    temp = origArray[i + 1];
                    origArray[i + 1] = origArray[i];
                }
                else
                {
                    temp2 = origArray[i + 1];
                    origArray[i + 1] = temp;
                    temp = temp2;
                }
            }

            origArray[0] = lastNum;
        }

        return origArray;
    }
}