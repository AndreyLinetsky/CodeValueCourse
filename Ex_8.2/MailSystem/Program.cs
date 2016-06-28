using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MailSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            MailManager manager = new MailManager();
            manager.MailArrived += NewMailArrived;
            manager.SimulateMailArrived("Hello", "Good day");
            // Check empty string
            manager.SimulateMailArrived("", "");
            // Check null
            manager.SimulateMailArrived(null, null);
            manager.MailArrived -= NewMailArrived;
            // Timer
            TimerCallback timerCallBack = new TimerCallback(MailTiming);
            Timer mailTimer = new Timer(timerCallBack, null, 0, 1000);
            Thread.Sleep(12000);
        }

        static void NewMailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine("Mail title is {0} and mail body is {1}", e.Title, e.Body);
        }

        static void MailTiming(object state)
        {
            MailManager timerManager = new MailManager();
            timerManager.MailArrived += NewMailArrived;
            timerManager.SimulateMailArrived("Notice", "Please dont forget your keys!");
        }
    }
}
