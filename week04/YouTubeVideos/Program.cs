using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

         List<Video> videos = new List<Video>();

        // Create videos and add comments
        Video video1 = new Video("Introduction to C#", "Tech Guru", 600);
        video1.AddComment("Alice", "Great explanation!");
        video1.AddComment("Bob", "Very helpful, thanks!");
        video1.AddComment("Charlie", "Can you cover more on classes?");

        Video video2 = new Video("Object-Oriented Programming", "Code Master", 900);
        video2.AddComment("Dave", "Best OOP tutorial I've seen!");
        video2.AddComment("Eve", "Clear and concise.");
        video2.AddComment("Frank", "Loved the real-world examples!");

        Video video3 = new Video("Advanced C# Techniques", "Dev Pro", 1200);
        video3.AddComment("Grace", "This is a game-changer!");
        video3.AddComment("Hank", "I finally understand delegates!");
        video3.AddComment("Ivy", "Waiting for the next part.");

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video details and comments
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
