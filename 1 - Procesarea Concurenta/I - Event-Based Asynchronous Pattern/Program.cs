using System;
using System.ComponentModel;
using System.Threading;

public class AsyncOperationExample
{
    public event EventHandler<AsyncCompletedEventArgs> Completed;

    public void StartAsyncOperation()
    {
        BackgroundWorker worker = new BackgroundWorker();

        worker.DoWork += (sender, e) => { Thread.Sleep(1000); }; // Simulare lucru 

        worker.RunWorkerCompleted += (sender, e) =>
        {
            OnCompleted(new AsyncCompletedEventArgs(e.Error, e.Cancelled, null));
        };

        worker.RunWorkerAsync();
    }

    protected virtual void OnCompleted(AsyncCompletedEventArgs e)
    {
        Completed?.Invoke(this, e);
    }
}