// ListingActivity.cs
using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are you grateful for today?",
        "Who has made a positive difference in your life?",
        "What experiences have shaped who you are?"
    };

    public ListingActivity() 
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        StartActivity();

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt} ---");

        Console.Write("You may begin in: ");
        ShowCountdown(6);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();
        int count = 0;

        Console.WriteLine("Go!\n");

        while (DateTime.Now < endTime)
        {
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item);
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items!");

        ShowSpinner(3);
        EndActivity();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}