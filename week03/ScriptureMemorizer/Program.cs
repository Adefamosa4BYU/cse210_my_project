// The program supports multiple scriptures and selects one randomly.
// Only words that are not already hidden will be hidden (ensuring a better memorization experience).
// I exceded the requirement by having the program to load scriptures from a files.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        // Load scriptures from a file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found. Please check the file.");
            return;
        }

        // Select a random scripture
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsFullyHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 words at a time
        }

        Console.Clear();
        scripture.Display();
        Console.WriteLine("\nAll words are hidden. Memorization complete!");
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|'); // Using '|' as a separator

                if (parts.Length != 2)
                {
                    Console.WriteLine($"Skipping invalid line: {line}");
                    continue;
                }

                string referenceText = parts[0].Trim();
                string verseText = parts[1].Trim();

                Reference reference = ParseReference(referenceText);
                scriptures.Add(new Scripture(reference, verseText));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return scriptures;

    }

    static Reference ParseReference(string refText)
    {
        string[] parts = refText.Split(' ', 2); // Ensure book names with spaces are handled
        if (parts.Length < 2)
        {
            throw new FormatException($"Invalid reference format: {refText}");
        }

        string book = parts[0];
        string[] chapterVerse = parts[1].Split(':'); // Separate chapter from verse(s)
        int chapter = int.Parse(chapterVerse[0]);

        string[] verses = chapterVerse[1].Split('-'); // Handle verse range
        int startVerse = int.Parse(verses[0]);
        int? endVerse = (verses.Length > 1) ? int.Parse(verses[1]) : (int?)null;

        return new Reference(book, chapter, startVerse, endVerse);
    }
}
