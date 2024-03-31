using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Base class for all goals
public abstract class Goal
{
    protected int value;
    protected bool completed;

    // Constructor
    public Goal(int value)
    {
        this.value = value;
        this.completed = false;
    }

    // Abstract method to record an event (accomplishment of the goal)
    public abstract void RecordEvent();

    // Abstract method to get details of the goal
    public abstract string GetDetailsString();

    // Getter for the goal value
    public int GetValue() => value;

    // Getter and setter for completed status
    public bool IsCompleted() => completed;
    public void SetCompleted(bool status) => completed = status;
}

// Simple goal class (inherits from Goal)
public class SimpleGoal : Goal
{
    // Constructor
    public SimpleGoal(int value) : base(value) { }

    // Implementation of RecordEvent method
    public override void RecordEvent()
    {
        Console.WriteLine("Simple goal completed!");
        completed = true;
    }

    // Implementation of GetDetailsString method
    public override string GetDetailsString()
    {
        return $"Simple Goal Details (Completed: {completed})";
    }
}

// Eternal goal class (inherits from Goal)
public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(int value) : base(value) { }

    // Implementation of RecordEvent method
    public override void RecordEvent()
    {
        Console.WriteLine("Eternal goal recorded!");
        value += 100; // Increase value each time recorded
    }

    // Implementation of GetDetailsString method
    public override string GetDetailsString()
    {
        return $"Eternal Goal Details (Value: {value})";
    }
}

// Checklist goal class (inherits from Goal)
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int completedCount;

    // Constructor
    public ChecklistGoal(int value, int targetCount) : base(value)
    {
        this.targetCount = targetCount;
        this.completedCount = 0;
    }

    // Implementation of RecordEvent method
    public override void RecordEvent()
    {
        completedCount++;

        if (completedCount >= targetCount)
        {
            Console.WriteLine("Checklist goal completed!");
            value += 500; // Bonus points upon completion
            completed = true;
        }
        else
        {
            Console.WriteLine("Checklist goal progress: {0}/{1}", completedCount, targetCount);
        }
    }

    // Implementation of GetDetailsString method
    public override string GetDetailsString()
    {
        return $"Checklist Goal Details (Completed {completedCount}/{targetCount} times)";
    }
}

// Program class for testing
class Program
{
    static void Main()
    {
        // Load goals from saved data (if available)
        List<Goal> goals = LoadGoals();

        // If no saved data, create new goals
        if (goals.Count == 0)
        {
            Goal simpleGoal = new SimpleGoal(1000);
            Goal eternalGoal = new EternalGoal(100);
            Goal checklistGoal = new ChecklistGoal(50, 10);

            goals.AddRange(new Goal[] { simpleGoal, eternalGoal, checklistGoal });
        }

        // User interface loop
        while (true)
        {
            Console.WriteLine("1. Record Event");
            Console.WriteLine("2. View Goals");
            Console.WriteLine("3. Add New Goal");
            Console.WriteLine("4. Save and Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RecordEvent(goals);
                    break;
                case "2":
                    ViewGoals(goals);
                    break;
                case "3":
                    AddNewGoal(goals);
                    break;
                case "4":
                    SaveGoals(goals);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void RecordEvent(List<Goal> goals)
    {
        Console.WriteLine("Enter the index of the goal you accomplished:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
        {
            goals[index - 1].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid index. Please try again.");
        }
    }

    static void ViewGoals(List<Goal> goals)
    {
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    static void AddNewGoal(List<Goal> goals)
    {
        Console.WriteLine("Enter the type of goal (1. Simple, 2. Eternal, 3. Checklist):");
        if (int.TryParse(Console.ReadLine(), out int typeChoice))
        {
            switch (typeChoice)
            {
                case 1:
                    Console.WriteLine("Enter the value for the simple goal:");
                    if (int.TryParse(Console.ReadLine(), out int simpleValue))
                    {
                        goals.Add(new SimpleGoal(simpleValue));
                        Console.WriteLine("Simple goal added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid value. Simple goal not added.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the value for the eternal goal:");
                    if (int.TryParse(Console.ReadLine(), out int eternalValue))
                    {
                        goals.Add(new EternalGoal(eternalValue));
                        Console.WriteLine("Eternal goal added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid value. Eternal goal not added.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the value for the checklist goal:");
                    if (int.TryParse(Console.ReadLine(), out int checklistValue))
                    {
                        Console.WriteLine("Enter the target count for the checklist goal:");
                        if (int.TryParse(Console.ReadLine(), out int targetCount))
                        {
                            goals.Add(new ChecklistGoal(checklistValue, targetCount));
                            Console.WriteLine("Checklist goal added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid target count. Checklist goal not added.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid value. Checklist goal not added.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not added.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Goal not added.");
        }
    }

    static void SaveGoals(List<Goal> goals)
    {
        string json = JsonSerializer.Serialize(goals);
        File.WriteAllText("goals.json", json);
        Console.WriteLine("Goals saved successfully.");
    }

    static List<Goal> LoadGoals()
    {
        List<Goal> goals = new List<Goal>();
        if (File.Exists("goals.json"))
        {
            string json = File.ReadAllText("goals.json");
            goals = JsonSerializer.Deserialize<List<Goal>>(json);
        }
        return goals;
    }
}
