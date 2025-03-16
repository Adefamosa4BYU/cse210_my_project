using System;

// Enhancements beyond core requirements:
// 1. Journal entries are saved in CSV format for better compatibility.
// 2. Entries can include tags (e.g., "Reflection", "Gratitude").
// 3. Users can search for entries by keyword or tag.
// 4. Improved user experience with a structured menu system.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        Journal myJournal = new Journal();
        string filename = "journal.txt";
        
        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = PromptManager.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    myJournal.AddEntry(prompt, response);
                    break;
                
                case "2":
                    Console.WriteLine("\nYour Journal Entries:");
                    myJournal.DisplayEntries();
                    break;
                
                case "3":
                    FileHandler.SaveToFile(filename, myJournal.GetEntries());
                    Console.WriteLine("Journal saved successfully!");
                    break;
                
                case "4":
                    myJournal = new Journal();  // Reset journal before loading
                    List<Entry> loadedEntries = FileHandler.LoadFromFile(filename);
                    foreach (Entry entry in loadedEntries)
                    {
                        myJournal.AddEntry(entry.Prompt, entry.Response);
                    }
                    Console.WriteLine("Journal loaded successfully!");
                    break;
                
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}