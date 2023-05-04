using CommunityToolkit.Maui.Behaviors;
using System.Windows.Input;

namespace CompOff_App.Components;


public partial class NavigationBarPrimary : ContentView
{
    public event EventHandler? Clicked;


    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NavigationBarPrimary));
    

    public static readonly BindableProperty UserNameProperty = BindableProperty.Create(nameof(UserName), typeof(string), typeof(NavigationBarPrimary), "User name");

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public string UserName
    {
        get => (string)GetValue(UserNameProperty);
        set => SetValue(UserNameProperty, value);
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
    }

    public NavigationBarPrimary()
    {
        InitializeComponent();

        MenuHandle.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(() =>
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            })
        });
    }
}