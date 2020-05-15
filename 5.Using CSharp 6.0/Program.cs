using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Threading.Thread;
using static System.Console;

namespace _5.Using_CSharp_5._0
{
    class Program
    {
        #region 5.1.同步、线程、回调、Task、async/await比较

        #region 同步

        static void Main()
        {
            Form1 form = new Form1();
            form.button1.Click += Button1_Click;
            Application.Run(form);
        }
        private static void Button1_Click(object sender, EventArgs e)
        {
            LongTimeMethod();
        }
        private static void LongTimeMethod()
        {
            Thread.Sleep(5000);
        }

        #endregion

        #region 线程

        //static void Main()
        //{
        //    Form1 form = new Form1();
        //    form.button1.Click += Button1_Click;
        //    Application.Run(form);
        //}
        //private static void Button1_Click(object sender, EventArgs e)
        //{
        //    Thread thread = new Thread(x => LongTimeMethod());
        //    thread.Start();
        //}
        //private static void LongTimeMethod()
        //{
        //    Thread.Sleep(5000);
        //}

        #endregion

        #region 回调

        //static Form1 form = new Form1();

        //static void Main()
        //{
        //    form.button1.Click += Button1_Click;
        //    Application.Run(form);
        //}

        //private static void Button1_Click(object sender, EventArgs e)
        //{
        //    Func<string> func = LongTimeMethod;
        //    var asyncResult = func.BeginInvoke(MyCallback, null);
        //}

        //private static void MyCallback(IAsyncResult ar)
        //{
        //    AsyncResult asyncResult = ar as AsyncResult;
        //    if (asyncResult != null)
        //    {
        //        Func<string> func = (Func<string>)asyncResult.AsyncDelegate;
        //        string result = func.EndInvoke(ar);
        //        ShowResult(result);
        //    }
        //}
        //private static void ShowResult(string result)
        //{
        //    if (form.InvokeRequired)
        //    {
        //        form.Invoke(new Action(() => form.textBox1.Text = result));
        //    }
        //    else
        //        form.textBox1.Text = result;
        //}

        //private static string LongTimeMethod()
        //{
        //    Thread.Sleep(5000);
        //    return "LongTimeMethod OK";
        //}

        #endregion

        #region Task

        //static Form1 form = new Form1();
        //static void Main()
        //{
        //    form.button1.Click += Button1_Click;
        //    Application.Run(form);
        //}
        //private static void Button1_Click(object sender, EventArgs e)
        //{
        //    Task.Factory.StartNew(() => LongTimeMethod()).ContinueWith(x => ShowResult(x.Result));
        //}
        //private static void ShowResult(string result)
        //{
        //    if (form.InvokeRequired)
        //    {
        //        form.Invoke(new Action(() =>
        //        {
        //            form.textBox1.Text = result;
        //        }));
        //    }
        //    else
        //    {
        //        form.textBox1.Text = result;
        //    }
        //}
        //private static string LongTimeMethod()
        //{
        //    Thread.Sleep(5000);
        //    return "LongTimeMethod OK";
        //}

        #endregion

        #region async/await

        //static Form1 form = new Form1();
        //static void Main()
        //{
        //    form.button1.Click += Button1_Click;
        //    Application.Run(form);
        //}
        //private static async void Button1_Click(object sender, EventArgs e)
        //{
        //    form.textBox1.Text = await LongTimeMethod();
        //}
        //private static async Task<string> LongTimeMethod()
        //{
        //    await Task.Delay(5000);
        //    return "LongTimeMethod OK";
        //}

        #endregion

        #endregion

        #region 5.2.async/await原理

        //    static Form1 mainForm = new Form1();
        //    static void Main()
        //    {
        //        mainForm.button1.Click += Button1_Click;
        //        Application.Run(mainForm);
        //    }

        //    private static void Button1_Click(object sender, EventArgs e)
        //    {
        //        Button1_Click_StateMachine stateMachine = new Button1_Click_StateMachine
        //        {
        //            form = mainForm,
        //            sender = sender,
        //            e = e,
        //            methodBuilder = AsyncVoidMethodBuilder.Create(),
        //            state = -1
        //        };
        //        stateMachine.methodBuilder.Start(ref stateMachine);
        //    }

        //    public static Task<string> LongTimeMethod()
        //    {
        //        LongTimeMethod_StateMachine stateMachine = new LongTimeMethod_StateMachine
        //        {
        //            methodBuilder = AsyncTaskMethodBuilder<string>.Create(),
        //            state = -1
        //        };
        //        stateMachine.methodBuilder.Start(ref stateMachine);
        //        return stateMachine.methodBuilder.Task;
        //    }
        //}

        //public class Button1_Click_StateMachine : IAsyncStateMachine
        //{
        //    public int state;
        //    public Form1 form;
        //    private TextBox textBox;
        //    private string result;
        //    public AsyncVoidMethodBuilder methodBuilder;
        //    private TaskAwaiter<string> taskAwaiter;
        //    public EventArgs e;
        //    public object sender;

        //    public void MoveNext()
        //    {
        //        try
        //        {
        //            TaskAwaiter<string> awaiter;
        //            if (state != 0)
        //            {
        //                textBox = form.textBox1;
        //                awaiter = Program.LongTimeMethod().GetAwaiter();
        //                if (!awaiter.IsCompleted)
        //                {
        //                    state = 0;
        //                    taskAwaiter = awaiter;
        //                    var stateMachine = this;
        //                    methodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                awaiter = taskAwaiter;
        //                taskAwaiter = new TaskAwaiter<string>();
        //                state = -1;
        //            }
        //            result = awaiter.GetResult();
        //            textBox.Text = result;
        //            textBox = null;
        //            result = null;
        //        }
        //        catch (Exception exception)
        //        {
        //            state = -2;
        //            methodBuilder.SetException(exception);
        //            return;
        //        }
        //        state = -2;
        //        methodBuilder.SetResult();
        //    }

        //    [DebuggerHidden]
        //    public void SetStateMachine(IAsyncStateMachine stateMachine)
        //    {

        //    }
        //}

        //public sealed class LongTimeMethod_StateMachine : IAsyncStateMachine
        //{
        //    public int state;
        //    public AsyncTaskMethodBuilder<string> methodBuilder;
        //    private TaskAwaiter taskAwaiter;

        //    public void MoveNext()
        //    {
        //        string str;
        //        try
        //        {
        //            TaskAwaiter awaiter;
        //            if (state != 0)
        //            {
        //                awaiter = Task.Delay(5 * 1000).GetAwaiter();
        //                if (!awaiter.IsCompleted)
        //                {
        //                    state = 0;
        //                    taskAwaiter = awaiter;
        //                    var stateMachine = this;
        //                    methodBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                awaiter = taskAwaiter;
        //                taskAwaiter = new TaskAwaiter();
        //                state = -1;
        //            }
        //            awaiter.GetResult();
        //            str = "LongTimeMethod OK";
        //        }
        //        catch (Exception exception)
        //        {
        //            state = -2;
        //            methodBuilder.SetException(exception);
        //            return;
        //        }
        //        state = -2;
        //        methodBuilder.SetResult(str);
        //    }

        //    public void SetStateMachine(IAsyncStateMachine stateMachine)
        //    {

        //    }

        #endregion

        #region 5.3.在lambda表达式中使用async/await

        //static void Main(string[] args)
        //{
        //    Task t = AsynchronousProcessing();
        //    t.Wait();
        //}

        //static async Task AsynchronousProcessing()
        //{
        //    Func<string, Task<string>> asyncLambda = async name => {
        //        await Task.Delay(TimeSpan.FromSeconds(2));
        //        return
        //            $"Task {name} is running on a thread id {CurrentThread.ManagedThreadId}." +
        //            $" Is thread pool thread: {CurrentThread.IsThreadPoolThread}";
        //    };

        //    string result = await asyncLambda("async lambda");

        //    WriteLine(result);
        //}

        #endregion

        #region 5.4.使用await等待异步并行任务

        //static void Main(string[] args)
        //{
        //    Task t = AsynchronousProcessing();
        //    t.Wait();
        //}

        //static async Task AsynchronousProcessing()
        //{
        //    Task<string> t1 = GetInfoAsync("Task 1", 3);
        //    Task<string> t2 = GetInfoAsync("Task 2", 5);

        //    string[] results = await Task.WhenAll(t1, t2);
        //    foreach (string result in results)
        //    {
        //        WriteLine(result);
        //    }
        //}

        //static async Task<string> GetInfoAsync(string name, int seconds)
        //{
        //    await Task.Delay(TimeSpan.FromSeconds(seconds));
        //    return
        //        $"Task {name} is running on a thread id {CurrentThread.ManagedThreadId}." +
        //        $" Is thread pool thread: {CurrentThread.IsThreadPoolThread}";
        //}

        #endregion

        #region 5.5.async/await中的异常处理

        //static void Main(string[] args)
        //{
        //    Task t = AsynchronousProcessing();
        //    t.Wait();
        //}

        //static async Task AsynchronousProcessing()
        //{
        //    WriteLine("1. Single exception");

        //    try
        //    {
        //        string result = await GetInfoAsync("Task 1", 2);
        //        WriteLine(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLine($"Exception details: {ex}");
        //    }

        //    WriteLine();
        //    WriteLine("2. Multiple exceptions");

        //    Task<string> t1 = GetInfoAsync("Task 1", 3);
        //    Task<string> t2 = GetInfoAsync("Task 2", 2);
        //    try
        //    {
        //        string[] results = await Task.WhenAll(t1, t2);
        //        WriteLine(results.Length);
        //    }
        //    catch (Exception ex)
        //    {
        //        WriteLine($"Exception details: {ex}");
        //    }

        //    WriteLine();
        //    WriteLine("3. Multiple exceptions with AggregateException");

        //    t1 = GetInfoAsync("Task 1", 3);
        //    t2 = GetInfoAsync("Task 2", 2);
        //    Task<string[]> t3 = Task.WhenAll(t1, t2);
        //    try
        //    {
        //        string[] results = await t3;
        //        WriteLine(results.Length);
        //    }
        //    catch
        //    {
        //        var ae = t3.Exception.Flatten();
        //        var exceptions = ae.InnerExceptions;
        //        WriteLine($"Exceptions caught: {exceptions.Count}");
        //        foreach (var e in exceptions)
        //        {
        //            WriteLine($"Exception details: {e}");
        //            WriteLine();
        //        }
        //    }

        //    WriteLine();
        //    WriteLine("4. await in catch and finally blocks");

        //    try
        //    {
        //        string result = await GetInfoAsync("Task 1", 2);
        //        WriteLine(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        await Task.Delay(TimeSpan.FromSeconds(1));
        //        WriteLine($"Catch block with await: Exception details: {ex}");
        //    }
        //    finally
        //    {
        //        await Task.Delay(TimeSpan.FromSeconds(1));
        //        WriteLine("Finally block");
        //    }
        //}

        //static async Task<string> GetInfoAsync(string name, int seconds)
        //{
        //    await Task.Delay(TimeSpan.FromSeconds(seconds));
        //    throw new Exception($"Boom from {name}!");
        //}

        #endregion
    }
}