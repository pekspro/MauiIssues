namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        Items = TimeZoneInfo.GetSystemTimeZones().ToList();

        BindingContext = this;
        
	}

    public List<TimeZoneInfo> Items { get; }
}

