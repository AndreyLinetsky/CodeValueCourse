using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailArrivedEventArgs : EventArgs
    {
        private string title;
        private string body;
        public MailArrivedEventArgs(string initTitle, string initBody)
        {
            title = initTitle;
            body = initBody;
        }
        public string Title
        {
            get
            {
                return title;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }
        }
    }
}
