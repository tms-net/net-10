//1)
    int[] myArray = new int[] {4, 22, 37, 9, 13, 40, 51};
    Console.WriteLine(string.Join(", ", myArray.Reverse()));
//2)
int[] myArray2 = new int[] { 4, 22, 37, 9, 13, 40, 51 };
int[] finalArray = new int[myArray2.Length];
int j = 0;
for (int i = 0; i < myArray2.Length; i++)
{
    if (myArray2[i] % 2 == 0)
    {
        finalArray[j++] = myArray2[i];
    }
}
Array.Resize(ref finalArray, j);
Console.WriteLine(string.Join(", ", finalArray.Reverse()));

