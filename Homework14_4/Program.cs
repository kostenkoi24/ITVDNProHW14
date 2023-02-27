using System;
using System.Threading;
using System.Threading.Tasks;

namespace Homework14_4
{
    class Program
    {
        static int counter = 0;

        static object block = 0;

        static void Function()
        {
            lock (block)
            {
                for (int i = 0; i < 5; ++i)
                {
                    Console.WriteLine(++counter);
                    Console.WriteLine("\t{0}", Thread.CurrentThread.GetHashCode());
                    Thread.Sleep(1000);
                }
            }

        }


        


        static async Task Main()
        {
            
            Task[] task = new Task[3];
            for (int i = 0; i < 3; i++)
            {
                task[i] = new Task(Function);
                task[i].Start();
                await task[i];
            }

            // Delay
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}
