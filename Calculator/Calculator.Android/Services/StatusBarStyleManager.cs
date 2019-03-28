﻿using Android.App;
using Android.OS;
using Android.Views;
using Calculator.Droid.Services;
using Calculator.Services;
using Xamarin.Forms;

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
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Black);
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
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.White);
                });
            }
        }

        private static Window GetCurrentWindow()
        {
            //var context = Android.App.Application.Context;
            var context = Forms.Context;
            var activity = (Activity) context;
            var window = activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}