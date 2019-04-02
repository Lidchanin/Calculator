using System;
using System.Threading.Tasks;
using Calculator.Enums;
using Xamarin.Forms;

namespace Calculator.Pages
{
    public partial class CalculatorPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        #region private methods

        private async void ThemesButton_OnTapped(object sender, EventArgs e)
        {
            ThemesButton.IsEnabled = false;
            await Navigation.PushAsync(new ThemesPage());
            ThemesButton.IsEnabled = true;
        }

        private async void HistoryButton_OnTapped(object sender, EventArgs e)
        {
            HistoryButton.IsEnabled = false;
            await Task.Delay(2000);
            HistoryButton.IsEnabled = true;
        }

        private void ClearButton_OnPressed(object sender, EventArgs e)
        {
            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                ViewModel.ButtonPressCommand.Execute(CalculatorKeys.Clear);
                return false;
            });
        }

        #endregion private methods
    }
}
