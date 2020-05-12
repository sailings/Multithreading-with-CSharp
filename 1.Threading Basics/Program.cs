using System;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;
using static System.Diagnostics.Process;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _1.Threading_Basics
{
    class Program
    {
        #region 1.1.线程创建
        static void Main(string[] args)
        {
            Thread t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
            Console.ReadLine();
        }
        static void PrintNumbers()
        {
            WriteLine("Starting...");
            for (int i = 1; i < 10; i++)
            {
                WriteLine(i);
            }
        }
        #endregion

        #region 1.2.线程睡眠
        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(PrintNumbersWithDelay);
        //    t.Start();
        //    PrintNumbersWithDelay();
        //}
        //static void PrintNumbersWithDelay()
        //{
        //    WriteLine("Starting...");
        //    for (int i = 1; i < 10; i++)
        //    {
        //        WriteLine(i);
        //        Thread.Sleep(2000);
        //    }
        //}
        #endregion

        #region 1.3.线程等待
        //static void Main(string[] args)
        //{
        //    WriteLine("Starting program...");
        //    Thread t = new Thread(PrintNumbersWithDelay);
        //    t.Start();
        //    t.Join();
        //    WriteLine("Main Thread completed");
        //}
        //static void PrintNumbersWithDelay()
        //{
        //    WriteLine("Starting...");
        //    for (int i = 1; i < 10; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(1));
        //        WriteLine(i);
        //    }
        //}
        #endregion

        #region 1.4.线程终止
        //static void Main(string[] args)
        //{
        //    WriteLine("Starting program...");
        //    Thread t = new Thread(PrintNumbersWithDelay);
        //    t.Start();
        //    Sleep(TimeSpan.FromSeconds(6));
        //    t.Abort();
        //    WriteLine("A thread has been aborted");
        //}
        //static void PrintNumbersWithDelay()
        //{
        //    WriteLine("Starting...");
        //    for (int i = 1; i < 10; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(1));
        //        WriteLine(i);
        //    }
        //}
        #endregion

        #region 1.5.线程状态
        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(PrintNumbersWithStatus);
        //    Thread t2 = new Thread(DoNothing);
        //    t.Start();
        //    t2.Start();

        //    //t.Join();
        //    //t2.Join();

        //    Sleep(TimeSpan.FromSeconds(6));
        //    t.Abort();

        //}
        //static void DoNothing()
        //{
        //    Thread.CurrentThread.Priority
        //    Sleep(TimeSpan.FromSeconds(2));
        //}
        //static void PrintNumbersWithStatus()
        //{
        //    for (int i = 1; i < 10; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(2));
        //    }
        //}
        #endregion

        #region 1.6.线程优先级
        //static void Main(string[] args)
        //{
        //    WriteLine($"Current thread priority: {CurrentThread.Priority}");
        //    WriteLine("Running on all cores available");
        //    RunThreads();
        //    Sleep(TimeSpan.FromSeconds(2));
        //    WriteLine("Running on a single core");
        //    GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
        //    RunThreads();
        //}

        //static void RunThreads()
        //{
        //    var sample = new ThreadSample();

        //    var threadOne = new Thread(sample.CountNumbers);
        //    threadOne.Name = "Thread1";
        //    var threadTwo = new Thread(sample.CountNumbers);
        //    threadTwo.Name = "Thread2";

        //    threadOne.Priority = ThreadPriority.Highest;
        //    threadTwo.Priority = ThreadPriority.Lowest;
        //    threadOne.Start();
        //    threadTwo.Start();

        //    Sleep(TimeSpan.FromSeconds(2));
        //    sample.Stop();
        //}
        //class ThreadSample
        //{
        //    private bool _isStopped = false;
        //    public void Stop()
        //    {
        //        _isStopped = true;
        //    }
        //    public void CountNumbers()
        //    {
        //        long counter = 0;
        //        while (!_isStopped)
        //        {
        //            counter++;
        //        }
        //        WriteLine($"{CurrentThread.Name} with " +
        //            $"{CurrentThread.Priority,11} priority " +
        //            $"has a count = {counter,13:N0}");
        //    }
        //}
        #endregion

        #region 1.7.前台和后台线程
        //part1
        //static void Main(string[] args)
        //{
        //    var sampleForeground = new ThreadSample(5);
        //    var sampleBackground = new ThreadSample(10);

        //    var threadOne = new Thread(sampleForeground.CountNumbers);
        //    threadOne.Name = "ForegroundThread";
        //    var threadTwo = new Thread(sampleBackground.CountNumbers);
        //    threadTwo.Name = "BackgroundThread";
        //    threadTwo.IsBackground = true;

        //    threadOne.Start();
        //    threadTwo.Start();
        //}
        //class ThreadSample
        //{
        //    private readonly int _iterations;

        //    public ThreadSample(int iterations)
        //    {
        //        _iterations = iterations;
        //    }
        //    public void CountNumbers()
        //    {
        //        for (int i = 0; i < _iterations; i++)
        //        {
        //            Sleep(TimeSpan.FromSeconds(0.5));
        //            WriteLine($"{CurrentThread.Name} prints {i}");
        //        }
        //    }
        //}

        //part2
        //static void Main(string[] args)
        //{
        //    Form form = new Form();
        //    form.Load += Form_Load;
        //    Application.Run(form);
        //    Console.WriteLine("form closed");
        //}

        //private static void Form_Load(object sender, EventArgs e)
        //{
        //    Thread worker = new Thread(() =>
        //    {
        //        WriteLine("worker started...");
        //        Sleep(100 * 1000);
        //        WriteLine("worker end...");
        //    });
        //    //worker.IsBackground = true;
        //    worker.Start();
        //}

        #endregion

        #region 1.8.线程传参
        //static void Main(string[] args)
        //{
        //    var sample = new ThreadSample(10);

        //    var threadOne = new Thread(sample.CountNumbers);
        //    threadOne.Name = "ThreadOne";
        //    threadOne.Start();
        //    threadOne.Join();
        //    WriteLine("--------------------------");
        //    var threadTwo = new Thread(Count);
        //    threadTwo.Name = "ThreadTwo";
        //    threadTwo.Start(8);
        //    threadTwo.Join();
        //    WriteLine("--------------------------");
        //    var threadThree = new Thread(() => CountNumbers(12));
        //    threadThree.Name = "ThreadThree";
        //    threadThree.Start();
        //    threadThree.Join();
        //    WriteLine("--------------------------");

        //    int i = 10;
        //    var threadFour = new Thread(() => PrintNumber(i));
        //    i = 20;
        //    var threadFive = new Thread(() => PrintNumber(i));
        //    threadFour.Start();
        //    threadFive.Start();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        new Thread(() => Console.WriteLine(i)).Start();
        //    }

        //    Console.ReadLine();
        //}

        //static void Count(object iterations)
        //{
        //    CountNumbers((int)iterations);
        //}
        //static void CountNumbers(int iterations)
        //{
        //    for (int i = 1; i <= iterations; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(0.5));
        //        WriteLine($"{CurrentThread.Name} prints {i}");
        //    }
        //}
        //static void PrintNumber(int number)
        //{
        //    WriteLine(number);
        //}
        //class ThreadSample
        //{
        //    private readonly int _iterations;

        //    public ThreadSample(int iterations)
        //    {
        //        _iterations = iterations;
        //    }
        //    public void CountNumbers()
        //    {
        //        for (int i = 1; i <= _iterations; i++)
        //        {
        //            Sleep(TimeSpan.FromSeconds(0.5));
        //            WriteLine($"{CurrentThread.Name} prints {i}");
        //        }
        //    }
        //}
        #endregion

        #region 1.9.Lock锁
        //static void Main(string[] args)
        //{
        //    WriteLine("Incorrect counter");

        //    var c = new Counter();

        //    var t1 = new Thread(() => TestCounter(c));
        //    var t2 = new Thread(() => TestCounter(c));
        //    var t3 = new Thread(() => TestCounter(c));
        //    t1.Start();
        //    t2.Start();
        //    t3.Start();
        //    t1.Join();
        //    t2.Join();
        //    t3.Join();

        //    WriteLine($"Total count: {c.Count}");
        //    WriteLine("--------------------------");

        //    WriteLine("Correct counter");

        //    var c1 = new CounterWithLock();

        //    t1 = new Thread(() => TestCounter(c1));
        //    t2 = new Thread(() => TestCounter(c1));
        //    t3 = new Thread(() => TestCounter(c1));
        //    t1.Start();
        //    t2.Start();
        //    t3.Start();
        //    t1.Join();
        //    t2.Join();
        //    t3.Join();
        //    WriteLine($"Total count: {c1.Count}");
        //}
        //static void TestCounter(CounterBase c)
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        c.Increment();
        //        c.Decrement();
        //    }
        //}
        //class Counter : CounterBase
        //{
        //    public int Count { get; private set; }

        //    public override void Increment()
        //    {
        //        Count++;
        //    }

        //    public override void Decrement()
        //    {
        //        Count--;
        //    }
        //}

        //class CounterWithLock : CounterBase
        //{
        //    private readonly object _syncRoot = new object();
        //    public int Count { get; private set; }
        //    public override void Increment()
        //    {
        //        lock (_syncRoot)
        //        {
        //            Count++;
        //        }
        //    }
        //    public override void Decrement()
        //    {
        //        lock (_syncRoot)
        //        {
        //            Count--;
        //        }
        //    }
        //}
        //abstract class CounterBase
        //{
        //    public abstract void Increment();
        //    public abstract void Decrement();
        //}
        #endregion

        #region 1.10.Monitor锁
        //static void Main(string[] args)
        //{
        //    object lock1 = new object();
        //    object lock2 = new object();
        //    new Thread(() => LockTooMuch(lock1, lock2)).Start();
        //    lock (lock2)
        //    {
        //        Sleep(1000);
        //        WriteLine("Monitor.TryEnter allows not to get stuck, returning false after a specified timeout is elapsed");
        //        if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))
        //        {
        //            WriteLine("Acquired a protected resource succesfully");
        //        }
        //        else
        //        {
        //            WriteLine("Timeout acquiring a resource!");
        //        }
        //    }

        //    //new Thread(() => LockTooMuch(lock1, lock2)).Start();
        //    //lock (lock2)
        //    //{
        //    //    WriteLine("This will be a deadlock!");
        //    //    Sleep(1000);
        //    //    lock (lock1)
        //    //    {
        //    //        WriteLine("Acquired a protected resource succesfully");
        //    //    }
        //    //}
        //}
        //static void LockTooMuch(object lock1, object lock2)
        //{
        //    lock (lock1)
        //    {
        //        Sleep(1000);
        //        lock (lock2)
        //        {

        //        }
        //    }
        //}
        #endregion

        #region 1.11.处理异常
        //static void Main(string[] args)
        //{
        //    var t = new Thread(FaultyThread);
        //    t.Start();
        //    t.Join();
        //    try
        //    {
        //        t = new Thread(BadFaultyThread);
        //        t.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLine("We won't get here!");
        //    }
        //}
        //static void BadFaultyThread()
        //{
        //    WriteLine("Starting a faulty thread...");
        //    Sleep(TimeSpan.FromSeconds(2));
        //    throw new Exception("Boom!");
        //}
        //static void FaultyThread()
        //{
        //    try
        //    {
        //        WriteLine("Starting a faulty thread...");
        //        Sleep(TimeSpan.FromSeconds(1));
        //        throw new Exception("Boom!");
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLine($"Exception handled: {ex.Message}");
        //    }
        //}
        #endregion

        #region 1.12.自旋锁

        //private static long _count = 10000;
        //private static int _timeout_ms = 0;

        //static void Main(string[] args)
        //{
        //    NoSleep();  
        //    ThreadSleepInThread();
        //    SpinWaitInThread();
        //    Console.ReadLine();
        //}

        //private static void NoSleep()
        //{
        //    Thread thread = new Thread(() =>
        //    {
        //        var sw = Stopwatch.StartNew();
        //        for (long i = 0; i < _count; i++)
        //        {

        //        }
        //        Console.WriteLine("No Sleep Consume Time:{0}", sw.Elapsed.ToString());
        //    });
        //    thread.IsBackground = true;
        //    thread.Start();
        //}

        //private static void ThreadSleepInThread()
        //{
        //    Thread thread = new Thread(() =>
        //    {
        //        var sw = Stopwatch.StartNew();
        //        for (long i = 0; i < _count; i++)
        //        {
        //            Thread.Sleep(_timeout_ms);
        //        }
        //        Console.WriteLine("Thread Sleep Consume Time:{0}", sw.Elapsed.ToString());
        //    });
        //    thread.IsBackground = true;
        //    thread.Start();
        //}

        //private static void SpinWaitInThread()
        //{
        //    Thread thread = new Thread(() =>
        //    {
        //        var sw = Stopwatch.StartNew();
        //        for (long i = 0; i < _count; i++)
        //        {
        //           System.Threading.SpinWait.SpinUntil(() => true, _timeout_ms);
        //        }
        //        Console.WriteLine("SpinWait Consume Time:{0}", sw.Elapsed.ToString());
        //    });
        //    thread.IsBackground = true;
        //    thread.Start();
        //}

        #endregion
    }
}