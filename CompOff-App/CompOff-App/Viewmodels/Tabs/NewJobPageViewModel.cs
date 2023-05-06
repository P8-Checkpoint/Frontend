using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompOff_App.Models;
using CompOff_App.Services;
using CompOff_App.Shared;
using CompOff_App.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Viewmodels.Tabs;

public partial class NewJobPageViewModel : BaseViewModel
{
    private readonly INavigationWrapper _navigator; 
    private readonly IDataService _dataService;

    public NewJobPageViewModel(INavigationWrapper navigator, IDataService dataService)
    {
        _navigator = navigator;
        _dataService = dataService;
    }

    [ObservableProperty]
    public string fileName = "No file chosen...";

    [ObservableProperty]
    public bool showTitleError = false;

    [ObservableProperty]
    public bool showDescriptionError = false;

    [ObservableProperty]
    public bool showFileError = false;



    private string _filePath = string.Empty;

    public async Task InitializeAsync()
    {
        await ResetErrors();
    }

    private Task ResetErrors()
    {
        ShowTitleError = false;
        ShowDescriptionError = false;
        ShowFileError = false;
        return Task.CompletedTask;
    }

    private async Task Clear()
    {
        FileName = "No file chosen...";
        _filePath = string.Empty;
        await ResetErrors();
    }

    public async Task AddJob(string name, string description)
    {
        ShowTitleError = String.IsNullOrWhiteSpace(name);
        ShowDescriptionError = String.IsNullOrWhiteSpace(description);
        ShowFileError = String.IsNullOrWhiteSpace(_filePath);

        if (ShowTitleError || ShowDescriptionError || ShowFileError)
            return;

        await Clear();

        var job = new Job(name, description, FileName, _filePath);
        await _dataService.AddJobAsync(job);
        await _navigator.RouteAndReplaceStackAsync(NavigationKeys.JobListPage, false);
    }

    [RelayCommand]
    public async Task PickFile(object arg)
    {
        await PickAndShow(new PickOptions());
    }

    public async Task<FileResult> PickAndShow(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                FileName = result.FullPath;
                _filePath = result.FullPath;

            }

            return result;
        }
        catch (Exception ex)
        {
            // The user canceled or something went wrong
        }

        return null;
    }
}
