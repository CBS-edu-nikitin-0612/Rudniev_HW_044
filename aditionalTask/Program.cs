using System;
using System.Threading;
using System.Threading.Tasks;

namespace aditionalTask
{
    internal class MyClass
    {
        static int counter;
        object obj = new object();
        public void Method()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (obj)
                {
                    Console.WriteLine($"Counter = {++counter},  Thread ID = {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }
        public async void MethodAsync()
        {
            await Task.Factory.StartNew(Method);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            for (int i = 0; i < 3; i++)
                myClass.MethodAsync();
            Console.ReadKey();
        }
    }
}
