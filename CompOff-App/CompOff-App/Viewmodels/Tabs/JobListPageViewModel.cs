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
using System.Windows.Input;

namespace CompOff_App.Viewmodels.Tabs;

public partial class JobListPageViewModel : BaseViewModel
{
    private readonly INavigationWrapper _navigator;
    private readonly IDataService _dataService;

    public ObservableRangeCollection<Job> Jobs { get; set; } = new();

    public JobListPageViewModel(INavigationWrapper navigator, IDataService dataService)
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

        List<Task> tasks = new() { LoadLatestJobs() };
        await Task.WhenAll(tasks);
        IsBusy = false;

        await Task.CompletedTask;
    }

    private async Task LoadLatestJobs()
    {
        var jobList = await _dataService.GetJobsAsync();
        var orderedList = jobList.OrderByDescending(x => x.LastActivity).ToList();
        Jobs.AddRange(orderedList);
    }
    
    
}
