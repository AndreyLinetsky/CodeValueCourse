using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;
        public void SimulateMailArrived(string title, string body)
        {
            if (title == null)
            {
                title = " ";
            }
            if (body == null)
            {
                body = " ";
            }
            OnMailArrived(new MailArrivedEventArgs(title, body));
        }
        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            if (MailArrived != null)
            {
                MailArrived(this, e);
            }
        }


    }
}
