namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		ItemsList.ItemsSource = new string[] { "Hello", "World" }; 
	}
}
