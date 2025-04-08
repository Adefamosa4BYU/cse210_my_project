using System;
using System.Collections.Generic;

public class VisualizationActivity : MindfulnessActivity
{
    private List<string> scenes = new List<string>
    {
        "Imagine you're walking through a peaceful forest, the sun filtering through the trees...",
        "Visualize yourself lying on a quiet beach, waves gently crashing around you...",
        "Picture being at the top of a mountain, breathing in the crisp, cool air...",
        "See yourself floating in a calm lake, completely weightless and free..."
    };

    public VisualizationActivity()
    {
        name = "Visualization Activity";
        description = "This activity guides you to visualize calming and peaceful scenes to help clear your mind.";
    }

    public override void PerformActivity()
    {
        Console.WriteLine($"\n{name}: {description}");
        ShowSpinner(3);

        Random rand = new Random();
        string scene = scenes[rand.Next(scenes.Count)];
        Console.WriteLine($"\nScene: {scene}");
        ShowSpinner(4);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\nFocus on the scene and take deep breaths...");
            ShowSpinner(5);
        }

        Console.WriteLine("\nWell done! You’ve completed the Visualization Activity.");
        ShowSpinner(3);
    }
}

