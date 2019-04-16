using Calculator.Data;
using Calculator.Helpers;
using Calculator.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Calculator
{
    public partial class App
    {
        private static ICalculatorDatabase _database;

        public App()
        {
            InitializeComponent();

            ThemeManager.LoadTheme();

            MainPage = new NavigationPage(new CalculatorPage());
        }

        public static ICalculatorDatabase Database =>
            _database ?? (_database = new CalculatorDatabase(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CalculatorDB.db3")));

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
