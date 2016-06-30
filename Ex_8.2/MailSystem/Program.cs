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
            EventHandler<MailArrivedEventArgs> mailHandler = (sender, e) =>
                {
                    Console.WriteLine("Mail title is {0} and mail body is {1}", e.Title, e.Body);
                };
            manager.MailArrived += mailHandler;
            manager.SimulateMailArrived("Hello", "Good day");
            // Check empty string
            manager.SimulateMailArrived("", "");
            // Check null
            manager.SimulateMailArrived(null, null);

            // Timer
            TimerCallback timerCallBack = (state) =>
            {
                manager.SimulateMailArrived("Notice", "Please dont forget your keys!");
            };
            Timer mailTimer = new Timer(timerCallBack, null, 0, 1000);
            Thread.Sleep(12000);
            manager.MailArrived -= mailHandler;
        }
    }
}
