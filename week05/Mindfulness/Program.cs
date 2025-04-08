using System;

// Exceeds core requirements by adding a new Visualization Activity..

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        Dictionary<string, int> activityLog = new Dictionary<string, int>()
        {
            { "Breathing", 0 },
            { "Reflection", 0 },
            { "Listing", 0 },
            { "Visualization", 0 }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Visualization Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            MindfulnessActivity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => new VisualizationActivity(),
                "5" => null,
                _ => null
            };

            if (choice == "5" || activity == null) break;

            activity.StartActivity();
        }
    }
}
