using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private GetPrompt promptGenerator = new GetPrompt();

    public void WriteNewEntry()
    {
        string randomPrompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string currentDate = DateTime.Now.ToString("yyyy/MM/dd");
        Entry newEntry = new Entry(randomPrompt, response, currentDate);
        entries.Add(newEntry);

        Console.WriteLine("Entry saved successfully!");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (var entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveJournalToFile()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to save.");
            return;
        }

        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        Console.WriteLine($"Entries to be saved to {filename}:");
        foreach (var entry in entries)
        {
            Console.WriteLine($"{entry.Date} - {entry.Prompt}: {entry.Response}");
        }

        string fullPath = Path.GetFullPath(filename);
        Console.WriteLine($"Absolute Path: {fullPath}");

        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in entries)
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
            entries.Clear();

            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string[] entryData = sr.ReadLine().Split(',');
                    entries.Add(new Entry { Date = entryData[0], Prompt = entryData[1], Response = entryData[2] });
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


// using System;
// using System.Collections.Generic;
// using System.IO;

// public class Journal
// {
//     private List<Entry> entries = new List<Entry>();
//     private GetPrompt promptGenerator = new GetPrompt();  // Add this line

//     // public void WriteNewEntry()
//     // {
//     //     string randomPrompt = promptGenerator.GetRandomPrompt();

//     //     Console.WriteLine($"Prompt: {randomPrompt}");
//     //     Console.Write("Your response: ");
//     //     string response = Console.ReadLine();

//     //     string currentDate = DateTime.Now.ToString("yyyy/MM/dd");
//     //     entries.Add(new Entry { Prompt = randomPrompt, Response = response, Date = currentDate });

//     //     Console.WriteLine("Entry saved successfully!");
//     // }

//     private class Entry
//     {
//         private string prompt;
//         private string response;
//         private string date;

//         public Entry(string prompt, string response, string date)
//         {
//             this.prompt = prompt;
//             this.response = response;
//             this.date = date;
//         }

//     public void WriteNewEntry()
//     {
//     string randomPrompt = promptGenerator.GetRandomPrompt();
//     Console.WriteLine($"Prompt: {randomPrompt}");
//     Console.Write("Your response: ");
//     string response = Console.ReadLine();

//     string currentDate = DateTime.Now.ToString("yyyy/MM/dd");

//     // Create a new Entry instance with the provided values
//     Entry newEntry = new Entry(randomPrompt, response, currentDate);

//     // Add the new entry to the list
//     entries.Add(newEntry);

//     Console.WriteLine("Entry saved successfully!");
// }


//     public void DisplayJournal()
// {
//     if (entries.Count == 0)
//     {
//         Console.WriteLine("No entries to display.");
//         return;
//     }

//     foreach (var entry in entries)
//     {
//         Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
//     }
// }


//     public void SaveJournalToFile()
// {
//     if (entries.Count == 0)
//     {
//         Console.WriteLine("No entries to save.");
//         return;
//     }

//     Console.Write("Enter a filename to save the journal: ");
//     string filename = Console.ReadLine();

//     Console.WriteLine($"Entries to be saved to {filename}:");
//     foreach (var entry in entries)
//     {
//         Console.WriteLine($"{entry.Date} - {entry.Prompt}: {entry.Response}");
//     }

//     string fullPath = Path.GetFullPath(filename);
//     Console.WriteLine($"Absolute Path: {fullPath}");

//     using (StreamWriter sw = new StreamWriter(filename))
//     {
//         foreach (var entry in entries)
//         {
//             sw.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
//         }
//     }

//     Console.WriteLine("Journal saved to file successfully!");
// }


//     public void LoadJournalFromFile()
//     {
//         Console.Write("Enter a filename to load the journal: ");
//         string filename = Console.ReadLine();

//         if (File.Exists(filename))
//         {
//             entries.Clear();

//             using (StreamReader sr = new StreamReader(filename))
//             {
//                 while (!sr.EndOfStream)
//                 {
//                     string[] entryData = sr.ReadLine().Split(',');
//                     entries.Add(new Entry { Date = entryData[0], Prompt = entryData[1], Response = entryData[2] });
//                 }
//             }

//             Console.WriteLine("Journal loaded from file successfully!");
//         }
//         else
//         {
//             Console.WriteLine("File not found. Please check the filename and try again.");
//         }
//     }
// }
