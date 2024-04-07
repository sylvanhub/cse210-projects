using System;

public class Program
{
    static void Main()
    {
        // Welcome message and ask for name
        Console.WriteLine("Welcome to the Student Union Election Voting System!"); 
        Console.Write(" Please enter your name: ");
        string name = Console.ReadLine();

        // Personalized welcoming message
        Console.WriteLine($"Hello, {name}! Welcome to the voting system.");

        // Ask for department and matriculation number
        Console.Write("Enter your department: ");
        string department = Console.ReadLine();

        Console.Write("Enter your matriculation number: ");
        string matriculationNumber = Console.ReadLine();

        // Provide list of seats to be voted for
        Console.WriteLine("Please enter your votes for the following positions:");
        string[] positions = {
            "SUG President",
            "Vice President",
            "General Secretary",
            "Financial Secretary",
            "PRO",
            "Speaker",
            "Sport Director 1",
            "Sport Director 2",
            "Social Director 1",
            "Social Director 2",
            "Welfare Director 1",
            "Welfare Director 2",
            "Auditor 1",
            "Auditor 2"
        };

        // Ask for votes and store them in a dictionary
        var votes = new Dictionary<string, string>();
        foreach (var position in positions)
        {
            Console.Write($"Enter your vote for {position}: ");
            string candidate = Console.ReadLine();
            votes[position] = candidate;
        }

        // Ask for SUG payment receipt code
        Console.Write("Enter the code from your SUG payment receipt: ");
        string receiptCode = Console.ReadLine();

        // Print voting choices for review and allow edits
        Console.WriteLine("\nReview Your Votes:");
        foreach (var kvp in votes)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        Console.Write("Do you want to make any changes? (yes/no): ");
        string editChoice = Console.ReadLine();

        if (editChoice.ToLower() == "yes")
        {
            // Allow edits
            foreach (var position in positions)
            {
                Console.Write($"Enter your revised vote for {position}: ");
                string revisedCandidate = Console.ReadLine();
                votes[position] = revisedCandidate;
            }
        }

        // Voting submission confirmation
        Console.WriteLine("\nYour voting has been recorded successfully.");
        Console.WriteLine("Thank you for exercising your student right.");
        Console.WriteLine("Your vote is your power and your voice, and it counts.");

        Console.ReadLine(); // Keep the console window open
    }
}
