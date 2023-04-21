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
    /// Backing BindableProperty for the <see cref="LoadCommand"/> property.
    /// </summary>
    public static readonly BindableProperty LoadCommandProperty = BindableProperty.Create(nameof(LoadCommand), typeof(ICommand), typeof(NavigationBarPrimary));

    /// <summary>
    /// Backing BindableProperty for the <see cref="Command"/> property.
    /// </summary>
    public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IconButton));

    /// <summary>
    /// The Command which will be executed when the component is initialized. This is commonly used to signal the <see cref="User"/> should be fetched/>
    /// </summary>
    public ICommand LoadCommand
    {
        get => (ICommand)GetValue(LoadCommandProperty);
        set => SetValue(LoadCommandProperty, value);
    }
    /// <summary>
    /// The command which is executed when the Menu is tapped.
    /// </summary>
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
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