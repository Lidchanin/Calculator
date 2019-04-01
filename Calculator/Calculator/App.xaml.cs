﻿using Calculator.Helpers;
using Calculator.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Calculator
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            ThemeManager.LoadTheme();

            MainPage = new NavigationPage(new CalculatorPage());
        }

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
