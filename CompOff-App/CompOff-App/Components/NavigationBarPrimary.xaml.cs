using CommunityToolkit.Maui.Behaviors;
using System.Windows.Input;

namespace CompOff_App.Components;


public partial class NavigationBarPrimary : ContentView
{
    public event EventHandler? Clicked;


    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NavigationBarPrimary));
    

    public static readonly BindableProperty UserNameProperty = BindableProperty.Create(nameof(UserName), typeof(string), typeof(NavigationBarPrimary), "User Name");


    public static readonly BindableProperty InitialsProperty = BindableProperty.Create(nameof(Initials), typeof(string), typeof(NavigationBarPrimary), "UN");

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

    public string Initials
    {
        get => (string)GetValue(InitialsProperty);
        set => SetValue(InitialsProperty, value);
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
    }

    public NavigationBarPrimary()
    {
        InitializeComponent();

    }
}