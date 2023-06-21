// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Tasks == ThreadPool

var task1 = Task.Run(VoidMethod);

var task2 = Task.Run(BoolMethod);

var task3 = Task.Run(ExceptionMethod);

//Console.WriteLine(task2.Result);

Console.WriteLine(task1.Status);

//task3.Wait();

Console.WriteLine(task3.Exception);

//Task.WaitAll(task1, task2, task3);

Task.WaitAny(task1, task2, task3);

var allTask = Task.WhenAll(task1, task2, task3);
// 1 ->
// 2 -> 3
// 3 ->

// 1 -> 2 -> 3 -> 4

// TheadPool.Queue()

var anyTask = Task.WhenAny(task1, task2, task3);

// TPL -> Task Parallel Library

var task4 = task1.ContinueWith((t, _) => BoolMethod(), TaskContinuationOptions.OnlyOnFaulted, CancellationToken.None);

task4.Wait(1000);

// Многопоточность

// Параллелизм (обработать файл параллельно) -> CPU-Bound operations

// row1
// row2
// ....
// row 10

// получение общего результата

// Асинхронность
// Блокировки
//  - каждая задача выполняется эфективно
//    - считать и обработать файл
//      - считать файл - I/O Bound Operation
//      - обработать - CPU-Bound

void ReadAndProcessFile()
{
    // долгий процесс
    // не использует CPU
    var content = ReadFile();

    ProcessFile(content);
}

task1.ContinueWith(t => ReadFile()).ContinueWith(t => ProcessFile(t.Result));

// async/await

// АСИНХРОННЫЙ МЕТОД ВЫПОЛНЯЕТСЯ НА РАЗНЫХ ПОТОКАХ (!!!)


await ReadAndProcessFileAsync(); // НЕЛЬЗЯ

async void ReadAndProcessFileAsync()
{
    await task1;

    var content = await ReadFile(); // Task -> IAWaitable (IEnumerable)

    await ProcessFile(content);
}

async Task<string> ReadFile()
{
    var filePath = Configuration.GetFilePath();

    var reader = new StreamReader(filePath);
    await reader.ReadToEndAsync();
}

void ProcessFile(string content)
{

}


Console.WriteLine("All completed");

void VoidMethod()
{
    Thread.Sleep(5000);
}

void ExceptionMethod()
{
    throw new NotImplementedException();
}

bool BoolMethod()
{
    return true;
}