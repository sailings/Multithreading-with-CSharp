using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using static System.Console;
using static System.Threading.Thread;

namespace _3.Using_Thread_Pool
{
    class Program
    {
        #region 3.1.线程池上执行代理
        //private delegate string RunOnThreadPool(out int threadId);
        //static void Main(string[] args)
        //{
        //    int threadId = 0;
        //    RunOnThreadPool poolDelegate = Test;
        //    var t = new Thread(() => Test(out threadId));
        //    t.Start();
        //    t.Join();

        //    WriteLine($"Thread id: {threadId}");

        //    IAsyncResult r = poolDelegate.BeginInvoke(out threadId, Callback, "a delegate asynchronous call");
        //    r.AsyncWaitHandle.WaitOne();

        //    string result = poolDelegate.EndInvoke(out threadId, r);

        //    WriteLine($"Thread pool worker thread id: {threadId}");
        //    WriteLine(result);

        //    Sleep(TimeSpan.FromSeconds(2));
        //}
        //private static void Callback(IAsyncResult ar)
        //{
        //    WriteLine("Starting a callback...");
        //    WriteLine($"State passed to a callbak: {ar.AsyncState}");
        //    WriteLine($"Is thread pool thread: {CurrentThread.IsThreadPoolThread}");
        //    WriteLine($"Thread pool worker thread id: {CurrentThread.ManagedThreadId}");
        //}
        //private static string Test(out int threadId)
        //{
        //    WriteLine("Starting...");
        //    WriteLine($"Is thread pool thread: {CurrentThread.IsThreadPoolThread}");
        //    Sleep(TimeSpan.FromSeconds(2));
        //    threadId = CurrentThread.ManagedThreadId;
        //    return $"Thread pool worker thread id : {threadId}";
        //}
        #endregion

        #region 3.2.线程池上提交异步操作

        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        ThreadPool.QueueUserWorkItem(AsyncOperation);
        //        //Thread t = new Thread(() => AsyncOperation(null));
        //        //t.Start();
        //        Sleep(2000);
        //    }
        //    WriteLine("End");
        //    ReadLine();
        //}
        //private static void AsyncOperation(object state)
        //{
        //    WriteLine($"Worker thread id: {CurrentThread.ManagedThreadId}");
        //    Sleep(TimeSpan.FromSeconds(2));
        //}

        #endregion

        #region 3.3.线程池与非线程池比较

        //static void Main(string[] args)
        //{
        //    const int numberOfOperations = 50;
        //    var sw = new Stopwatch();
        //    sw.Start();
        //    UseThreads(numberOfOperations);
        //    sw.Stop();
        //    WriteLine($"Execution time using threads: {sw.ElapsedMilliseconds}");

        //    //sw.Reset();
        //    //sw.Start();
        //    //UseThreadPool(numberOfOperations);
        //    //sw.Stop();
        //    //WriteLine($"Execution time using the thread pool: {sw.ElapsedMilliseconds}");

        //    ReadLine();
        //}
        //static void UseThreads(int numberOfOperations)
        //{
        //    using (var countdown = new CountdownEvent(numberOfOperations))
        //    {
        //        WriteLine("Scheduling work by creating threads");
        //        for (int i = 0; i < numberOfOperations; i++)
        //        {
        //            var thread = new Thread(() =>
        //            {
        //                Write($"{CurrentThread.ManagedThreadId},");
        //                Sleep(TimeSpan.FromSeconds(5));
        //                countdown.Signal();
        //            });
        //            thread.Start();
        //        }
        //        countdown.Wait();
        //        WriteLine();
        //    }
        //}
        //static void UseThreadPool(int numberOfOperations)
        //{
        //    using (var countdown = new CountdownEvent(numberOfOperations))
        //    {
        //        WriteLine("Starting work on a threadpool");
        //        for (int i = 0; i < numberOfOperations; i++)
        //        {
        //            ThreadPool.QueueUserWorkItem(_ =>
        //            {
        //                Write($"{CurrentThread.ManagedThreadId},");
        //                Sleep(TimeSpan.FromSeconds(5));
        //                countdown.Signal();
        //            });
        //        }
        //        countdown.Wait();
        //        WriteLine();
        //    }
        //}
        #endregion

        #region 3.4.取消任务

        static void Main(string[] args)
        {
            using (var cts = new CancellationTokenSource())
            {
                CancellationToken token = cts.Token;
                ThreadPool.QueueUserWorkItem(_ => AsyncOperation1(token));
                Sleep(TimeSpan.FromSeconds(2));
                cts.Cancel();
            }
            using (var cts = new CancellationTokenSource())
            {
                CancellationToken token = cts.Token;
                ThreadPool.QueueUserWorkItem(_ => AsyncOperation2(token));
                Sleep(TimeSpan.FromSeconds(2));
                cts.Cancel();
            }
            Sleep(TimeSpan.FromSeconds(2));
        }
        static void AsyncOperation1(CancellationToken token)
        {
            WriteLine("Starting the first task");
            for (int i = 0; i < 5; i++)
            {
                if (token.IsCancellationRequested)
                {
                    WriteLine("The first task has been canceled.");
                    return;
                }
                Sleep(TimeSpan.FromSeconds(1));
            }
            WriteLine("The first task has completed succesfully");
        }
        static void AsyncOperation2(CancellationToken token)
        {
            try
            {
                WriteLine("Starting the second task");

                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Sleep(TimeSpan.FromSeconds(1));
                }
                WriteLine("The second task has completed succesfully");
            }
            catch (OperationCanceledException)
            {
                WriteLine("The second task has been canceled.");
            }
        }
        #endregion

        #region 3.5.使用BackgroundWorker组件
        //static void Main(string[] args)
        //{
        //    var bw = new BackgroundWorker();
        //    bw.WorkerReportsProgress = true;
        //    bw.WorkerSupportsCancellation = true;

        //    bw.DoWork += Worker_DoWork;
        //    bw.ProgressChanged += Worker_ProgressChanged;
        //    bw.RunWorkerCompleted += Worker_Completed;

        //    bw.RunWorkerAsync();

        //    WriteLine("Press C to cancel work");
        //    do
        //    {
        //        if (ReadKey(true).KeyChar == 'C')
        //        {
        //            bw.CancelAsync();
        //        }

        //    }
        //    while (bw.IsBusy);
        //}

        //static void Worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    WriteLine($"DoWork thread pool thread id: {CurrentThread.ManagedThreadId}");
        //    var bw = (BackgroundWorker)sender;
        //    for (int i = 1; i <= 100; i++)
        //    {
        //        if (bw.CancellationPending)
        //        {
        //            e.Cancel = true;
        //            return;
        //        }
        //        if (i % 10 == 0)
        //        {
        //            bw.ReportProgress(i);
        //        }

        //        Sleep(TimeSpan.FromSeconds(0.1));
        //    }

        //    e.Result = 42;
        //}
        //static void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    WriteLine($"{e.ProgressPercentage}% completed. " +
        //              $"Progress thread pool thread id: {CurrentThread.ManagedThreadId}");
        //}
        //static void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    WriteLine($"Completed thread pool thread id: {CurrentThread.ManagedThreadId}");
        //    if (e.Error != null)
        //    {
        //        WriteLine($"Exception {e.Error.Message} has occured.");
        //    }
        //    else if (e.Cancelled)
        //    {
        //        WriteLine($"Operation has been canceled.");
        //    }
        //    else
        //    {
        //        WriteLine($"The answer is: {e.Result}");
        //    }
        //}
        #endregion
    }
}
