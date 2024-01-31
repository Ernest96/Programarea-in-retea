using System;
using System.Threading;

class Program
{

    static Semaphore semaphore = new Semaphore(2, 2);
    static void Main()
    {
        for (int i = 1; i <= 5; i++)
        {
            Thread thread = new Thread(Run);
            thread.Start(i);
        }

        Console.ReadLine();
    }

    static void Run(object threadId)
    {
        Console.WriteLine($"Firul {threadId} asteapta...");

        semaphore.WaitOne();

        Console.WriteLine($"Firul {threadId} a intrat");

        Thread.Sleep(2000);

        Console.WriteLine($"Firul {threadId} a iesit");

        semaphore.Release();
    }
}