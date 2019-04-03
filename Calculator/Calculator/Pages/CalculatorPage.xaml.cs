using Calculator.Enums;
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
            await Navigation.PushAsync(new HistoryPage());
            HistoryButton.IsEnabled = true;
        }

        private void ClearButton_OnPressed(object sender, EventArgs e)
        {
            var clearButton = (Button) sender;

            Device.StartTimer(TimeSpan.FromMilliseconds(1500), () =>
            {
                if (clearButton.IsPressed)
                {
                    ViewModel.ButtonPressCommand.Execute(CalculatorKeys.Clear);
                }

                return false;
            });
        }

        #endregion private methods
    }
}
