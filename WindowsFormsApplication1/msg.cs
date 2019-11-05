using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Drawing;

namespace WindowsFormsApplication1
{
    public class Msg
    {
        delegate void DisplayCallback(object displayer);
        public void ShowMsgCallback(object displayer)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 

            int n = 0;
            Type type = displayer.GetType();
            dynamic obj = Convert.ChangeType(displayer, type);

            while (obj.IsHandleCreated == false)
            {
                //解决窗体关闭时出现“访问已释放句柄“的异常
                if (obj.Disposing || obj.IsDisposed)
                    return;
                Application.DoEvents();
                Thread.Sleep(1);
                if (n++ > 100) return;
            }
            //如果调用控件的线程和创建创建控件的线程不是同一个则为True
            if (obj.InvokeRequired)
            {
                DisplayCallback d = new DisplayCallback(ShowMsgCallback);
                obj.BeginInvoke(d, new object[] { displayer });
            }
            else
            {
                showmsg(obj);
            }
        }
        public struct MsgData
        {

            public DateTime dt;
            public string msg;
            public override string ToString()
            {
                return string.Format(" [{0:HH:mm:ss.fff}] {1}", dt, msg);
            }
        }
        public static LinkedList<MsgData> list_msgdat = new LinkedList<MsgData>();
        static object lockobj = new object();
        public void showmsg(RichTextBox rtb)
        {
            if (list_msgdat.Count == 0 || rtb == null) return;

            while (list_msgdat.Count > 0)
            {
                MsgData msg = list_msgdat.First();

                rtb.AppendText(msg.ToString() + "\r\n");
                rtb.SelectedText = msg.ToString() + "\r\n";


                if (rtb.Lines.Count() > 100)//大于100行
                    rtb.Lines[0].Remove(0);

                rtb.SelectionStart = rtb.Text.Length;
                rtb.ScrollToCaret();

                lock (lockobj)
                {
                    list_msgdat.RemoveFirst();
                }
            }
        }
        System.Timers.Timer timer;
        object displayer;
        public void StartUpdate(object displayer)
        {
            if (displayer == null) return;
            this.displayer = displayer;
            //显示刷新
            if (timer == null)
            {
                timer = new System.Timers.Timer(200);
                timer.Elapsed += timer_Elapsed;//委托
                timer.AutoReset = true;
                timer.Enabled = true;
            }
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (list_msgdat.Count == 0 || displayer == null) return;
            ShowMsgCallback(displayer);
        }
        public void addmsg(string Strmsg)
        {
            MsgData msg = new MsgData();

            msg.msg = Strmsg;
            msg.dt = DateTime.Now;
            lock (lockobj)
            {
                list_msgdat.AddLast(msg);
                if (list_msgdat.Count > 200) list_msgdat.RemoveFirst();
            }
        }
    }
}
