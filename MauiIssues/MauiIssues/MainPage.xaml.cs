namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		Routing.RegisterRoute(nameof(SecondPage), typeof(SecondPage));
		await Shell.Current.GoToAsync(nameof(SecondPage));
	}
}
