class ReflectionActivity : Activity
{
    public override void StartActivity()
    {
        // Define prompts and questions for reflection activity
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            // Add more prompts as needed
        };

        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            // Add more questions as needed
        };

        CommonStartingMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random random = new Random();
        int remainingTime = duration;
        while (remainingTime > 0)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(4000); // Pause for 4 seconds
            }

            remainingTime -= 10; // Each reflection cycle takes 10 seconds
        }

        CommonEndingMessage("Reflection Activity");
    }
}

class ListingActivity : Activity
{
    public override void StartActivity()
    {
        // Define prompts for listing activity
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            // Add more prompts as needed
        };

        CommonStartingMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("You have 10 seconds to start listing...");
        Thread.Sleep(10000); // Pause for 10 seconds

        Console.WriteLine("Enter each item and press Enter. Press Enter again to finish.");

        int count = 0;
        string input;
        do
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                count++;
            }
        } while (!string.IsNullOrWhiteSpace(input));

        Console.WriteLine($"You listed {count} items.");

        CommonEndingMessage("Listing Activity");
    }
}
