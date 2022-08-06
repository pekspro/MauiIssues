using System.Collections.ObjectModel;

namespace MauiIssues;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = this;
    }

    public List<string> Colors { get; set; } = new List<string>()
    {
        "Red",
        "LightRed",
        "DarkRed",
    };

    public int SelectedColorIndex { get; set; }

    private int ChangeCount = 0;

    private void OnCounterClicked(object sender, EventArgs e)
    {
        ChangeCount++;
        Colors = new List<string>()
        {
            "Blue " + ChangeCount,
            "LightBlue " + ChangeCount,
            "DarkBlue " + ChangeCount,
        };

        OnPropertyChanged(nameof(Colors));
        SelectedColorIndex = 0;
        OnPropertyChanged(nameof(SelectedColorIndex));
    }

    /*
    This code works better:

    public MainPage()
    {
        InitializeComponent();

        BindingContext = this;
    }

    public ObservableCollection<string> Colors { get; set; } = new ObservableCollection<string>()
    {
        "Red",
        "LightRed",
        "DarkRed",
    };

    public int SelectedColorIndex { get; set; }

    int ChangeCount = 0;

    private void OnCounterClicked(object sender, EventArgs e)
    {
        ChangeCount++;

        Colors.Clear();

        Colors.Add("Blue " + ChangeCount);
        Colors.Add("LightBlue " + ChangeCount);
        Colors.Add("DarkBlue " + ChangeCount);

        OnPropertyChanged(nameof(Colors));
        SelectedColorIndex = 0;
        OnPropertyChanged(nameof(SelectedColorIndex));
    }

    */
}

