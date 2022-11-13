namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = this;
	}

	public List<int> Numbers { get; } = Enumerable.Range(1, 100).ToList();
}
