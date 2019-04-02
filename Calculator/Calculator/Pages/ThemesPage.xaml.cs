using System;
using Calculator.Models;
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

        #region private methods

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.ChangeTheme((Theme) e.SelectedItem);
        }

        private async void CalculatorButton_OnTapped(object sender, EventArgs e)
        {
            CalculatorButton.IsEnabled = false;
            await Navigation.PushAsync(new CalculatorPage());
            CalculatorButton.IsEnabled = true;
        }

        #endregion private methods
    }
}