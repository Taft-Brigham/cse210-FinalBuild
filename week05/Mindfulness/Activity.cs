// Activity.cs
using System;

public class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration; // in seconds

    public string Name => _activityName;

    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }

    public void StartActivity()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("\n\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_activityName} activity for {_duration} seconds.");
        ShowSpinner(4);

        // Log the session
        
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm} | {_activityName} | {_duration}s";
        File.AppendAllText("session_log.txt", logEntry + Environment.NewLine);
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.\n");
        Console.WriteLine(_description + "\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine() ?? "0");
        Console.Clear();
    }

    public virtual void Run()
    {
        // Will be overridden — required for polymorphism
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int cycles = seconds * 4; // 4 frames per second feel

        for (int i = 0; i < cycles; i++)
        {
            Console.Write(spinner[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}