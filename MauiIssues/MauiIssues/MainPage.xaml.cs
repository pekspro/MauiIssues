using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiIssues;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = this;
    }

    public class Issue : BindableObject
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = true;
        public bool IsNotCompleted => !IsCompleted;

        public ICommand CommandToggle { get; }

        public Issue()
        {
             CommandToggle = new Command(() => Toggle());
        }

        public void Toggle()
        {
            IsCompleted = !IsCompleted;
            System.Diagnostics.Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} Setting {Title} to {IsCompleted}");
            OnPropertyChanged(nameof(IsCompleted));
            OnPropertyChanged(nameof(IsNotCompleted));
        }
    }

    public ObservableCollection<Issue> Issues { get; } = new ObservableCollection<Issue>();

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Issues.Add(new Issue { Title = "Issue 1", IsCompleted = false });
        Issues.Add(new Issue { Title = "Issue 2", IsCompleted = true });
        Issues.Add(new Issue { Title = "Issue 3", IsCompleted = false });
        Issues.Add(new Issue { Title = "Issue 4", IsCompleted = true });
    }
}
