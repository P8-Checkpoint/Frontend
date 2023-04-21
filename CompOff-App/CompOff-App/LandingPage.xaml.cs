using CompOff_App.Viewmodels;

namespace CompOff_App;

public partial class LandingPage : ContentPage
{
    private readonly LandingPageViewModel Vm;

	public LandingPage(LandingPageViewModel vm)
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

