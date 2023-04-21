using CompOff_App.Viewmodels.Tabs;

namespace CompOff_App.Pages.Tabs;

public partial class NewJobPage : ContentPage
{
    private readonly NewJobPageViewModel Vm;

    public NewJobPage(NewJobPageViewModel vm)
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