// See https://aka.ms/new-console-template for more information
using Homework_4;
using System;
using System.Linq;
using Zookeeper;

class Program
{
    public void Main()
    {
        Console.WriteLine("Array taksks");

        int[] myArray = new int[] { 4, 22, 37, 9, 13, 40, 51 };

        int[] result = SolveArrayTask(myArray);
    }
    // 
    int[] SolveArrayTask2(int[] nums, int k)
    {
        for (int i = 0; i < k; i++)
        {
            int[] otherArray = new int[nums.Length];

            int lastItem = nums[^1];

            var twoFirst = nums[0..1];

            var myArray = new MyArray();

            var myInterface = new ICanReverse();

            ArrayExtensions.ReverseToArray(myArray);

            nums.Reverse();

            var reversed = nums.ReverseArray();

            lastItem = nums[nums.Length - 1];


            Array.Copy(nums, 0, otherArray, 1, otherArray.Length - 1);
            otherArray[0] = lastItem;
            nums = otherArray;
            var output = string.Join(" ", nums);
            Console.WriteLine(output);
        }
        return nums;
    }

    // Even numbers
    int[] SolveArrayTask(int[] nums)
    {
        var length = nums.Length;
        //var obj = new MyClass();
        //var prop = obj.MyProperty;
        //var prop2 = obj.MyProperty2;

        int[] tmp = new int[nums.Length];
        var index = 0;

        // tmp -> [0]

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
            {
                // 1: tmp -> [1]
                // 2: tmp -> [2]
                // tmp[tmp.Length] = nums[i];

                // 1: (4)
                // 2: (4) -> (22)

                // Stack
                // List

                tmp[index++] = nums[i];
                // index = index + 1;
            }
        }

        //var result = new int[index];

        //Array.Copy(tmp, result, index);

        return tmp[..index];

        // return [^0..]
    }

    void Run()
    {
        var cat = new Cat();
        cat.Jump();

        var turtle = new Turtle();
        //var dog = new Dog();
        //dog

        Cat cat =  new Cat();

        IAnimal vegan = cat;

        Animal anml = cat;

        //IAnimal animal = Zoo.GetAnimal();

        Console.WriteLine($"Animal speaks: {animal.Speak()}");
    }
}

internal class Turtle : Animal
{
    protected override int Move()
    {
        return base.Move();
    }
}

class MyClass : ICanReverse
{
    string MyProperty2;
    //string _myProp;

    public string MyProperty { get; set; }
    //{
    //    get {
    //        return _myProp;
    //    }
    //    set // setValue(string value)
    //    { 
    //        _myProp = value;
    //    }
    //}
    public void Reverse()
    {
        throw new NotImplementedException();
    }
}

struct MyStruct : ICanReverse
{
    public void Reverse()
    {
        throw new NotImplementedException();
    }
}

interface ICanReverse
{
    void Reverse();
}

