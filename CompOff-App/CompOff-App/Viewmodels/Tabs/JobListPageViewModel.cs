using CompOff_App.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Viewmodels.Tabs;

public partial class JobListPageViewModel
{
    private readonly INavigationWrapper _navigator; 

    public JobListPageViewModel(INavigationWrapper navigator)
    {
        _navigator = navigator;
    }

    public async Task InitializeAsync()
    {
        await Task.CompletedTask;
    }
}
