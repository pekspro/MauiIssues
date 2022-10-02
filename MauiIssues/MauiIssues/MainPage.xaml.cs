namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void ButtonNavigate_Clicked(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync(nameof(SecondaryPage));
	}
}

