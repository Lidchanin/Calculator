using Calculator.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemesPage
    {
        public ThemesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var currentTheme = ViewModel.GetCurrentTheme();
            ThemesView.SelectedItem = currentTheme;
            //ThemesListView.SelectedItem = currentTheme;
            //ThemesListView.ScrollTo(currentTheme, ScrollToPosition.MakeVisible, true);
        }

        #region private methods

        private void ThemesListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.ChangeTheme((Theme) e.SelectedItem);
        }

        private async void CalculatorButton_OnTapped(object sender, EventArgs e)
        {
            CalculatorButton.IsEnabled = false;
            await Navigation.PopToRootAsync(true);
            CalculatorButton.IsEnabled = true;
        }

        private async void HistoryButton_OnTapped(object sender, EventArgs e)
        {
            HistoryButton.IsEnabled = false;
            await Navigation.PushAsync(new HistoryPage());
            HistoryButton.IsEnabled = true;
        }

        private void ThemeCard_OnTapped(object sender, EventArgs e)
        {
            var currentTheme = (Theme)((ContentView)sender).BindingContext;
            ViewModel.ChangeTheme(currentTheme);
        }

        #endregion private methods
    }
}