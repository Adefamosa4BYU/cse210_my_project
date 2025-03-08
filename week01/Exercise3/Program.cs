using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        // Generate a random magic number between 1 and 100
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int guess = 0;

        Console.WriteLine("Welcome to Guess My Number!");

        // Loop until the user guesses correctly
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess )
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}