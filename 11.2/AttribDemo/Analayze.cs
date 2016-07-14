using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace AttribDemo
{
    class Analayze
    {
        public bool AnalayzeAssembly(Assembly inputAssembly)
        {
            bool isAllApproved = true;
            // If assembly is null then return true 
            if (inputAssembly != null)
            {
                Type[] assemblyTypes = inputAssembly.GetTypes();
                foreach (Type currType in assemblyTypes)
                {
                    object[] currAttributes = currType.GetCustomAttributes(typeof(CodeReviewAttribute), false);
                    foreach (CodeReviewAttribute attr in currAttributes)
                    {
                        if (!attr.IsApproved)
                        {
                            isAllApproved = false;
                        }
                        Console.Write("Reviewer name is {0},date is {1}", attr.Name, attr.Date);
                        if (attr.IsApproved)
                        {
                            Console.WriteLine(",the review was approved");
                        }
                        else
                        {
                            Console.WriteLine(",the review was not approved");
                        }
                    }
                }
            }
            return isAllApproved;
        }
    }
}