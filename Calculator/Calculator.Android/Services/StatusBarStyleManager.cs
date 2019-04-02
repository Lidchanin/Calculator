using Android.App;
using Android.OS;
using Android.Views;
using Calculator.Droid.Services;
using Calculator.Services;
using Xamarin.Forms;
using static Android.Graphics.Color;

[assembly: Dependency(typeof(StatusBarStyleManager))]
namespace Calculator.Droid.Services
{
    public class StatusBarStyleManager : IStatusBarStyleManager
    {
        public void SetBlackTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = 0;
                    currentWindow.SetStatusBarColor(ParseColor("#212121"));
                });
            }
        }

        public void SetWhiteTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                    currentWindow.SetStatusBarColor(ParseColor("#FFFFFF"));
                });
            }
        }

        private static Window GetCurrentWindow()
        {
            //var context = Android.App.Application.Context;
            var context = Forms.Context;
            var activity = (Activity) context;
            var window = activity.Window;

            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}