namespace MauiIssues;

[QueryProperty(nameof(Data), nameof(Data))]
public partial class DetailsPage : ContentPage
{
	public string Data { get; set; }

	public DetailsPage()
	{
		InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (Data == null)
        {
            LabelDetails.Text = "DATA IS NOT SET!";
        }
        else
        {
            LabelDetails.Text = $"Navigated to this page at {Data}";
        }
    }
}

