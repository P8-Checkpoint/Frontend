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
    private List<Models.Location> _locations = new()
    {
        new("Trekanten Makerspace", "Resources/Images/Sample.jpg", new Address("Sofiendahlsvej", "80", "Aalborg", "9220", "Denmark")),
        new("Open Space Aarhus", "Resources/Images/Sample.jpg", new Address("Olof palmes alle", "11", "Aarhus", "8200", "Denmark")),
        new("Teck-Teket Makerspace","Resources/Images/Sample.jpg", new Address("Banegårdspladsen", "1", "Ballerup", "2750", "Denmark")),
        new("Silkeborg Makerspace","Resources/Images/Sample.jpg", new Address("Hostrupsgade", "41 A", "Silkeborg", "8600", "Denmark")),

    };
    private readonly INavigationWrapper _navigator;
    private readonly IConnectionService _connectionService;

    public DataService(INavigationWrapper navigator, IConnectionService connectionService)
    {
        _navigator = navigator;
        _connectionService = connectionService;
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
        return await _connectionService.GetJobsAsync();
    }

    public async Task<IEnumerable<Models.Location>> GetLocationsAsync()
    {
        await Task.CompletedTask;
        return _locations;
    }

    public async Task<Job> GetJobByIdAsync(Guid id)
    {
        return await _connectionService.GetJobByIdAsync(id);
    }

    public async Task UpdateJobAsync(Job job)
    {
        await _connectionService.UpdateJobAsync(job);
    }

    public async Task AddJobAsync(string name, string description)
    {
        await _connectionService.CreateJobAsync(name, description);
    }

    public async Task ClearDataAndLogout()
    {
        SecureStorage.RemoveAll();
        await _navigator.RouteAndReplaceStackAsync(NavigationKeys.LandingPage);
    }
}
