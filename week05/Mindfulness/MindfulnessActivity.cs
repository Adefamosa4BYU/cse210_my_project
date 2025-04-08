using System;
using System.Threading;

public abstract class MindfulnessActivity
{
    protected string name;
    protected string description;
    protected int duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"\n{name}");
        Console.WriteLine(description);
        Console.Write("\nEnter duration in seconds: ");
        
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);

        PerformActivity();

        EndActivity();
    }

    public abstract void PerformActivity();

    protected void EndActivity()
    {
        Console.WriteLine("\nGood job!");
        ShowSpinner(3);
        Console.WriteLine($"You completed the {name} for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(500);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
