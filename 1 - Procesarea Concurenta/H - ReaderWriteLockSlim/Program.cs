using System;
using System.Threading;

Task.Run(() => ReaderWriterExample.ReaderMethod());
Task.Run(() => ReaderWriterExample.WriterMethod());
Task.Run(() => ReaderWriterExample.ReaderMethod());
Task.Run(() => ReaderWriterExample.WriterMethod());
Task.Run(() => ReaderWriterExample.ReaderMethod());
Task.Run(() => ReaderWriterExample.WriterMethod());

Console.ReadLine();

public class ReaderWriterExample
{
    private static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

    private static int _data = 0;

    public static void ReaderMethod()
    {

        _lock.EnterReadLock();

        try
        {
            Console.WriteLine($"Reading {_data}");
        }

        finally
        {
            _lock.ExitReadLock();
        }
    }

    public static void WriterMethod()
    {
        _lock.EnterWriteLock();

        try
        {
            _data++;

            Console.WriteLine($"Writing {_data}");
        }
        finally
        {
            _lock.ExitWriteLock();
        }

    }

}