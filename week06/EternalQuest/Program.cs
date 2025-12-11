using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Eternal Quest - Turn your goals into eternity!");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

// To exceed requirements, I added a leveling system (level up every 500 points) and a streak counter 
// (increments on each event record—could be tied to dates for true daily streaks in a future version).
// This adds gamification to motivate users beyond basic points.

// How to Use The Program

// Choose 1 : Create New Goal
// Create a Simple Goal: “Run a marathon” → 1000 points
// Create an Eternal Goal: “Read scriptures” → 100 points
// Create a Checklist Goal: “Attend the temple 10 times” → 50 points each + 500 bonus

// Choose 5 : Record Event
// Pick #1 (Run a marathon) → you instantly earn 1000 points (and it becomes [X])
// Pick #2 (Read scriptures) → you earn 100 points
// Pick #2 again → another 100 points (you can do this forever)
// Pick #3 ten times → you earn 50 × 10 = 500 points normally + 500 bonus the 10th time = 1000 total for that goal

// Your score at the top keeps climbing every time you record an event.
// Every 500 total points → you level up (shown in the header).
// The streak counter increments with each recorded event, encouraging consistent engagement.