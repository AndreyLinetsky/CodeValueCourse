using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
    sealed class CodeReviewAttribute : Attribute
    {
        private string name;
        private string date;
        private bool isApproved;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Date
        {
            get
            {
                return date;
            }
        }
        public bool IsApproved
        {
            get
            {
                return isApproved;
            }

        }

        public CodeReviewAttribute(string initName, string initDate, bool initApprove)
        {
            name = initName;
            date = initDate;
            isApproved = initApprove;
        }
    }
}
