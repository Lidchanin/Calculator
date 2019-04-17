using Calculator.Controls;
using Calculator.Enums;
using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator.Pages
{
    public partial class CalculatorPage
    {
        private readonly CalculatorViewModel _viewModel;

        private bool _isFirstTap;
        private bool _isExpanded;

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

        private void ExpressionEntry_OnFocused(object sender, FocusEventArgs e) =>
            ((BorderlessEntry) sender).CursorPosition = _viewModel.CurrentCursorPosition;

        private void ExpressionEntry_OnUnfocused(object sender, FocusEventArgs e) =>
            _viewModel.CurrentCursorPosition = ((BorderlessEntry) sender).CursorPosition;

        private async void ChangeSecondaryExtensibility_OnTapped(object sender, EventArgs e)
        {
            const int animationSpeed = 500;
            var distance = SecondaryOperationsSectionGrid.Width + SecondarySectionVisibilitySwitcher.Width;

            SecondarySectionVisibilitySwitcher.IsEnabled = false;

            if (!_isFirstTap)
            {
                MainView.LowerChild(MainOperationsSectionGrid);
                _isFirstTap = true;
            }

            if (_isExpanded)
            {
                SecondaryOperationsSectionGrid.TranslationX = 0;

                await Task.WhenAll(new List<Task>
                {
                    SecondaryOperationsSectionGrid.TranslateTo(distance, 0, animationSpeed, Easing.CubicInOut),

                    ArrowImage.RotateYTo(0, animationSpeed/2, Easing.CubicInOut)
                });
            }
            else
            {
                SecondaryOperationsSectionGrid.TranslationX = distance;

                await Task.WhenAll(new List<Task>
                {
                    SecondaryOperationsSectionGrid.TranslateTo(0, 0, animationSpeed, Easing.CubicInOut),

                    ArrowImage.RotateYTo(180, animationSpeed/2, Easing.CubicInOut)
                });
            }

            _isExpanded = !_isExpanded;

            SecondarySectionVisibilitySwitcher.IsEnabled = true;
        }

        #endregion private methods
    }
}