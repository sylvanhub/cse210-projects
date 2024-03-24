using System;
using System.Threading;

abstract class Activity
{
    protected int duration;

    protected void CommonStartingMessage(string activityName, string description)
    {
        Console.WriteLine($"Starting {activityName}...");
        Console.WriteLine(description);
        Console.Write("Enter duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected void CommonEndingMessage(string activityName)
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed {activityName} for {duration} seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected void ShowSpinnerAndCountdown(int seconds)
    {
        Console.WriteLine("Processing...");
        string[] spinner = { "|", "/", "-", "\\" };
        int index = 0;
        for (int i = 0; i < seconds * 2; i++)
        {
            Console.Write($"\r{spinner[index]} {seconds - i}"); // Countdown timer
            index = (index + 1) % spinner.Length;
            Thread.Sleep(2000); // Change speed of spinner here
        }
        Console.WriteLine();
    }

    public abstract void StartActivity();
}