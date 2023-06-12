using System.Collections.Concurrent;
using System.Diagnostics;

class Program
{
    static async Task Main()
    {
        var content = CreateFileContent();
        var tasks = new List<Task>(100);
        var executionTime = new Stopwatch();
        ThreadPool.SetMinThreads(4, 4);
        ThreadPool.SetMaxThreads(4, 4);

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(WriteFile($"file-{i}.txt", content));
        }

        executionTime.Start();
        await Task.WhenAll(tasks);
        executionTime.Stop();

        Console.WriteLine($"Общее время выполнения задач: {executionTime.Elapsed.TotalSeconds} сек");

        /*
              (write)    1 file               10 files
            1 thread    13.25 s             106.58 s
            2 thread    13.74 s             98.56 s
            4 thread    14.13 s             96.12 s
            8 thread    14.70 s             104.10 s
            10 thread   15.13 s             104.73 s
            16 thread   15.47 s             122.93 s
         ThreadPool(auto) 6 thr(1 write)    20 thr(10 write)
        */
    }



    private static async Task WriteFile(string path, string content)
    {
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(path)))
        {
            await outputFile.WriteAsync(content);
        }
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

}