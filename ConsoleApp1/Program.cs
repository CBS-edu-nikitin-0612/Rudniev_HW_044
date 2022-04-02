using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MyClass
    {
        static int counter;
        public void Method()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Counter = {++counter},  Thread ID = {Thread.CurrentThread.ManagedThreadId}");
            }
        }
        public async void MethodAsync()
        {
            //Task task = new Task(Method);
            //task.Start();

            //Task.Factory.StartNew(Method);
            await Task.Factory.StartNew(Method);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.MethodAsync();
        }
    }
}
