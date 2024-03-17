using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private string reference;
    private List<Word> words;
    private bool isComplete;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
        this.isComplete = false;
    }

    public string Reference => reference;

    public List<Word> Words => words;

    public bool IsComplete => isComplete;

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, words.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(0, words.Count);
            words[index].Hide();
            Console.WriteLine($"Hint: {words[index].Text}"); // Display a hint for the hidden word
        }

        if (words.All(word => !word.IsVisible))
        {
            isComplete = true;
            Console.WriteLine("Congratulations! You have successfully memorized the verse.");
        }
    }

    public void Display()
    {
        Console.WriteLine(reference);
        Console.WriteLine(string.Join(" ", words.Select(word => word.IsVisible ? word.Text : "_____")));
    }
}

public class Reference
{
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(int chapter, int startVerse)
    {
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = startVerse;
    }

    public Reference(int chapter, int startVerse, int endVerse)
    {
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public override string ToString()
    {
        if (startVerse == endVerse)
            return $"{chapter} {startVerse}";
        else
            return $"{chapter} {startVerse}-{endVerse}";
    }
}

public class Word
{
    private string text;
    private bool isVisible;

    public Word(string text)
    {
        this.text = text;
        this.isVisible = true;
    }

    public string Text => text;

    public bool IsVisible => isVisible;

    public void Hide()
    {
        isVisible = false;
    }
}

class Program
{
    static void Main()
    {
        // Ask the user for their preference
        Console.WriteLine("Enter 'b' for a scripture from the Bible or 'm' for a scripture from the Book of Mormon:");
        string preference = Console.ReadLine().ToLower();

        // Create a library of scriptures based on user preference
        List<Scripture> scriptures = new List<Scripture>();
        if (preference == "b")
        {
            scriptures.Add(new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."));
            scriptures.Add(new Scripture("Philippians 4:13", "I can do all things through him who strengthens me."));
            scriptures.Add(new Scripture("Isaiah 40:31", "But they who wait for the Lord shall renew their strength; they shall mount up with wings like eagles; they shall run and not be weary; they shall walk and not faint."));
            scriptures.Add(new Scripture("Psalm 23:1", "The Lord is my shepherd; I shall not want."));
            scriptures.Add(new Scripture("Romans 8:28", "And we know that for those who love God all things work together for good, for those who are called according to his purpose."));
        }
        else if (preference == "m")
        {
            scriptures.Add(new Scripture("1 Nephi 3:7", "I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));
            scriptures.Add(new Scripture("Alma 32:21", "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true."));
            scriptures.Add(new Scripture("3 Nephi 11:29", "For verily, verily, I say unto you, that he that hath the spirit of contention is not of me, but is of the devil, who is the father of contention, and he stirreth up the hearts of men to contend with anger, one with another."));
            scriptures.Add(new Scripture("Moroni 10:4", "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost."));
            scriptures.Add(new Scripture("Ether 12:27", "And if men come unto me I will show unto them their weakness. I give unto men weakness that they may be humble; and my grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, then will I make weak things become strong unto them."));
        }
        else
        {
            Console.WriteLine("Invalid input. Exiting program.");
            return;
        }

        // Present a random scripture to the user
        Random random = new Random();
        Scripture randomScripture = scriptures[random.Next(0, scriptures.Count)];
        randomScripture.Display();

        // Prompt the user to press Enter or type "quit"
        while (true)
        {
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;
            else
            {
                // Hide a few random words
                randomScripture.HideRandomWords();

                if (randomScripture.IsComplete)
                {
                    Console.WriteLine("Do you want to memorize another scripture?");
                    break;
                }

                // Clear the console and display the scripture again
                Console.Clear();
                randomScripture.Display();
            }
        }
    }
}
