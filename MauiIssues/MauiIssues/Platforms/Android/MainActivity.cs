using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.Content;

namespace MauiIssues;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnResume()
    {
        base.OnResume();

        PackageManager manager = PackageManager!;
        PackageInfo info;
        
        if (OperatingSystem.IsAndroidVersionAtLeast(33))
        {
            info = manager.GetPackageInfo(PackageName!, PackageManager.PackageInfoFlags.Of((int)PackageInfoFlags.MetaData));
        }
        else
        {
//#pragma warning disable 618
            info = manager.GetPackageInfo(PackageName!, PackageInfoFlags.MetaData)!;
//#pragma warning restore 618
        }

        string version = info.VersionName!;
    }
}
