using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompOff_App.Models;

namespace CompOff_App.Services.Impl;

public class DataService : IDataService
{
    private readonly List<Job> _jobs = new()
    {
        new("Home Video Render", "video rendering for new home video", "homevideo.mp4", "C:/User/homevideos")
        {
            DateAdded = new(2023, 4, 24),
            LastActivity = new(2023,4,25),
            Status = JobStatus.Cancelled
            
        },
        new("N-Beats", "Machine learning algorithm, big data", "notavirus.exe", "C:/User/folder1")
        {
            DateAdded = new(2023, 4, 22),
            LastActivity = new(2023, 4, 22),
            Status = JobStatus.Waiting
            
        },
        new("Neural Network", "Deepfake learning", "deepfake", "C:/User/deeplearning")
        {
            DateAdded = new(2023, 4, 21),
            LastActivity = new(2023, 4, 24),
            Status = JobStatus.InQueue
        },
        new("Auto Tuner but this name is way too long to fit on the page so i hope that my truncation truly works", "Autotuner for pitch correction", "autotune.exe", "C:/User/music/pitchcorrection")
        {
            DateAdded = new(2023, 4, 25),
            LastActivity = new(2023, 4, 26)
        }
    };
    private readonly User _user = new("John", "staal", "staalanden");
    private readonly List<Models.Location> _locations = new()
    {
        new("Trekanten", "C/images/logoaalborg.png", new Address("Sofiendahlsvej", "80", "Aalborg", "9220", "Denmark")),
        new("Open Space", "C/images/logoaarhus.png", new Address("Olof palmes alle", "11", "Aarhus", "8200", "Denmark"))
    };

    public DataService()
    {
        Console.WriteLine("Dataservice initialized \n");
    }
    //Create a lot of mockup data to test these methods on

    public async Task<User> GetCurrentUserAsync() //TODO: possibly async?
    {
        await Task.CompletedTask;
        return _user;
    }

    public async Task<IEnumerable<Job>> GetJobsAsync()
    {
        await Task.CompletedTask;
        return _jobs;
    }

    public async Task<IEnumerable<Models.Location>> GetLocationsAsync()
    {
        await Task.CompletedTask;
        return _locations;
    }
}
