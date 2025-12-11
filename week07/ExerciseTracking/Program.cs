using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<Activity> activities = new List<Activity>();

        activities.Add(new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0));     
        activities.Add(new RunningActivity(new DateTime(2022, 11, 4), 30, 4.8));     
        activities.Add(new CyclingActivity(new DateTime(2022, 11, 5), 45, 15.0));     
        activities.Add(new SwimmingActivity(new DateTime(2022, 11, 6), 30, 40));      

        // Display summary for each activity using polymorphism
        Console.WriteLine("Exercise Summary\n");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}