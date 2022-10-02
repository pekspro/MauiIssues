namespace MauiIssues;

public partial class SecondaryPage : ContentPage
{
	public SecondaryPage()
	{
		InitializeComponent();
	}

	private async void ButtonNavigate_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(ThirdPage));
	}
}