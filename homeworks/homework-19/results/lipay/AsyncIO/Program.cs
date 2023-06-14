using System.Diagnostics;

class Program
{
    private static async Task Main()
    {
        var timer = new Timer(GetSnapshot);
        timer.Change(0, 100);

        var content = CreateFileContent();
        var tasks = new List<Task>(100);

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(WriteFile($"file-{i}.txt", content));
        }
        await Task.WhenAll(tasks);

        
    }

    private static void GetSnapshot(object? state)
    {
        Process progress = Process.GetCurrentProcess();
        ProcessThreadCollection threads = progress.Threads;
        Console.WriteLine($"Thread: {threads}");
    }

    private static async Task WriteFile(string path, string content)
    {
        // TODO: Записать данные в файл

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