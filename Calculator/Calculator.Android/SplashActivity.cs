using Android.App;
using Android.Content;
using Android.OS;

namespace Calculator.Droid
{
    [Activity(Label = "Calculator", 
        Theme = "@style/Theme.Splash", 
        MainLauncher = true, 
        NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(this, typeof(MainActivity)));

            Finish();
        }
    }
}