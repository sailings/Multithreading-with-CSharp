using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace _2.Thread_Synchronization
{
    class Program
    {
        #region 2.1.基本原子操作
        //private static void Main(string[] args)
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
        //    var c1 = new CounterNoLock();
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
        //    private int _count;
        //    public int Count => _count;
        //    public override void Increment()
        //    {
        //        _count++;
        //    }
        //    public override void Decrement()
        //    {
        //        _count--;
        //    }
        //}

        //class CounterNoLock : CounterBase
        //{
        //    private int _count;
        //    public int Count => _count;
        //    public override void Increment()
        //    {
        //        Interlocked.Increment(ref _count);
        //    }
        //    public override void Decrement()
        //    {
        //        Interlocked.Decrement(ref _count);
        //    }
        //}
        //abstract class CounterBase
        //{
        //    public abstract void Increment();

        //    public abstract void Decrement();
        //}
        #endregion

        #region 2.2.互斥
        //static void Main(string[] args)
        //{
        //    const string MutexName = "MyApp";
        //    using (var m = new Mutex(false, MutexName))
        //    {
        //        if (!m.WaitOne(TimeSpan.FromSeconds(5), false))
        //        {
        //            WriteLine("Second instance is running!");
        //        }
        //        else
        //        {
        //            WriteLine("Running!");
        //            ReadLine();
        //            m.ReleaseMutex();
        //        }
        //    }
        //}
        #endregion

        #region 2.3.信号量

        //static SemaphoreSlim _semaphore = new SemaphoreSlim(4);
        //static void Main(string[] args)
        //{
        //    for (int i = 1; i <= 6; i++)
        //    {
        //        string threadName = "Thread " + i;
        //        int secondsToWait = 2 + 2 * i;
        //        var t = new Thread(() => AccessDatabase(threadName, secondsToWait));
        //        t.Start();
        //    }
        //}
        //static void AccessDatabase(string name, int seconds)
        //{
        //    WriteLine($"{name} waits to access a database");
        //    _semaphore.Wait();
        //    WriteLine($"{name} was granted an access to a database");
        //    Sleep(TimeSpan.FromSeconds(seconds));
        //    WriteLine($"{name} is completed");
        //    _semaphore.Release();
        //}

        #endregion

        #region 2.4.AutoResetEvent

        //private static AutoResetEvent carEvent = new AutoResetEvent(false);
        ////private static ManualResetEvent carEvent = new ManualResetEvent(false);

        //static void Main()
        //{
        //    new Thread(Car1Access).Start();
        //    new Thread(Car2Access).Start();

        //    Thread.Sleep(2000);
        //    Console.WriteLine("Open Gate...");
        //    carEvent.Set();

        //    Thread.Sleep(1000);
        //    Console.WriteLine("Close Gate...");
        //    carEvent.Reset();
        //}

        //static void Car1Access()
        //{
        //    Console.WriteLine("Car1 Waiting");
        //    carEvent.WaitOne();
        //    Console.WriteLine("Car1 Access");
        //}

        //static void Car2Access()
        //{
        //    Thread.Sleep(4000);

        //    Console.WriteLine("Car2 Waiting");
        //    carEvent.WaitOne();
        //    Console.WriteLine("Car2 Access");
        //}

        #endregion

        #region 2.5.CountDownEvent
        //static CountdownEvent _countdown = new CountdownEvent(2);
        //static void Main(string[] args)
        //{
        //    WriteLine("Starting two operations");
        //    var t1 = new Thread(() => PerformOperation("Operation 1 is completed", 4));
        //    var t2 = new Thread(() => PerformOperation("Operation 2 is completed", 8));
        //    t1.Start();
        //    t2.Start();
        //    _countdown.Wait();
        //    WriteLine("Both operations have been completed.");
        //    _countdown.Dispose();
        //}
        //static void PerformOperation(string message, int seconds)
        //{
        //    Sleep(TimeSpan.FromSeconds(seconds));
        //    WriteLine(message);
        //    _countdown.Signal();
        //}
        #endregion

        #region 2.6.Barrier

        //static Barrier barrier = new Barrier(2, b => WriteLine($"song {b.CurrentPhaseNumber} finished"));
        //static void Main(string[] args)
        //{
        //    var t1 = new Thread(() => PlayMusic("the guitarist", "play an amazing solo", 1));
        //    var t2 = new Thread(() => PlayMusic("the singer", "sing his song", 5));

        //    t1.Start();
        //    t2.Start();
        //}

        //static void PlayMusic(string name, string message, int seconds)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(seconds));
        //        //WriteLine($"{name} starts to {message}");
        //        //Sleep(TimeSpan.FromSeconds(seconds));

        //        WriteLine($"{name} finishes to {message},at song{i}");
        //        WriteLine($"{name} are waiting " + barrier.ParticipantsRemaining + " tasks");
        //        barrier.SignalAndWait();
        //    }
        //}
        #endregion

        #region 2.7.ReaderWriterLockSlim
        //static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
        //static Dictionary<int, int> _items = new Dictionary<int, int>();

        //static void Main(string[] args)
        //{
        //    new Thread(Read) { IsBackground = true }.Start();
        //    new Thread(Read) { IsBackground = true }.Start();
        //    new Thread(Read) { IsBackground = true }.Start();

        //    new Thread(() => Write("Thread 1")) { IsBackground = true }.Start();
        //    new Thread(() => Write("Thread 2")) { IsBackground = true }.Start();

        //    Sleep(TimeSpan.FromSeconds(30));
        //}
        //static void Read()
        //{
        //    WriteLine("Reading contents of a dictionary");
        //    while (true)
        //    {
        //        try
        //        {
        //            _rw.EnterReadLock();
        //            foreach (var key in _items.Keys)
        //            {
        //                Sleep(TimeSpan.FromSeconds(0.1));
        //            }
        //        }
        //        finally
        //        {
        //            _rw.ExitReadLock();
        //        }
        //    }
        //}

        //static void Write(string threadName)
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            int newKey = new Random().Next(250);
        //            _rw.EnterUpgradeableReadLock();
        //            if (!_items.ContainsKey(newKey))
        //            {
        //                try
        //                {
        //                    _rw.EnterWriteLock();
        //                    _items[newKey] = 1;
        //                    WriteLine($"New key {newKey} is added to a dictionary by a {threadName}");
        //                }
        //                finally
        //                {
        //                    _rw.ExitWriteLock();
        //                }
        //            }
        //            Sleep(TimeSpan.FromSeconds(0.1));
        //        }
        //        finally
        //        {
        //            _rw.ExitUpgradeableReadLock();
        //        }
        //    }
        //}
        #endregion
    }
}
