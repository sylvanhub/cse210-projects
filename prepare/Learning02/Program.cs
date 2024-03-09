using System;
using System.Collections.Generic;

class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;
}

class Resume
{
    public string _name;
    public List<Job> _jobs;

    public Resume()
    {
        _jobs = new List<Job>();
    }

    public void Display()
    {
        Console.WriteLine("Resume of: " + _name);
        Console.WriteLine("Experience:");

        foreach (var job in _jobs)
        {
            Console.WriteLine("Job Title: " + job._jobTitle);
            Console.WriteLine("Company: " + job._company);
            Console.WriteLine("Years: " + job._startYear + " - " + job._endYear);
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Hair Stylist";
        job1._company = "Pearl's Touch UNisex Salon";
        job1._startYear = 2010;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._jobTitle = "Agric Engineer";
        job2._company = "Zartech Farm Limited";
        job2._startYear = 2023;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Bernard Adejumoke";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
