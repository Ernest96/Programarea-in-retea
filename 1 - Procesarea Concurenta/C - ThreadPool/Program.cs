using System;
using System.Threading;
class Program
{
    static void Main()
    {
        ThreadPool.QueueUserWorkItem(Run);

        Console.ReadLine();
    }

    static void Run(object state)
    {
        Console.WriteLine("Calcul in ThreadPool...");
    }
}