namespace MauiIssues;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        var currentHeight = Window.Height;
        
        // Setting the same value doesn't do anything.
        Window.Height = currentHeight;

        // Changing value will cause Fatal signal 11 (SIGSEGV), code 1 on Android.
        Window.Height = currentHeight + 1;
    }
}
