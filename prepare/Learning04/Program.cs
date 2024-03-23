using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Aderibigbe John", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Itunuoluwa Oluwaseun", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Samson Cole", "Politics", "Causes of poverty in Nigeria");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}