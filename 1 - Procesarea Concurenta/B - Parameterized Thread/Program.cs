using System;
using System.Threading;

class Program
{
    static void Main()
    {
        string parameter = "PR";

        Thread thread = new Thread(new ParameterizedThreadStart(Run));

        thread.Start(parameter);

        Console.ReadLine();
    }
    static void Run(object parameter)
    {
        Console.WriteLine($"Calcul cu {parameter}...");
    }

}