using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;


ProducerConsumerExample example = new ProducerConsumerExample();

example.Start();

public class ProducerConsumerExample
{
    private BlockingCollection<int> buffer = new BlockingCollection<int>();

    public void Start()
    {
        Task producer = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)

            {

                buffer.Add(i);

                Console.WriteLine($"Produced {i}");

            }

            buffer.CompleteAdding();

        });

        Task consumer = Task.Run(() =>
        {
            foreach (var item in buffer.GetConsumingEnumerable())

            {

                Console.WriteLine($"Consumed {item}");

            }

        });

        Task.WaitAll(producer, consumer);
    }
}

