using System;

class Program
{
    static void Main(string[] args)
    {
        // List of scriptures - program picks one at random each time
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), 
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            
            new Scripture(new Reference("Proverbs", 3, 5, 6), 
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            
            new Scripture(new Reference("Psalm", 23, 1), 
                "The Lord is my shepherd, I lack nothing.")
        };

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        Console.Clear();

        while (!scripture.AllWordsHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                return;

            scripture.HideRandomWords(2);  // This will hide 2 words after each press
            Console.Clear();
        }

        // What to show after hiding evrything
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden! Well done! You memorized the scripture!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}



// Creativity & Exceeding Requirements:
// • Multiple scriptures loaded from a list (random each time)
// • Only hides words that are still visible (stretch challenge)
// • Beautiful display with extra spacing
// • Works perfectly with single verse or verse ranges
