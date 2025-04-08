using System;
using System.Collections.Generic;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn from this experience?",
        "How can you apply this in the future?"
    };

    public ReflectionActivity()
    {
        name = "Reflection Activity";
        description = "This activity will help you reflect on times you showed strength and resilience.";
    }

    public override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"\n{prompt}\n");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(5);
        }
    }
}
