using System.IO;
using System.Net.Sockets;

class Program
{
    static readonly object locker = new object();
    //static int count;
    //static List<string> threadsList = new List<string>();
    private static async Task Main()
    {
        
        var content = CreateFileContent();
        var tasks = new List<Task>(100);
        var threadsDictionary = new Dictionary<int, string>();
        //var threadsList = new List<string>();

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(WriteFile($"file-{i}.txt", content, threadsDictionary));
        }
        
        AddNewThreadId(Thread.CurrentThread.ManagedThreadId, threadsDictionary);

        await Task.WhenAll(tasks);

        AddNewThreadId(Thread.CurrentThread.ManagedThreadId, threadsDictionary);
        Console.WriteLine($"For writing has used {threadsDictionary.Count} threads ({String.Join(",", threadsDictionary.Values)})");            
    }

    private static async Task WriteFile(string path, string content, Dictionary<int, string> threadsDictionary)
    {
        AddNewThreadId(Thread.CurrentThread.ManagedThreadId, threadsDictionary);
        
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), path)))
        {
            await outputFile.WriteAsync(content);
        }

        AddNewThreadId(Thread.CurrentThread.ManagedThreadId, threadsDictionary);
            
        Console.WriteLine($"At moment of writing {path} has used {threadsDictionary.Count} threads ({String.Join(",", threadsDictionary.Values)})");
        // TODO: Записать данные в файл
    }

    private static string CreateFileContent()
    {
        var size = 512 * 1024 * 1024;

        using var ms = new MemoryStream();
        ms.SetLength(size);
        ms.Seek(size, SeekOrigin.Begin);
        ms.WriteByte(0);
        ms.Position = 0;

        var buffer = new byte[size];

        ms.Read(buffer, 0, size);

        return System.Text.Encoding.UTF8.GetString(buffer);
    }

    private static void AddNewThreadId(int id, Dictionary<int, string> threadsDictionary)
    {
        lock (locker)
        {
            threadsDictionary.TryAdd(id, id.ToString());
        }        
    }

    

}