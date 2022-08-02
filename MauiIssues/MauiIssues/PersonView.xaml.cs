namespace MauiIssues;

public partial class PersonView : ContentView
{
	public PersonView()
	{
		InitializeComponent();
	}

	protected override void OnBindingContextChanged()
	{
		base.OnBindingContextChanged();

		var context = BindingContext;
	}
}
