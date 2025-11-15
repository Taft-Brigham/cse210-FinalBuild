using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                string safeText = entry._entryText.Replace("\n", "<br>");
                string safeTag = entry._tag.Replace("|", "/");
                outputFile.WriteLine($"{entry._timestamp}|{entry._promptText}|{safeText}|{safeTag}");
            }
        }
        Console.WriteLine("Journal saved successfully.\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                Entry entry = new Entry();
                entry._timestamp = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2].Replace("<br>", "\n");
                entry._tag = parts[3];

                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded successfully.\n");
    }
}
