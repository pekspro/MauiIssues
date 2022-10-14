using System.Collections.ObjectModel;

namespace MauiIssues;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        BindingContext = this;
    }

    public int SpanCount { get; set; } = 2;

    public ObservableCollection<int> Numbers { get; } =
        new ObservableCollection<int>(Enumerable.Range(1, 8));
        //new ObservableCollection<int>(Enumerable.Range(1, 100));

    private void AddColumn_Clicked(object sender, EventArgs e)
    {
        SpanCount++;
        OnPropertyChanged(nameof(SpanCount));
    }
}
