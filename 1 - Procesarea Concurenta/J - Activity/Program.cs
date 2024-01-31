public class Activity
{
    private CountdownEvent preCondition;

    private Action action;

    private CountdownEvent postSignal;

    public Activity(Action action = null, CountdownEvent preCondition = null, CountdownEvent postSignal = null)
    {
        this.preCondition = preCondition;
        this.action = action;
        this.postSignal = postSignal;
    }

    public void Run()
    {
        preCondition?.Wait();
        action?.Invoke();
        postSignal?.Signal();
    }
}

class Program
{
    static void Main()
    {
        CountdownEvent countdownEvent = new CountdownEvent(2);

        Task.Run(() => new Activity(() => Console.WriteLine("A3"),
               countdownEvent).Run());


        Task.Run(() => new Activity(() => Console.WriteLine("A1"),
                null, countdownEvent).Run());


        Task.Run(() => new Activity(() => Console.WriteLine("A2"),
               null, countdownEvent).Run());

        Console.ReadLine(); // Wait for user input 
    }
}