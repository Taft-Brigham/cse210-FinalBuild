using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "Who did you interact with today and how did it go?",
        "How did you see the hand of the Lord in your life today?",
        "What emotion was strongest for you today?",
        "If you could redo one thing today, what would it be?",
        "What is something you learned today?",
        "Describe a moment that made you smile today."
    };

    private Random _rand = new Random();

    public string GetRandomPrompt()
    {
        int index = _rand.Next(_prompts.Count);
        return _prompts[index];
    }
}
