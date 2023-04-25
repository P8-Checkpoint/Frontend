using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompOff_App.Models;
using CompOff_App.Pages.Tabs;
using static CompOff_App.Models.Location;

namespace CompOff_App.Services.Impl;

class DataService : IDataService
{
    public DataService()
    {
        Console.WriteLine("Dataservice initialized \n");
    }
    //Create a lot of mockup data to test these methods on

    public User getcurrentuser() //TODO: possibly async?
    {
        User user = new("John", "staal", "staalanden");
        return user;
    }

    public List<Job> getjobs()
    {
        Job job1 = new("task1", "video rendering for new home video", "homevideo.mp4", "C:/User/homevideos");
        Job job2 = new("task2", "Machine learning algorithm, big data", "notavirus.exe", "C:/User/folder1");
        Job job3 = new("task3", "Deepfake learning", "deepfake", "C:/User/deeplearning");
        Job job4 = new("task4", "Autotuner for pitch correction", "autotune.exe", "C:/User/music/pitchcorrection");

        List<Job> joblist = new();
        joblist.Add(job1);
        joblist.Add (job2);
        joblist.Add (job3);
        joblist.Add (job4);

        return joblist;
    }

    public List<Models.Location> getlocations()
    {
        Models.Location Aalborg = new("trekanten", "C/images/logoaalborg.png", new Address("Sofiendahlsvej", "80", "Aalborg", "9220", "Denmark"));
        Models.Location Aarhus = new("Open Space", "C/images/logoaarhus.png", new Address("Olof palmes alle", "11", "Aarhus", "8200", "Denmark"));

        List<Models.Location> locationlist = new();
        locationlist.Add(Aalborg);
        locationlist.Add(Aarhus);

        return locationlist;
        
    }
}
