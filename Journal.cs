using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private GetPrompt _promptGenerator = new GetPrompt();

    public void WriteNewEntry()
    {
        string randomPrompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string currentDate = DateTime.Now.ToString("yyyy/MM/dd");
        Entry newEntry = new Entry(randomPrompt, response, currentDate);
        _entries.Add(newEntry);

        Console.WriteLine("Entry saved successfully!");
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
        }
    }

    public void SaveJournalToFile()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to save.");
            return;
        }

        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        Console.WriteLine($"Entries to be saved to {filename}:");
        foreach (var entry in _entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt}: {entry.Response}");
        }

        string fullPath = Path.GetFullPath(filename);
        Console.WriteLine($"Absolute Path: {fullPath}");

        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                sw.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine("Journal saved to file successfully!");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter a filename to load the journal: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            _entries.Clear();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string[] entryData = sr.ReadLine().Split(',');
                    _entries.Add(new Entry(entryData[1], entryData[2], entryData[0]));
                }
            }

            Console.WriteLine("Journal loaded from file successfully!");
        }
        else
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
        }
    }
}
