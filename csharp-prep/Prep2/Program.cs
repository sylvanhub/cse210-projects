using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (+, -, or none) for A grades
        string sign = "";
        if (letter == "A")
        {
            if (percent >= 97)
            {
                sign = "";
            }
            else if (percent <= 93)
            {
                sign = "-";
            }
        }
        else
        {
            // Determine the sign (+, -, or none) for other grades
            int lastDigit = percent % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Display both the grade letter and the sign
        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >= 70)
        {
            Console.WriteLine(" Congratulations, You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time! you can do better and be better" );
        }
    }
}
