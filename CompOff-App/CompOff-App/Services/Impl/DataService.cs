using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CompOff_App.DTOs;
using CompOff_App.Models;
using CompOff_App.Shared;
using CompOff_App.Wrappers;

namespace CompOff_App.Services.Impl;

public class DataService : IDataService
{
    private List<Job> _jobs = new()
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
    private List<Models.Location> _locations = new()
    {
        new("Trekanten Makerspace", "Resources/Images/Sample.jpg", new Address("Sofiendahlsvej", "80", "Aalborg", "9220", "Denmark")),
        new("Open Space Aarhus", "Resources/Images/Sample.jpg", new Address("Olof palmes alle", "11", "Aarhus", "8200", "Denmark")),
        new("Teck-Teket Makerspace","Resources/Images/Sample.jpg", new Address("Banegårdspladsen", "1", "Ballerup", "2750", "Denmark")),
        new("Silkeborg Makerspace","Resources/Images/Sample.jpg", new Address("Hostrupsgade", "41 A", "Silkeborg", "8600", "Denmark")),

    };
    private readonly INavigationWrapper _navigator;
    private readonly IConnectionService connectionService;

    public DataService(INavigationWrapper navigator )
    {
        _navigator = navigator;
    }
    //Create a lot of mockup data to test these methods on

    public async Task<User> GetCurrentUserAsync()
    {
        var userDtoString = await SecureStorage.GetAsync(StorageKeys.UserKey);
        if (userDtoString == null)
        {
            return null;
        }
        var userDto = JsonSerializer.Deserialize<UserDto>(userDtoString);
        return new User(userDto);
        
    }

    public async Task<IEnumerable<Job>> GetJobsAsync()
    {
        await Task.CompletedTask;
        return _jobs.Select(x => new Job(x)) ;
    }

    public async Task<IEnumerable<Models.Location>> GetLocationsAsync()
    {
        await Task.CompletedTask;
        return _locations;
    }

    public async Task<Job> GetJobByIdAsync(Guid id)
    {
        await Task.CompletedTask;
        return new Job (_jobs.Where(x => x.JobID == id).FirstOrDefault());
    }

    public async Task UpdateJobAsync(Guid id, string name, JobStatus status, string description)
    {
        var job = _jobs.FirstOrDefault(x => x.JobID == id);
        if (job != null)
        {
            job.JobName = name;
            job.Status = status;
            job.Description = description;
        }
        await Task.CompletedTask;
    }

    public async Task AddJobAsync(Job job)
    {
        if (_jobs.Where(x => x.JobID == job.JobID).Any())
            return;

        _jobs.Add(new(job));
        await Task.CompletedTask;
    }

    public async Task ClearDataAndLogout()
    {
        SecureStorage.RemoveAll();
        await _navigator.RouteAndReplaceStackAsync(NavigationKeys.LandingPage);
    }
}
