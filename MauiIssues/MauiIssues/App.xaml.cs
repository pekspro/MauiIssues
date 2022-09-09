namespace MauiIssues;

public partial class App : Application
{
    Microsoft.Maui.Handlers.IToolbarHandler ToolbarHandler;

    public App()
	{
		InitializeComponent();

        Microsoft.Maui.Handlers.ToolbarHandler.Mapper.AppendToMapping("mytoolbar", (handler, view) =>
        {
            ToolbarHandler = handler;
            SetupMenuBarColorFix();
        });

        RequestedThemeChanged += (s, e) => SetupMenuBarColorFix();

        MainPage = new AppShell();
	}

    public void SetupMenuBarColorFix()
    {
        if (ToolbarHandler is null)
        {
            return;
        }

#if ANDROID
        if (RequestedTheme == AppTheme.Light)
        {
            ToolbarHandler.PlatformView.OverflowIcon = Platform.CurrentActivity.GetDrawable(Resource.Drawable.ic_more_vert_24_light);
        }
        else
        {
            ToolbarHandler.PlatformView.OverflowIcon = Platform.CurrentActivity.GetDrawable(Resource.Drawable.ic_more_vert_24_dark);
        }
#endif
    }
}
