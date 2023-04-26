using CommunityToolkit.Mvvm.Input;
using CompOff_App.Shared;
using CompOff_App.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Viewmodels;

public partial class LandingPageViewModel
{
    private readonly INavigationWrapper _navigator;

    public LandingPageViewModel(INavigationWrapper navigator)
    {
        _navigator = navigator;
    }

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
    }

    [RelayCommand]
    private async Task Login(object arg)
    {
        await _navigator.RouteAndReplaceStackAsync(NavigationKeys.OverviewPage, false);
    }
}