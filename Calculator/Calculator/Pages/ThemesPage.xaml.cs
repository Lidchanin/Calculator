using Calculator.Models;
using Calculator.ViewModels;
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
        }

        #region private methods

        private async void CalculatorButton_OnTapped(object sender, EventArgs e)
        {
            await PopupService.ShowLoadingAsync();
            await Navigation.PopToRootAsync(true);
            await PopupService.HideLastPopupAsync();
        }

        private async void HistoryButton_OnTapped(object sender, EventArgs e)
        {
            await PopupService.ShowLoadingAsync();
            await Navigation.PushAsync(new HistoryPage());
            await PopupService.HideLastPopupAsync();
        }

        private void ThemeCard_OnTapped(object sender, EventArgs e)
        {
            var currentTheme = (Theme)((ContentView)sender).BindingContext;
            ThemesViewModel.ChangeTheme(currentTheme);
        }

        #endregion private methods
    }
}