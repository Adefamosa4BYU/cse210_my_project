// The program supports multiple scriptures and selects one randomly.
// Only words that are not already hidden will be hidden (ensuring a better memorization experience).
// Add multiple scripture

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        // Scripture list (you can load from a file to exceed requirements)
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
            new Scripture(new Reference("Romans", 8, 28), "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."),
            new Scripture(new Reference("Isaiah", 41, 10), "Fear thou not; for I am with thee: be not dismayed; for I am thy God: I will strengthen thee; yea, I will help thee; yea, I will uphold thee with the right hand of my righteousness."),
            new Scripture(new Reference("Psalm", 23, 1, 2), "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters."),
            new Scripture(new Reference("2 Timothy", 1, 7), "For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind."),
            new Scripture(new Reference("Joshua", 1, 9), "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest.")
        };

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
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        return _endVerse == null ? $"{_book} {_chapter}:{_startVerse}" : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public override string ToString()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{_reference}\n");
        Console.WriteLine(string.Join(" ", _words));
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        if (visibleWords.Count == 0)
            return;
        
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
