using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread thread = new Thread(Run);

        thread.Start();

        Console.ReadLine();
    }

    static void Run()
    {
        Console.WriteLine("Calcul...");
    }
}