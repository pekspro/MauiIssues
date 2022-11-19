namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		ItemsList.ItemsSource = new List<string>() { "1" };
	}
}

