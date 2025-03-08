using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

         List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Collect numbers from the user
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);
        
        // Compute the sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");
        
        // Compute the average
        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;
        Console.WriteLine($"The average is: {average}");
        
        // Find the maximum number
        int maxNumber = numbers.Count > 0 ? numbers[0] : 0;
        foreach (int num in numbers)
        {
            if (num > maxNumber)
            {
                maxNumber = num;
            }
        }
        Console.WriteLine($"The largest number is: {maxNumber}");
    }
}