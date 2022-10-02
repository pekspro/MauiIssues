namespace MauiIssues;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        Routing.RegisterRoute(nameof(SecondaryPage), typeof(SecondaryPage));
        Routing.RegisterRoute(nameof(ThirdPage), typeof(ThirdPage));
    }
}
