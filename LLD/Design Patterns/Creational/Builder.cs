using System;
using System.Collections.Generic;

class BackgroundJob
{
    public string Name { get; }
    public DateTime StartTime { get; }
    public List<int> Payload { get; }

    private BackgroundJob(string name, DateTime startTime, List<int> payload)
    {
        this.Name = name;
        this.StartTime = startTime;
        this.Payload = payload;
    }

    public class Builder
    {
        private string name;
        private DateTime startTime;
        private List<int> payload;

        public Builder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public Builder SetStartTime(DateTime time)
        {
            this.startTime = time;
            return this;
        }

        public Builder SetPayload(List<int> payload)
        {
            this.payload = payload;
            return this;
        }

        public BackgroundJob Build()
        {
            return new BackgroundJob(name, startTime, payload);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var backgroundJob = new BackgroundJob.Builder()
                            .SetName("Hi")
                            .SetStartTime(DateTime.Now)
                            .SetPayload(new List<int> { 1, 2, 3 })
                            .Build();

        Console.WriteLine($"Name: {backgroundJob.Name}");
        Console.WriteLine($"StartTime: {backgroundJob.StartTime}");
        Console.WriteLine($"Payload: {string.Join(", ", backgroundJob.Payload)}");
    }
}
