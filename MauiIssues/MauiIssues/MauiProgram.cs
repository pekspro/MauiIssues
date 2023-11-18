using GeneralDatabase;
using Microsoft.Extensions.Logging;

namespace MauiIssues;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        SQLitePCL.Batteries_V2.Init();

#if ANDROID
        string cachePath = Android.App.Application.Context.CacheDir!.AbsolutePath;
#elif WINDOWS
        string cachePath = global::Windows.Storage.ApplicationData.Current.LocalCacheFolder.Path;
#else
        string cachePath = string.Empty;
#endif

        // Add this to fix the issue:
        // System.AppContext.SetSwitch("Microsoft.EntityFrameworkCore.Issue31751", true);

        var context = new GeneralDatabaseContext(cachePath);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Blog.Add(new Blog());
        context.SaveChanges();
        var blogs = context.Blog.ToList();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
