using System;

using System.Threading;



class Program
{

    static object lockObject = new object();

    static void Main()
    {
        // Incercati sa rulati codul dat cu 2 fire de executie
        Thread thread = new Thread(Run);

        thread.Start();

        Console.ReadLine();
    }

    static void Run()
    {

        lock (lockObject)
        {
            Console.WriteLine($"Sunt in sectiune critica");

            Console.WriteLine("Calcul...");

            Thread.Sleep(2000);

        }

        Console.WriteLine($"Am parasit sectiunea critica");
    }

}