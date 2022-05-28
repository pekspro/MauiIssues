using System.Collections.ObjectModel;

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
        public bool IsRed { get; set; } = true;
        public bool IsGreen => !IsRed;

        public void MakeGreen()
        {
            IsRed = false;
            OnPropertyChanged(nameof(IsGreen));
            OnPropertyChanged(nameof(IsRed));
        }
    }

    public ObservableCollection<Issue> Issues { get; } = new ObservableCollection<Issue>();

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        Issues.Add(new Issue { Title = "Issue 1" });
        Issues.Add(new Issue { Title = "Issue 2" });
        Issues.Add(new Issue { Title = "Issue 3" });

        await Task.Delay(4000);

        Issues[0].MakeGreen();
        Issues[1].MakeGreen();
    }
}
