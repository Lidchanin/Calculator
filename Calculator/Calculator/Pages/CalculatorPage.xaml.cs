using Calculator.Enums;
using Calculator.ViewModels;
using System;
using Xamarin.Forms;

namespace Calculator.Pages
{
    public partial class CalculatorPage
    {
        private readonly CalculatorViewModel _viewModel;

        public CalculatorPage()
        {
            _viewModel = new CalculatorViewModel();

            BindingContext = _viewModel;

            InitializeComponent();
        }

        public CalculatorPage(string expression, string result)
        {
            _viewModel = new CalculatorViewModel(expression, result);

            BindingContext = _viewModel;

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
                    _viewModel.ButtonPressCommand.Execute(CalculatorKeys.Clear);
                }

                return false;
            });
        }

        private void ExpressionString_OnFocused(object sender, FocusEventArgs e)
        {
            var temp = (Entry)sender;

            temp.CursorPosition = _viewModel.CurrentCursorPosition;
        }

        private void ExpressionEntry_OnUnfocused(object sender, FocusEventArgs e)
        {
            var temp = (Entry)sender;

            _viewModel.CurrentCursorPosition = temp.CursorPosition;
        }

        #endregion private methods
    }
}
