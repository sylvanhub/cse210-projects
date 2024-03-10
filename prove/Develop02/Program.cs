using System;
using System.Collections.Generic;
using System.IO;
using System.Timers; // Add the namespace for System.Timers.Timer

class DailyJournal
{
    static void Main(string[] args)
    {
        JournalManager journalManager = new JournalManager();

        // Set up a reminder timer
        System.Timers.Timer reminderTimer = new System.Timers.Timer(); // Specify the full namespace
        reminderTimer.Interval = TimeSpan.FromHours(24).TotalMilliseconds; // Remind once a day
        reminderTimer.Elapsed += (sender, e) => journalManager.RemindToWrite();
        reminderTimer.Start();

        // Display menu
        journalManager.DisplayMenu();

        // Stop the timer when the program exits
        reminderTimer.Stop();
    }
}

class JournalManager
{
    private List<Entry> journalEntries = new List<Entry>();
    private const string journalFilePath = "journal.txt";

    public void DisplayMenu()
    {
        bool exit = false;

        do
        {
            Console.WriteLine("Daily Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Please enter your choice: ");

            switch (Console.ReadLine())
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (!exit);
    }

    public void WriteNewEntry()
    {
        Entry newEntry = new Entry();
        newEntry.WriteEntry();
        journalEntries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (Entry entry in journalEntries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveJournalToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(journalFilePath))
            {
                foreach (Entry entry in journalEntries)
                {
                    entry.SaveEntryToFile(writer);
                }
            }

            Console.WriteLine("Journal saved to file: " + journalFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving journal to file: " + ex.Message);
        }
    }

    public void LoadJournalFromFile()
    {
        try
        {
            List<Entry> loadedEntries = new List<Entry>();
            using (StreamReader reader = new StreamReader(journalFilePath))
            {
                while (!reader.EndOfStream)
                {
                    Entry loadedEntry = new Entry();
                    loadedEntry.LoadEntryFromFile(reader);
                    loadedEntries.Add(loadedEntry);
                }
            }

            journalEntries = loadedEntries;
            Console.WriteLine("Journal loaded from file: " + journalFilePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading journal from file: " + ex.Message);
        }
    }

    public void RemindToWrite()
    {
        Console.WriteLine("Reminder: Don't forget to write in your journal today!");
    }
}

class Entry
{
    private DateTime date;
    private string prompt;
    private string response;

    public Entry() { }

    public Entry(DateTime date, string prompt, string response)
    {
        this.date = date;
        this.prompt = prompt;
        this.response = response;
    }

    public void WriteEntry()
    {
        Console.Write("Enter date (MM/dd/yyyy): ");
        date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter prompt: ");
        prompt = Console.ReadLine();

        Console.Write("Enter response: ");
        response = Console.ReadLine();
    }

    public void DisplayEntry()
    {
        Console.WriteLine("Date: " + date.ToShortDateString());
        Console.WriteLine("Prompt: " + prompt);
        Console.WriteLine("Response: " + response);
        Console.WriteLine();
    }

    public void SaveEntryToFile(StreamWriter writer)
    {
        writer.WriteLine("Date: " + date.ToShortDateString());
        writer.WriteLine("Prompt: " + prompt);
        writer.WriteLine("Response: " + response);
        writer.WriteLine();
    }

    public void LoadEntryFromFile(StreamReader reader)
    {
        string dateLine = reader.ReadLine();
        string promptLine = reader.ReadLine();
        string responseLine = reader.ReadLine();

        if (dateLine != null && promptLine != null && responseLine != null)
        {
            // Read empty line
            reader.ReadLine();

            date = DateTime.Parse(dateLine.Substring(6)); // Extract date
            prompt = promptLine.Substring(8); // Extract prompt
            response = responseLine.Substring(10); // Extract response
        }
    }
}
