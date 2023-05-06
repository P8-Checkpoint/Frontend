using CompOff_App.Models;
using CompOff_App.Services;
using CompOff_App.Viewmodels.Tabs;

namespace CompOff_App.Pages.Tabs;

public partial class JobListPage : ContentPage
{
    private readonly JobListPageViewModel Vm;

    public JobListPage(JobListPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Vm.InitializeAsync();
    }



}