using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        name = "Breathing Activity";
        description = "This activity will help you relax by guiding you through slow breathing.";
    }

    public override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);
            Console.Write("\nBreathe out... ");
            ShowCountdown(6);
        }
    }
}
