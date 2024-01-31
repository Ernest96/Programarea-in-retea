using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int parameter = 42;

        int result = await Task.Run(() => Run(parameter));

        Console.WriteLine($"result = {result}");

        Console.ReadLine();
    }
    static int Run(int parameter)
    {
        int result = parameter * 2;

        Console.WriteLine($"Calcul efectuat...");

        return result;
    }
}