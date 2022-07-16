namespace MauiIssues;

public partial class App : Application
{
    public App()
    {
	    InitializeComponent();

        Routing.RegisterRoute(nameof(SecondaryPage), typeof(SecondaryPage));

        MainPage = new AppShell();
    }
}
