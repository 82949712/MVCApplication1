using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static event MyDelegate someEvent;
        private delegate string MyDelegate(string message);
        static void Main(string[] args)
        {
            InvokeEvent();
            Console.WriteLine(someEvent("test"));
            Console.ReadLine();
            var a = new Dictionary<string, string>() {{"adf", "test"}};
            var b = new List<string>() {"get", "set"};

        }

        private static void InvokeEvent()
        {
            someEvent += (string a) => a.ToUpper();
        }
    }
}
