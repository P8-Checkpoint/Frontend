using CompOff_App.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using CompOff_App.Shared;

namespace CompOff_App.Viewmodels.Tabs;

public partial class OverviewPageViewModel
{
    private readonly INavigationWrapper _navigator; 

    public OverviewPageViewModel(INavigationWrapper navigator)
    {
        _navigator = navigator;
    }

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
    }

    [RelayCommand]
    private async Task Nav(object arg)
    {
        await _navigator.RouteAndReplaceStackAsync(NavigationKeys.LandingPage, false);
    }
}
