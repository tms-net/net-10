// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using Async.Wpf;

class Program
{
    private static int counter;
    private const int OperationDuration = 2000;

    private static int MaxThreads
    {
        get
        {
            ThreadPool.GetMaxThreads(out var workerThreads, out _);
            return workerThreads;
        }
    }
    private static int AvailableThreads
    {
        get
        {
            ThreadPool.GetAvailableThreads(out var workerThreads, out _);
            return workerThreads;
        }
    }

    [STAThread]
    public static void Main()
    {
        ThreadPool.SetMaxThreads(10, 10);
        Console.WriteLine($"Starting with thread capacity {MaxThreads}");
        var timer = new Timer(TimerTick);

        Console.WriteLine("Performing operation...");
        var sw = new Stopwatch();
        sw.Start();
        DoOperationAsync().Wait();
        sw.Stop();
        Console.WriteLine($"Single operation completes in {sw.ElapsedMilliseconds} ms.");

        timer.Change(0, 1000);
        Thread.Sleep(10000);
        Console.WriteLine($"Operations completed: {counter}");

        //RunApp();
    }

    private static void TimerTick(object state)
    {
        for (int i = 0; i < 100; i++)
        {
            DoOperationAsync();
        }
        Console.WriteLine($"Added another 100 operations. Threads available {AvailableThreads}");
    }

    private static async Task DoOperationAsync()
    {
        await Task.Yield();
        //Thread.Sleep(OperationDuration);
        await Task.Delay(OperationDuration);

        Interlocked.Increment(ref counter);
    }

    static void RunApp()
    {
        // run windowed
        App app = new App();
        app.MainWindow = new MainWindow();
        app.MainWindow.Show();
        app.Run();
    }
}