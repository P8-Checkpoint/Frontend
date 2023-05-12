using CompOff_App.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CompOff_App.Shared;
using CompOff_App.Services;
using Shared.Common;
using CompOff_App.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CompOff_App.Templates;

namespace CompOff_App.Viewmodels.Tabs;

public partial class OverviewPageViewModel : BaseViewModel
{
    private readonly INavigationWrapper _navigator;
    private readonly IDataService _dataService;

    private const int NUMBER_OF_JOBS_SHOWN = 3;

    public ObservableRangeCollection<Job> Jobs { get; set; } = new();

    public ObservableRangeCollection<Models.Location> Locations { get; set; } = new();

    public OverviewPageViewModel(INavigationWrapper navigator, IDataService dataService)
    {
        _navigator = navigator;
        _dataService = dataService;
    }

    public async Task InitializeAsync()
    {
        if (IsBusy)
            return;

        IsBusy = true;
        Jobs.Clear();
        Locations.Clear();
        await LoadCurrentUser();

        if(CurrentUser == null)
        {
            await _dataService.ClearDataAndLogout();
            return;
        }
        List<Task> tasks = new()
        {
            LoadLatestJobs(),
            LoadLocations()
        };

        await Task.WhenAll(tasks);
        IsBusy = false;
    }

    private async Task LoadLatestJobs()
    {
        var jobList = await _dataService.GetJobsAsync();
        var orderedList = jobList.OrderByDescending(x => x.LastActivity).ToList().Take(NUMBER_OF_JOBS_SHOWN);

        Jobs.AddRange(orderedList);
    }

    private async Task LoadLocations()
    {
        var locationList = await _dataService.GetLocationsAsync();
        Locations.AddRange(locationList);
    }

    private async Task LoadCurrentUser()
    {
        CurrentUser = await _dataService.GetCurrentUserAsync();
    }

    [RelayCommand]
    private async Task Nav(object arg)
    {
        await _navigator.RouteAndReplaceStackAsync(NavigationKeys.LandingPage, false);
    }

    [RelayCommand]
    public async Task JobClicked(Job job)
    {
        await _navigator.RouteAsync(NavigationKeys.JobPage, new Dictionary<string, object>
        {
            {"Job", job }
        });
    }

    [RelayCommand]
    private async Task ShowAllJobs(object arg)
    {
        await _navigator.RouteAndReplaceStackAsync(NavigationKeys.JobListPage, false);
    }
}
