class Program
{
    private static async Task Main()
    {
        var content = CreateFileContent();
        var tasks = new List<Task>(100);

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(WriteFile($"file-{i}.txt", content));
        }

        await Task.WhenAll(tasks);

        int maxThreads, ioThreads;
        ThreadPool.GetMaxThreads(out maxThreads, out ioThreads);
        Console.WriteLine($"Maximum number of threads: {maxThreads}");
        Console.WriteLine($"Maximum number of I/O threads: {ioThreads}");
    }

    private static async Task WriteFile(string path, string content)
    {
        using (var writer = new StreamWriter(path))
        {
            await writer.WriteAsync(content);
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
