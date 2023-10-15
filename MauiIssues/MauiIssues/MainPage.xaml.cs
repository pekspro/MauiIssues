using CommunityToolkit.Maui.Storage;
using System.Diagnostics;

namespace MauiIssues;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void SaveFile(object sender, EventArgs e)
	{
        using var stream = new MemoryStream("Hello world"u8.ToArray());
        var fileSaverResult = await FileSaver.Default.SaveAsync("myfile.bin", stream, default);
    }

    private async void OpenFile(object sender, EventArgs e)
	{
        var customFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.Android, new[] { "application/octet-stream" } }
            });

        PickOptions options = new()
        {
            PickerTitle = "Select file",
            FileTypes = customFileType,
            
        };

        var result = await FilePicker.Default.PickAsync(options);
        if (result != null)
        {
            try
            {
                using var stream = await result.OpenReadAsync();

                using var reader = new StreamReader(stream);

                var text = reader.ReadToEnd();

#if ANDROID
                Android.Widget.Toast.MakeText(Platform.CurrentActivity, "File was read.", Android.Widget.ToastLength.Short)
                    .Show();
#endif
            }
            catch(Exception ex)
            {
#if ANDROID
                Android.Widget.Toast.MakeText(Platform.CurrentActivity, "Reading failed: " + ex.Message, Android.Widget.ToastLength.Short)
                    .Show();
#endif
                Debugger.Break();
                string message = ex.Message;
            }
        }
    }
}

