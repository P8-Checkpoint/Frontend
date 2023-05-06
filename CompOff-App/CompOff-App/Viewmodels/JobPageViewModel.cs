using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompOff_App.Models;
using CompOff_App.Services;
using CompOff_App.Wrappers;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Viewmodels
{
    public partial class JobPageViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly INavigationWrapper _navigator;
        private readonly IDataService _dataService;
        
        private string _description;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            _ = query.TryGetValue("Job", out object? queryJob);

            if (queryJob is Job job && queryJob is not null)
            {
                CurrentJob = job;
            }
        }

        [ObservableProperty]
        public Job currentJob = new();

        [ObservableProperty]
        public bool notEditingDescription = true;

        [ObservableProperty]
        public bool showCancelButton = false;

        [ObservableProperty]
        public bool showResultButton = false;


        public JobPageViewModel(INavigationWrapper navigator, IDataService dataService)
        {
            _dataService = dataService;
            _navigator = navigator;
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
            var job = await _dataService.GetJobByIdAsync(CurrentJob.JobID);
            CurrentJob = job;
            _description = CurrentJob.Description;
            OnPropertyChanged(nameof(CurrentJob));

            ShowCancelButton = CurrentJob.Status is JobStatus.Waiting or JobStatus.InQueue or JobStatus.Running;
            ShowResultButton = CurrentJob.Status is JobStatus.Done;
            OnPropertyChanged(nameof(ShowCancelButton));
            OnPropertyChanged(nameof(ShowResultButton));
        }

        [RelayCommand]
        public async Task Reload(object arg)
        {
            await Update();
        }

        [RelayCommand]
        public async Task Cancel(object arg)
        {
            await _dataService.UpdateJobAsync(CurrentJob.JobID, CurrentJob.JobName, JobStatus.Cancelled, CurrentJob.Description);
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
            _description = (string)arg;
            await _dataService.UpdateJobAsync(CurrentJob.JobID, CurrentJob.JobName, CurrentJob.Status, _description);
            await Update();
        }

        [RelayCommand]
        public async Task CancelDescriptionEdit(object arg)
        {
            NotEditingDescription = true;
            CurrentJob.Description = _description;
            OnPropertyChanged(nameof(CurrentJob));
            await Update();
        }
    }
}
