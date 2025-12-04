// GratitudeActivity.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts = new List<string>
    {
        "What made you smile today?",
        "Who are you thankful for right now?",
        "What is one thing your body did for you today?",
        "What is something beautiful you saw recently?",
        "What is a small moment of joy you experienced?",
        "What opportunity are you grateful for?"
    };

    public GratitudeActivity()
        : base("Gratitude Activity",
               "This activity helps you focus on gratitude by guiding you to write down things you are thankful for today.")
    {
    }

    public override void Run()
    {
        StartActivity();

        Console.WriteLine("Today, let's focus on gratitude.\n");
        string prompt = _gratitudePrompts[new Random().Next(_gratitudePrompts.Count)];
        Console.WriteLine($"Prompt: {prompt}\n");
        Console.WriteLine("Start typing things you are grateful for (one per line). Time starts now!\n");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
                count++;
            if (DateTime.Now >= endTime) break;
        }

        Console.WriteLine($"\nWonderful! You expressed gratitude {count} times.");

        

        EndActivity();
    }
}