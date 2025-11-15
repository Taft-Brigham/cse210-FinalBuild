using System;
using System.Threading;

public class ReminderService
{
    private Timer _timer;
    private readonly PromptGenerator _promptGenerator;
    private readonly object _consoleLock = new object();

    public ReminderService(PromptGenerator promptGenerator)
    {
        _promptGenerator = promptGenerator ?? throw new ArgumentNullException(nameof(promptGenerator));
    }

    public void StartDailyReminder(int hour, int minute)
    {
        if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
            throw new ArgumentException("Invalid hour or minute for reminder.");

        DateTime now = DateTime.Now;
        DateTime nextRun = new DateTime(now.Year, now.Month, now.Day, hour, minute, 0);

        if (nextRun <= now)
            nextRun = nextRun.AddDays(1);

        TimeSpan timeToGo = nextRun - now;

        _timer = new Timer(x => SendReminder(), null, timeToGo, TimeSpan.FromDays(1));

        Console.WriteLine($"✅ Daily reminder set for {hour:D2}:{minute:D2}\n");
    }

    private void SendReminder()
    {
        string prompt = _promptGenerator.GetRandomPrompt();

        lock (_consoleLock)
        {
            Console.WriteLine("\n⏰ DAILY JOURNAL REMINDER!");
            Console.WriteLine($"Prompt suggestion: {prompt}");
            Console.WriteLine("(Press Enter to continue)\n");
        }
    }
}
