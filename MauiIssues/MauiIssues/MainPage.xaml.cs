namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnOpenDetailsClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>()
		{
			{ "Data", DateTime.Now.ToString("HH:m:ss") }
		});
	}
}

