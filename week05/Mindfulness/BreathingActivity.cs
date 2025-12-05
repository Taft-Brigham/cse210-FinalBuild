// BreathingActivity.cs
using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by walking you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        StartActivity();

        Console.WriteLine("Breathe in slowly...");
        ShowCountdown(5);
        Console.WriteLine("Now breathe out slowly...");
        ShowCountdown(6);

        int cycles = _duration / 11; 
        int remaining = _duration % 11;

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in slowly...");
            ShowCountdown(5);
            Console.WriteLine("Now breathe out slowly...");
            ShowCountdown(6);
        }

        // Use up any leftover seconds
        if (remaining >= 5)
        {
            Console.WriteLine("Breathe in slowly...");
            ShowCountdown(5);
            remaining -= 5;
        }
        if (remaining > 0)
        {
            Console.WriteLine("Now breathe out slowly...");
            ShowCountdown(remaining);
        }

        EndActivity();
    }
}