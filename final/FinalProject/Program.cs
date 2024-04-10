using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; set; }
    public string Department { get; set; }
    public string MatriculationNumber { get; set; }
}

public class VotingSystemBase
{
    protected Dictionary<string, string> Votes { get; set; }
    protected string[] Positions { get; set; }

    public VotingSystemBase()
    {
        Votes = new Dictionary<string, string>();
        Positions = new string[]
        {
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
    }

    protected void RecordVotes()
    {
        foreach (var position in Positions)
        {
            Console.Write($"Enter your vote for {position}: ");
            string candidate = Console.ReadLine();
            Votes[position] = candidate;
        }
    }

    protected void ReviewAndEditVotes()
    {
        Console.WriteLine("\nReview Your Votes:");
        foreach (var kvp in Votes)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }

        Console.Write("Do you want to make any changes? (yes/no): ");
        string editChoice = Console.ReadLine();

        if (editChoice.ToLower() == "yes")
        {
            foreach (var position in Positions)
            {
                Console.Write($"Enter your revised vote for {position}: ");
                string revisedCandidate = Console.ReadLine();
                Votes[position] = revisedCandidate;
            }
        }
    }

    protected void PrintConfirmationMessage()
    {
        Console.WriteLine("\nYour voting has been recorded successfully.");
        Console.WriteLine("Thank you for exercising your student right.");
        Console.WriteLine("Your vote is your power and your voice, and it counts.");
    }

    protected virtual bool ValidateReceiptCode(string code)
    {
        if (int.TryParse(code, out int receiptCode))
        {
            if (receiptCode >= 1 && receiptCode <= 20)
            {
                return true;
            }
        }

        Console.WriteLine("Invalid code. Please enter a code(refrence written on the left of the receipt).");
        return false;
    }

    protected string EnterReceiptCode()
    {
        string receiptCode;
        do
        {
            Console.Write("Enter the code from your SUG payment receipt: ");
            receiptCode = Console.ReadLine();
        } while (!ValidateReceiptCode(receiptCode));

        return receiptCode;
    }
}

public class VotingSystem : VotingSystemBase
{
    public Student StudentInfo { get; set; }

    public void RunVotingSystem()
    {
        Console.WriteLine("Welcome to the Student Union Election Voting System!");

        StudentInfo = new Student();
        Console.Write(" Please enter your name: ");
        StudentInfo.Name = Console.ReadLine();

        Console.Write("Enter your department: ");
        StudentInfo.Department = Console.ReadLine();

        Console.Write("Enter your matriculation number: ");
        StudentInfo.MatriculationNumber = Console.ReadLine();

        RecordVotes();
        ReviewAndEditVotes();

        string receiptCode = EnterReceiptCode(); // Ask for the receipt code

        if (receiptCode != null) // Check if receipt code is valid before submission
        {
            // Additional logic for submission using the receipt code if needed
            PrintConfirmationMessage();
        }

        Console.ReadLine(); // Keep the console window open
    }
}

public class Program
{
    static void Main()
    {
        VotingSystem votingSystem = new VotingSystem();
        votingSystem.RunVotingSystem();
    }
}
