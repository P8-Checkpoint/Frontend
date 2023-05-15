using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompOff_App.Models;
using CompOff_App.Services;
using CompOff_App.Wrappers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Viewmodels;

public partial class JobPageViewModel : BaseViewModel, IQueryAttributable
{
    private readonly INavigationWrapper _navigator;
    private readonly IDataService _dataService;
    private readonly IConnectionService _connectionService;
    private readonly INetworkService _networkService;
    private readonly IFileService _fileService;
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _ = query.TryGetValue("Job", out object? queryJob);

        if (queryJob is Job job && queryJob is not null)
        {
            _currenntJobId = job.JobID;
        }
    }

    private Guid _currenntJobId = Guid.Empty;

    [ObservableProperty]
    public Job currentJob = new();

    [ObservableProperty]
    public bool notEditingDescription = true;

    [ObservableProperty]
    public bool isWaiting = false;

    [ObservableProperty]
    public bool isRunning = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotPreparing))]
    public bool isPreparing = false;

    public bool IsNotPreparing => !IsPreparing;

    [ObservableProperty]
    public bool showWorkerError = false;


    public JobPageViewModel(IFileService fileService, INavigationWrapper navigator, IDataService dataService, INetworkService networkService, IConnectionService connectionService)
    {
        _fileService = fileService;
        _dataService = dataService;
        _navigator = navigator;
        _connectionService = connectionService;
        _networkService = networkService;
    }

    public async Task InitializeAsync()
    {
        if (IsBusy)
            return;
        IsBusy = true;
        await Update();
        IsBusy = false;
    }

    private async Task Update()
    {
        var job = await _dataService.GetJobByIdAsync(_currenntJobId);
        CurrentJob = job;
        OnPropertyChanged(nameof(CurrentJob));

        IsWaiting = CurrentJob.Status is JobStatus.Waiting;
        IsRunning = CurrentJob.Status is JobStatus.Running or JobStatus.InQueue;
        OnPropertyChanged(nameof(IsWaiting));
        OnPropertyChanged(nameof(IsRunning));
    }

    [RelayCommand]
    public async Task Reload(object arg)
    {
        await Update();
    }

    [RelayCommand]
    public async Task Start(object arg)
    {
        IsPreparing = true;
        var prepareDto = await _connectionService.PrepareJob(CurrentJob);

        if (prepareDto == null)
        {
            ShowWorkerError = true;
            OnPropertyChanged(nameof(ShowWorkerError));
            isPreparing = false;
            await Update();
            return;
        }

        ShowWorkerError = false;
        OnPropertyChanged(nameof(ShowWorkerError));

        CurrentJob = new Job(prepareDto.serviceTask);

        _networkService.ConnectToNetwork(prepareDto.wifi.ssid, prepareDto.wifi.password);
        _fileService.UploadScript(CurrentJob);

        await _connectionService.StartJobAsync(CurrentJob);
        Thread.Sleep(50);

        IsPreparing = false;
        await Update();
    }

    [RelayCommand]
    public async Task Cancel(object arg)
    {
        await _dataService.CancelJobAsync(CurrentJob);
        await Update();
    }

    [RelayCommand]
    public async Task Back(object arg)
    {
        await _navigator.NavigateBackAsync(isAnimated: true);
    }

    [RelayCommand]
    public Task EditDescription(object arg)
    {
        NotEditingDescription = false;
        return Task.CompletedTask;
    }

    [RelayCommand]
    public async Task SubmitDescriptionChange(object arg)
    {
        NotEditingDescription = true;
        CurrentJob.Description = (string)arg;
        await _dataService.UpdateJobAsync(CurrentJob);
        await Update();
    }

    [RelayCommand]
    public async Task CancelDescriptionEdit(object arg)
    {
        NotEditingDescription = true;
        OnPropertyChanged(nameof(CurrentJob));
        await Update();
    }
}
