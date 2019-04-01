using System;

namespace Calculator.Pages
{
    public partial class CalculatorPage
    {
        public CalculatorPage()
        {
            InitializeComponent();
        }

        #region private methods

        private async void SettingsButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        #endregion private methods
    }
}
