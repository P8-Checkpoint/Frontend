using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CompOff_App.Models;
using CompOff_App.Services;
using CompOff_App.Wrappers;
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



            IsBusy = false;
        }

        [RelayCommand]
        public async Task Back(object arg)
        {
            await _navigator.NavigateBackAsync(isAnimated: true);
        }
    }
}
