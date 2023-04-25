using CommunityToolkit.Maui.Behaviors;
using System.Windows.Input;

namespace CompOff_App.Components;

/// <summary>
/// This component provides the primary navigation for top-level pages
/// </summary>
public partial class NavigationBarPrimary : ContentView
{
    public event EventHandler? Clicked;

    /// <summary>
    /// Backing BindableProperty for the <see cref="Command"/> property.
    /// </summary>
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(NavigationBarPrimary));
    
    /// <summary>
    /// Backing BindableProperty for <see cref="UserName"/> property.
    /// </summary>
    public static readonly BindableProperty UserNameProperty = BindableProperty.Create(nameof(UserName), typeof(string), typeof(NavigationBarPrimary), "User name");
    /// <summary>
    /// The command which is executed when the Menu is tapped.
    /// </summary>
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    /// <summary>
    /// The User name to be displayed next to the avatar
    /// </summary>
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