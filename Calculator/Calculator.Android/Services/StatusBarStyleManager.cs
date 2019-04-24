using Android.OS;
using Android.Views;
using Calculator.Droid.Services;
using Calculator.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using static Android.Graphics.Color;

[assembly: Dependency(typeof(StatusBarStyleManager))]
namespace Calculator.Droid.Services
{
    public class StatusBarStyleManager : IStatusBarStyleManager
    {
        public void SetDarkTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility) SystemUiFlags.LightStatusBar;
                    currentWindow.SetStatusBarColor(ParseColor("#455A64"));
                });
            }
        }

        public void SetLightTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = 0;
                    currentWindow.SetStatusBarColor(ParseColor("#757575"));
                });
            }
        }

        private static Window GetCurrentWindow()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            var window = activity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}