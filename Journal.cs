using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void WriteEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Random Prompt: {prompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        DateTime date = DateTime.Now;
        Entry entry = new Entry(date, prompt, response);
        _entries.Add(entry);
        Console.WriteLine("Entry saved successfully!");
    }

    public void DisplayJournal()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine($"\nDate: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save (JSON format): ");
        string filename = Console.ReadLine();

        try
        {
            List<Entry> existingEntries;

            if (File.Exists(filename))
            {
                // If the file exists, load the existing entries
                string existingJson = File.ReadAllText(filename);
                existingEntries = JsonConvert.DeserializeObject<List<Entry>>(existingJson);
            }
            else
            {
                // If the file doesn't exist, create an empty list
                existingEntries = new List<Entry>();
            }

            // Add new entries to the existing list
            existingEntries.AddRange(_entries);

            // Save the combined list back to the file
            string updatedJson = JsonConvert.SerializeObject(existingEntries, Formatting.Indented);
            File.WriteAllText(filename, updatedJson);

            Console.WriteLine($"Journal saved to {filename} (JSON format)");
        }
        catch (IOException)
        {
            Console.WriteLine("Error saving the journal to the file. Please check the filename and try again.");
        }
    }

public void SaveToTextFile()
    {
        Console.Write("Enter filename to save (Text format): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"Date: {entry.Date}");
                    writer.WriteLine($"Prompt: {entry.Prompt}");
                    writer.WriteLine($"Response: {entry.Response}");
                    writer.WriteLine(); // Add an empty line between entries
                }
            }

            Console.WriteLine($"Journal saved to {filename} (Text format)");
        }
        catch (IOException)
        {
            Console.WriteLine("Error saving the journal to the file. Please check the filename and try again.");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        try
        {
            if (Path.GetExtension(filename).Equals(".json", StringComparison.OrdinalIgnoreCase))
            {
                string json = File.ReadAllText(filename);
                _entries = JsonConvert.DeserializeObject<List<Entry>>(json);
                Console.WriteLine($"Journal loaded from {filename} (JSON format)");
            }
            else
            {
                LoadFromTextFile(filename);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Please check the filename.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the journal: {ex.Message}");
        }
    }

    private void LoadFromTextFile(string filename)
    {
        try
        {
            _entries.Clear(); // Clear existing entries before loading from text file

            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    DateTime date;
                    string prompt;
                    string response;

                    // Assuming the file format is consistent with Date, Prompt, Response
                    // You may need to adjust this parsing logic based on your actual file format

                    if (DateTime.TryParseExact(reader.ReadLine()?.Substring(6), "M/d/yyyy h:mm:ss tt", null, System.Globalization.DateTimeStyles.None, out date)
                        && (prompt = reader.ReadLine()?.Substring(8)) != null
                        && (response = reader.ReadLine()?.Substring(10)) != null)
                    {
                        _entries.Add(new Entry(date, prompt, response));
                    }

                    // Skip the empty line between entries
                    reader.ReadLine();
                }
            }

            Console.WriteLine($"Journal loaded from {filename} (Text format)");
        }
        catch (IOException)
        {
            Console.WriteLine("Error loading the journal from the file. Please check the filename and try again.");
        }
    }

    private string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Random random = new Random();
        return prompts[random.Next(prompts.Count)];
    }
}