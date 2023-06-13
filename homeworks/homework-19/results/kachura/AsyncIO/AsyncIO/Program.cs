using System.Diagnostics;

class Program
{
    private static async Task Main()
    {
        var content = CreateFileContent();
        var tasks = new List<Task>(100);
        var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;


        for (int i = 0; i < 10; i++)
        {
            tasks.Add(WriteFileAsync(Path.Combine(path, $"file-{i}.txt"), content));
        }

        await Task.WhenAll(tasks);
    }

    private static async Task WriteFileAsync(string path, string content)
    {
        // TODO: Записать данные в файл
        using (var outputFile = new StreamWriter(path))
        {
            Console.WriteLine("Writing");
            await outputFile.WriteAsync(content); //если эта строка закомменчена, то количество потоков, используемых приложением - 11. Можно взять это количество как дефолтное
            //при записи одного файла используется 20-21 потоков, то есть 10-11 для записи. В дебаггере потоков такое же количество - 10
            //при записи пяти файлов используется  27 потоков, то есть 17 потоков. В дебаггере потоков количество - 17
            //при записи десяти файлов используется  29 потоков, то есть 19 потоков. В дебаггере потоков количество - 19

            Process process = Process.GetCurrentProcess();
            ProcessThreadCollection threads = process.Threads;

            Console.Write("Thread IDs:");
            foreach(ProcessThread thread in threads)
            {
                Console.Write($" {thread.Id}");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Writing completed");
    }

    private static string CreateFileContent()
    {
        var size = 512;// * 1024 * 1024;

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