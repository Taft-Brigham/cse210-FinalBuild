using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _streak; // Exceeds: Simple streak counter

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _streak = 0;
    }

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
            else if (choice == "6")
            {
                Console.WriteLine("Thanks for pursuing eternal goals! Keep going!");
                break;
            }
            else Console.WriteLine("Invalid choice. Try again.");
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points | Level {_level} | Streak: {_streak}");
    }

    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is a short name for it? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;
        if (typeChoice == "1")
        {
            goal = new SimpleGoal(name, desc, points);
        }
        else if (typeChoice == "2")
        {
            goal = new EternalGoal(name, desc, points);
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, desc, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create one first!");
            return;
        }

        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index;
        if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= _goals.Count)
        {
            int points = _goals[index - 1].RecordEvent();
            _score += points;
            _streak++; 
            _level = _score / 500 + 1; 

            Console.WriteLine($"Congratulations! You've earned {points} points!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to {filename}");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _level = _score / 500 + 1;
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split("|");

            if (type == "SimpleGoal")
            {
                var goal = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                if (bool.Parse(data[3])) goal.RecordEvent();
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                var goal = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                for (int j = 0; j < int.Parse(data[5]); j++) goal.RecordEvent(); 
                _goals.Add(goal);
            }
        }
        Console.WriteLine($"Goals loaded from {filename}");
    }
}

