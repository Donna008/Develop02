using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\n1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                // Exceeding Requirements:Save or load your document to a database or use a different library or format such as JSON for storage.
                    Console.WriteLine("1. Save to JSON file");
                    Console.WriteLine("2. Save to Text file");
                    Console.Write("Enter your choice (1-2): ");
                    string saveChoice = Console.ReadLine();
                                        if (saveChoice == "1")
                    {
                        journal.SaveToFile();
                    }
                    else if (saveChoice == "2")
                    {
                        journal.SaveToTextFile();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    }
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}