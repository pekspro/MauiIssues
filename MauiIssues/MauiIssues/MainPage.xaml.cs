namespace MauiIssues;

public record Person (string PersonName);

public record Team (string TeamName, Person Leader);

public record Teams (List<Team> TheTeams);

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		Person alice = new Person("Alice");
		Team coders = new Team("Coders", alice);
		Teams teams = new Teams(new List<Team> { coders });

		BindingContext = teams;
	}
}

