using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // ---------------- VIDEO 1 ----------------
        Video v1 = new Video("The Power of Clean Code", "Brigham Essien", 480);
        v1.AddComment(new Comment("Kwame", "This video really helped me!"));
        v1.AddComment(new Comment("Sarah", "Very clear explanation."));
        v1.AddComment(new Comment("Daniel", "Thanks for sharing!"));
        videos.Add(v1);

        // ---------------- VIDEO 2 ----------------
        Video v2 = new Video("C# Classes Explained", "CodeAcademy GH", 620);
        v2.AddComment(new Comment("Ama", "Now I understand classes!"));
        v2.AddComment(new Comment("Michael", "Great teaching."));
        v2.AddComment(new Comment("Linda", "Helpful examples."));
        videos.Add(v2);

        // ---------------- VIDEO 3 ----------------
        Video v3 = new Video("Learn Abstraction in 5 Minutes", "TechGhana", 300);
        v3.AddComment(new Comment("Nana", "Short and straight to the point."));
        v3.AddComment(new Comment("Joseph", "Really helpful for my homework."));
        v3.AddComment(new Comment("Kofi", "Make more of these!"));
        videos.Add(v3);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
    
}