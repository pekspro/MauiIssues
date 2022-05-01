using System.ComponentModel;

namespace MauiIssues;

public partial class MainPage : ContentPage
{
    public ViewModel Model { get; set; } = new ViewModel();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = Model;
    }
}

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public int Counter { get; set; }

    private System.Timers.Timer Timer = new();

    public ViewModel()
    {
        Timer.Interval = 1;
        Timer.Enabled = true;
        Timer.Elapsed += (o, s) =>
        {
            Application.Current.Dispatcher.Dispatch(() =>
            {
                Counter = (Counter + 1) % 1000;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
            });
        };
    }
}
