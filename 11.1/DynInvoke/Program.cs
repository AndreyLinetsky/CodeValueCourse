using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DynInvoke
{
    class Program
    {
        public static void InvokeHello(object obj, string inputString)
        {
            if (obj != null)
            {
                Type objType = obj.GetType();
                MethodInfo method = objType.GetMethod("Hello", new Type[] { typeof(string) });
                if (method != null)
                {
                    object printString = method.Invoke(obj, new object[] { inputString });
                    Console.WriteLine("Result: {0}", printString.ToString());
                }
                else
                {
                    Console.WriteLine("Method does not exists");
                }
            }
            else
            {
                Console.WriteLine("object was null");
            }
        }
        static void Main(string[] args)
        {
            A firstEx = new A();
            B secondEx = new B();
            C thirdEx = new C();
            InvokeHello(firstEx, "Israel");
            InvokeHello(secondEx, "France");
            InvokeHello(thirdEx, "Asia");
        }
    }
}
