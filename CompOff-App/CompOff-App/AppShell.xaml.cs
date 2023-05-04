using CompOff_App.Pages;
using CompOff_App.Shared;

namespace CompOff_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(NavigationKeys.JobPage, typeof(JobPage));
	}
}
