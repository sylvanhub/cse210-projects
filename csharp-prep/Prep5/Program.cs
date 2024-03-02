using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squareOfNumber = SquareNumber(userNumber);
        DisplayResult(userName, squareOfNumber);
    }


    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }


    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }


    static int PromptUserNumber()
    {
        Console.Write("What is your favourite number? ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }


    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }


    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}