using System;
using System.Collections.Generic;

public class PromptManager
{
    private static List<string> prompts = new List<string>
    {
        "What made you smile today?",
        "Describe a challenge you faced today.",
        "What are you grateful for today?",
        "Write about a recent success.",
        "If you could relive one moment today, what would it be?"
    };

    private static Random random = new Random();

    public static string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
