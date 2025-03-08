using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("Enter a figure ");
        string userInput = Console.ReadLine();
        int number = int.Parse(userInput);

        string letter;

        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (number >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard and try again next time.");
        }
    }
}