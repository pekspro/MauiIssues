namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        Picker.ItemsSource = new List<string> { "One", "Two", "Three" };
		Picker.SelectedIndex = 1;
    }

    override async protected void OnAppearing()
    {
        base.OnAppearing();

        DisabledButton.IsEnabled = false;
        await Task.Delay(100);
        DisabledButton.IsEnabled = true;

        Window.Width = 360;
        Window.Height = 700;
    }

    private void ThemeLight_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (ThemeLight.IsChecked)
        {
            App.Current.UserAppTheme = AppTheme.Light;
        }
        else
        {
            App.Current.UserAppTheme = AppTheme.Dark;            
        }
    }
}
