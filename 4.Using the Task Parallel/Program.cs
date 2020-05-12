using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

namespace _4.Using_the_Task_Parallel
{
    class Program
    {
        #region 4.1.创建Task
        //static void Main(string[] args)
        //{
        //    var t1 = new Task(() => TaskMethod("Task 1"));
        //    t1.Start();
        //    Task.Run(() => TaskMethod("Task 2"));
        //    Task.Factory.StartNew(() => TaskMethod("Task 3"));
        //    Sleep(TimeSpan.FromSeconds(1));
        //}
        //static void TaskMethod(string name)
        //{
        //    WriteLine($"Task {name} is running on a thread id " +
        //              $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
        //              $"{CurrentThread.IsThreadPoolThread}");
        //}
        #endregion

        #region 4.2.Task上的基本操作
        //static void Main(string[] args)
        //{
        //    TaskMethod("Main Thread Task");
        //    Task<int> task = CreateTask("Task 1");
        //    task.Start();
        //    int result = task.Result;
        //    WriteLine($"Result is: {result}");

        //    task = CreateTask("Task 2");
        //    task.RunSynchronously();
        //    result = task.Result;
        //    WriteLine($"Result is: {result}");

        //    task = CreateTask("Task 3");
        //    WriteLine(task.Status);
        //    task.Start();

        //    while (!task.IsCompleted)
        //    {
        //        WriteLine(task.Status);
        //        Sleep(TimeSpan.FromSeconds(0.5));
        //    }

        //    WriteLine(task.Status);
        //    result = task.Result;
        //    WriteLine($"Result is: {result}");
        //}

        //static Task<int> CreateTask(string name)
        //{
        //    return new Task<int>(() => TaskMethod(name));
        //}

        //static int TaskMethod(string name)
        //{
        //    WriteLine($"Task {name} is running on a thread id " +
        //              $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
        //              $"{CurrentThread.IsThreadPoolThread}");
        //    Sleep(TimeSpan.FromSeconds(2));
        //    return 42;
        //}
        #endregion

        #region 4.3.Task的协作
        static void Main(string[] args)
        {
            //var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
            //firstTask.ContinueWith(
            //    t => WriteLine(
            //        $"The first answer is {t.Result}. Thread id " +
            //        $"{CurrentThread.ManagedThreadId}, is thread pool thread: " +
            //        $"{CurrentThread.IsThreadPoolThread}"),
            //    TaskContinuationOptions.OnlyOnRanToCompletion);
            //firstTask.Start();

            //var secondTask = new Task<int>(() => TaskMethod("Second Task", 2));
            //secondTask.Start();
            //Task continuation = secondTask.ContinueWith(
            //    t => WriteLine(
            //        $"The second answer is {t.Result}. Thread id " +
            //        $"{CurrentThread.ManagedThreadId}, is thread pool thread: " +
            //        $"{CurrentThread.IsThreadPoolThread}"),
            //    TaskContinuationOptions.OnlyOnRanToCompletion);
            //    //| TaskContinuationOptions.ExecuteSynchronously);
            //continuation.GetAwaiter().OnCompleted(
            //    () => WriteLine(
            //        $"Continuation Task Completed! Thread id " +
            //        $"{CurrentThread.ManagedThreadId}, is thread pool thread: " +
            //        $"{CurrentThread.IsThreadPoolThread}"));

            var firstTask = new Task<int>(() =>
            {
                var childTask = Task.Factory.StartNew(() => TaskMethod("Child Task", 5),
                    TaskCreationOptions.AttachedToParent);

                childTask.ContinueWith(t => TaskMethod("Child Task Continue", 2),
                    TaskContinuationOptions.AttachedToParent);

                return TaskMethod("Parent Task", 2);
            });

            firstTask.Start();

            while (!firstTask.IsCompleted)
            {
                WriteLine(firstTask.Status);
                Sleep(TimeSpan.FromSeconds(0.5));
            }
            WriteLine(firstTask.Status);

            //Sleep(TimeSpan.FromSeconds(10));
            WriteLine("End");
            ReadLine();
        }
        static int TaskMethod(string name, int seconds)
        {
            WriteLine(
                $"{name} is running on a thread id " +
                $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
                $"{CurrentThread.IsThreadPoolThread}");
            Sleep(TimeSpan.FromSeconds(seconds));
            WriteLine(name + " finished");
            return 1 * seconds;
        }
        #endregion

        #region 4.4.Task的取消

        //static void Main(string[] args)
        //{
        //    var cts = new CancellationTokenSource();
        //    var longTask = new Task<int>(() => TaskMethod("Task 1", 10, cts.Token), cts.Token);
        //    WriteLine(longTask.Status);
        //    cts.Cancel();
        //    WriteLine(longTask.Status);
        //    WriteLine("First task has been cancelled before execution");

        //    cts = new CancellationTokenSource();
        //    longTask = new Task<int>(() => TaskMethod("Task 2", 10, cts.Token), cts.Token);
        //    longTask.Start();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(0.5));
        //        WriteLine(longTask.Status);
        //    }
        //    cts.Cancel();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(0.5));
        //        WriteLine(longTask.Status);
        //    }

        //    WriteLine($"A task has been completed with result {longTask.Result}.");
        //}
        //static int TaskMethod(string name, int seconds, CancellationToken token)
        //{
        //    WriteLine(
        //        $"Task {name} is running on a thread id " +
        //        $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
        //        $"{CurrentThread.IsThreadPoolThread}");

        //    for (int i = 0; i < seconds; i++)
        //    {
        //        Sleep(TimeSpan.FromSeconds(1));
        //        if (token.IsCancellationRequested) return -1;
        //    }
        //    return 42 * seconds;
        //}

        #endregion

        #region 4.5.Task异常处理
        //static void Main(string[] args)
        //{
        //    //Task<int> task;
        //    //try
        //    //{
        //    //    task = Task.Run(() => TaskMethod("Task 1", 1));
        //    //    //int result = task.Result;
        //    //    //WriteLine($"Result: {result}");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    WriteLine($"Exception caught: {ex}");
        //    //}

        //    var t1 = new Task<int>(() => TaskMethod("Task 3", 3));
        //    var t2 = new Task<int>(() => TaskMethod("Task 4", 2));
        //    var complexTask = Task.WhenAll(t1, t2);
        //    var exceptionHandler = complexTask.ContinueWith(t =>
        //            WriteLine($"Exception caught: {t.Exception}"),
        //            TaskContinuationOptions.OnlyOnFaulted
        //        );
        //    t1.Start();
        //    t2.Start();

        //    Console.ReadLine();
        //}
        //static int TaskMethod(string name, int seconds)
        //{
        //    WriteLine(
        //        $"Task {name} is running on a thread id " +
        //        $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
        //        $"{CurrentThread.IsThreadPoolThread}");

        //    Sleep(TimeSpan.FromSeconds(seconds));
        //    throw new Exception("Boom!");
        //    //return 42 * seconds;
        //}
        #endregion

        #region 4.6.Task并行
        //static void Main(string[] args)
        //{
        //    //var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
        //    //var secondTask = new Task<int>(() => TaskMethod("Second Task", 2));
        //    //var whenAllTask = Task.WhenAll(firstTask, secondTask);

        //    //whenAllTask.ContinueWith(t =>
        //    //    WriteLine($"The first answer is {t.Result[0]}, the second is {t.Result[1]}"),
        //    //    TaskContinuationOptions.OnlyOnRanToCompletion);

        //    //firstTask.Start();
        //    //secondTask.Start();

        //    //Sleep(TimeSpan.FromSeconds(4));

        //    var tasks = new List<Task<int>>();
        //    for (int i = 1; i < 4; i++)
        //    {
        //        int counter = i;
        //        var task = new Task<int>(() => TaskMethod($"Task {counter}", counter));
        //        tasks.Add(task);
        //        task.Start();
        //    }

        //    while (tasks.Count > 0)
        //    {
        //        var completedTask = Task.WhenAny(tasks).Result;
        //        tasks.Remove(completedTask);
        //        WriteLine($"A task has been completed with result {completedTask.Result}.");
        //    }

        //    //Sleep(TimeSpan.FromSeconds(1));
        //    Console.ReadLine();
        //}
        //static int TaskMethod(string name, int seconds)
        //{
        //    WriteLine(
        //        $"Task {name} is running on a thread id " +
        //        $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
        //        $"{CurrentThread.IsThreadPoolThread}");

        //    Sleep(TimeSpan.FromSeconds(seconds));
        //    return 42 * seconds;
        //}
        #endregion
    }
}