namespace MauiIssues;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private bool _IsSet = false;

    public bool IsSet
	{
        get
		{
            return _IsSet;
        }
		set
		{
            _IsSet = value;
            OnPropertyChanged();
        }
	}
}
