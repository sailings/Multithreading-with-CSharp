using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2.Thread_Synchronization
{
    public partial class Form1 : Form
    {
        private int produceSpeed = 1;
        private int consumeSpeed = 1;

        private bool produceStarted = false;
        private bool consumeStarted = false;

        private bool formClose = false;

        private Thread ProduceThread = null;
        private Thread ConsumeThread = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void SafeAction(Action action)
        {
            try
            {
                if (InvokeRequired)
                    Invoke(action);
                else
                    action();
            }
            catch (Exception ex)
            {

            }
        }

        private void AddTaskToUI(string taskName)
        {
            SafeAction(() =>
            {
                AddTaskToListBox(taskName);
                lbCount.Text = listBox1.Items.Count.ToString();
            });
        }
        private void RemoveTaskFromUI(string taskName)
        {
            SafeAction(() =>
            {
                RemoveTaskFromListBox(taskName);
                lbCount.Text = listBox1.Items.Count.ToString();
            });
        }

        private void AddTaskToListBox(string taskName)
        {
            listBox1.Items.Add(taskName);
        }
        private void RemoveTaskFromListBox(string taskName)
        {
            listBox1.Items.Remove(taskName);
        }

        private void tbProduceSpeed_Scroll(object sender, EventArgs e)
        {
            lbProduceSpeed.Text = tbProduceSpeed.Value.ToString();
            produceSpeed = tbProduceSpeed.Value;
        }

        private void tbConsumeSpeed_Scroll(object sender, EventArgs e)
        {
            lbConsumeSpeed.Text = tbConsumeSpeed.Value.ToString();
            consumeSpeed = tbConsumeSpeed.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProduceThread = new Thread(() => Producer());
            ProduceThread.Start();
            ConsumeThread = new Thread(() => Consumer());
            ConsumeThread.Start();
        }

        private void btnStartProduce_Click(object sender, EventArgs e)
        {
            produceStarted = !produceStarted;
            btnStartProduce.Text = produceStarted ? "停止生产" : "开始生产";
        }

        private void btnStartConsume_Click(object sender, EventArgs e)
        {
            consumeStarted = !consumeStarted;
            btnStartConsume.Text = consumeStarted ? "停止消费" : "开始消费";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            formClose = true;
        }

        #region use lock and AutoResetEvent

        //private static Queue<string> Task = new Queue<string>();
        //private static readonly object locker = new object();
        //private static AutoResetEvent resetEvent = new AutoResetEvent(false);

        //void Producer()
        //{
        //    while (!formClose)
        //    {
        //        if (produceStarted)
        //        {
        //            lock (locker)
        //            {
        //                string taskID = Guid.NewGuid().ToString();
        //                Task.Enqueue(taskID);
        //                AddTaskToUI(taskID);
        //            }
        //            resetEvent.Set();
        //            Thread.Sleep(1000 / produceSpeed);
        //        }
        //        else
        //            Thread.Sleep(100);
        //    }
        //}
        //void Consumer()
        //{
        //    while (!formClose)
        //    {
        //        if (consumeStarted)
        //        {
        //            string taskID = "";
        //            lock (locker)
        //            {
        //                if (Task.Count > 0)
        //                {
        //                    taskID = Task.Dequeue();
        //                }
        //            }
        //            if (!string.IsNullOrEmpty(taskID))
        //            {
        //                RemoveTaskFromUI(taskID);
        //                Thread.Sleep(1000 / consumeSpeed);
        //            }
        //            else
        //            {
        //                resetEvent.WaitOne();
        //            }
        //        }
        //        else
        //            Thread.Sleep(100);
        //    }
        //}
        #endregion

        #region use BlockingCollection

        //private static BlockingCollection<string> Task = new BlockingCollection<string>(5);

        //void Producer()
        //{
        //    while (!formClose)
        //    {
        //        if (produceStarted)
        //        {
        //            string taskID = Guid.NewGuid().ToString();
        //            Task.Add(taskID);
        //            AddTaskToUI(taskID);
        //            Thread.Sleep(1000 / produceSpeed);
        //        }
        //        else
        //            Thread.Sleep(100);
        //    }
        //}
        //void Consumer()
        //{
        //    while (!formClose)
        //    {
        //        if (consumeStarted)
        //        {
        //            var taskID = Task.Take();
        //            RemoveTaskFromUI(taskID);
        //            Thread.Sleep(1000 / consumeSpeed);
        //        }
        //        else
        //            Thread.Sleep(100);
        //    }
        //}
        //private void btnManual_Click(object sender, EventArgs e)
        //{
        //    string taskID = Guid.NewGuid().ToString();
        //    Task.Add(taskID);
        //    AddTaskToUI(taskID);
        //}

        #endregion

        #region use BlockingCollection with No Block

        private static BlockingCollection<string> Task = new BlockingCollection<string>(5);

        void Producer()
        {
            while (!formClose)
            {
                if (produceStarted)
                {
                    string taskID = Guid.NewGuid().ToString();
                    bool result = Task.TryAdd(taskID, 200);
                    if (result)
                        AddTaskToUI(taskID);
                    Thread.Sleep(1000 / produceSpeed);
                }
                else
                    Thread.Sleep(100);
            }
        }
        void Consumer()
        {
            string taskID = "";
            while (!formClose)
            {
                if (consumeStarted)
                {
                    var result = Task.TryTake(out taskID);
                    if (result)
                    {
                        RemoveTaskFromUI(taskID);
                        Thread.Sleep(1000 / consumeSpeed);
                    }
                }
                else
                    Thread.Sleep(100);
            }
        }
        private void btnManual_Click(object sender, EventArgs e)
        {
            string taskID = Guid.NewGuid().ToString();
            var result = Task.TryAdd(taskID, 100);
            if (result)
            {
                AddTaskToUI(taskID);
            }
        }

        #endregion
    }
}
