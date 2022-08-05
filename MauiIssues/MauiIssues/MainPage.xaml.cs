namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await Task.Delay(1000);
		ButtonTwo.IsEnabled = true;
    }

	private void DarkButtom_Clicked(object sender, EventArgs e)
	{
		App.Current.UserAppTheme = AppTheme.Dark;
	}

	private void LightButtom_Clicked(object sender, EventArgs e)
	{
		App.Current.UserAppTheme = AppTheme.Light;
	}
}
