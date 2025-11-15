using System;

public class Entry
{
    public string _timestamp;
    public string _promptText;
    public string _entryText;
    public string _tag;

    public void Display()
    {
        Console.WriteLine($"Date/Time: {_timestamp}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Tag: {_tag}");
        Console.WriteLine("Response:");
        Console.WriteLine(_entryText);
        Console.WriteLine(new string('-', 40));
    }
}
