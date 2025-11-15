using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to your Journal Program!\n");

        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        // Set up daily reminder
        Console.WriteLine("Set your daily journal reminder time.");
        int hour = GetValidNumber("Hour (0-23): ", 0, 23);
        int minute = GetValidNumber("Minute (0-59): ", 0, 59);

        ReminderService reminderService = new ReminderService(promptGenerator);
        reminderService.StartDailyReminder(hour, minute);

        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load journal from file");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Entry newEntry = new Entry();
                    newEntry._timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    newEntry._promptText = promptGenerator.GetRandomPrompt();

                    Console.WriteLine(newEntry._promptText);
                    Console.WriteLine("Your response (type 'END' to finish):");

                    string response = "";
                    string line;
                    while ((line = Console.ReadLine()) != "END")
                    {
                        response += line + "\n";
                    }
                    newEntry._entryText = response.Trim();

                    Console.Write("Add a tag (e.g., Mood: Happy): ");
                    newEntry._tag = Console.ReadLine();

                    myJournal.AddEntry(newEntry);
                    Console.WriteLine("Entry added!\n");
                    break;

                case "2":
                    myJournal.DisplayAll();
                    break;

                case "3":
                    try
                    {
                        Console.Write("Enter filename to load: ");
                        myJournal.LoadFromFile(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading file: {ex.Message}\n");
                    }
                    break;

                case "4":
                    try
                    {
                        Console.Write("Enter filename to save: ");
                        myJournal.SaveToFile(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving file: {ex.Message}\n");
                    }
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }
    }

    // Helper to get valid numeric input
    private static int GetValidNumber(string prompt, int min, int max)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max)
                return number;
            Console.WriteLine($"Invalid input. Enter a number between {min} and {max}.");
        }
    }
}
