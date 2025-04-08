using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ShowGoals();
                    break;
                case "3":
                    manager.ShowGoals();
                    Console.Write("Which goal did you accomplish? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoalEvent(index);
                    break;
                case "4":
                    manager.ShowScore();
                    break;
                case "5":
                    // Console.Write("Enter filename to save: ");
                    // manager.SaveGoals(Console.ReadLine());
                    manager.SaveGoals("goals.txt");
                    Console.WriteLine("Goals saved to goals.txt");
                    break;
                case "6":
                    // Console.Write("Enter filename to load: ");
                    // manager.LoadGoals(Console.ReadLine());
                    manager.LoadGoals("goals.txt");
                    Console.WriteLine("Goals loaded from goals.txt");
                    break;
                case "7":
                    running = false;
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("Select Goal Type: 1) Simple 2) Eternal 3) Checklist 4) Progress 5) Negative");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target Count: ");
                int count = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, points, count, bonus));
                break;
            case "4":
                Console.Write("Target Progress Count: ");
                int target = int.Parse(Console.ReadLine());
                manager.AddGoal(new ProgressGoal(name, desc, points, target));
                break;
            case "5":
                Console.Write("Penalty Points: ");
                int penalty = int.Parse(Console.ReadLine());
                manager.AddGoal(new NegativeGoal(name, desc, penalty));
                break;
        }
    }
}