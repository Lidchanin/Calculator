using Calculator.Services;
using System;
using Xamarin.Forms;

namespace Calculator.Pages
{
    public partial class CalculatorPage
    {
        public CalculatorPage()
        {

            InitializeComponent();
        }

        private void ChangeTheme_OnClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
                {
                    var navigationPage = (NavigationPage)Application.Current.MainPage;

                    Application.Current.Resources["DarkColor"] = Color.Black;
                    Application.Current.Resources["BlurColor"] = Color.DarkSlateGray;
                    Application.Current.Resources["LightColor"] = Color.White;

                    navigationPage.BarBackgroundColor = (Color) Application.Current.Resources["DarkColor"];
                    navigationPage.BarTextColor = (Color) Application.Current.Resources["LightColor"];

                    var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();

                    statusBarStyleManager.SetBlackTheme();
                }
            );
        }

        private void ChangeTheme2_OnClicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
                {
                    var navigationPage = (NavigationPage)Application.Current.MainPage;

                    Application.Current.Resources["DarkColor"] = Color.White;
                    Application.Current.Resources["BlurColor"] = Color.DarkSlateGray;
                    Application.Current.Resources["LightColor"] = Color.Black;

                    navigationPage.BarBackgroundColor = (Color)Application.Current.Resources["DarkColor"];
                    navigationPage.BarTextColor = (Color)Application.Current.Resources["LightColor"];

                    var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();

                    statusBarStyleManager.SetWhiteTheme();
                }
            );
        }
    }
}
