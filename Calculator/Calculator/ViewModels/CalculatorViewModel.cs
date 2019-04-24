using Calculator.Enums;
using Calculator.Helpers;
using Calculator.Models;
using org.mariuszgromada.math.mxparser;
using System;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public string ExpressionString { get; set; } = string.Empty;
        public string ResultString { get; set; }

        public int CurrentCursorPosition { get; set; }

        public ICommand ButtonPressCommand { get; }

        public CalculatorViewModel()
        {
            ButtonPressCommand = new Command<CalculatorKeys>(ButtonPress);
        }

        public CalculatorViewModel(string expression, string result) : this()
        {
            ExpressionString = expression;
            ResultString = result;
        }

        #region private methods

        private void ButtonPress(CalculatorKeys parameter)
        {
            if (!string.IsNullOrEmpty(ExpressionString))
            {
                switch (parameter)
                {
                    case CalculatorKeys.Equal:
                        EqualClicked();
                        return;
                    case CalculatorKeys.Clear:
                        ClearClicked();
                        return;
                    case CalculatorKeys.ClearEntry:
                        ClearEntryClicked();
                        return;
                }
            }

            if (!string.IsNullOrEmpty(parameter.GetText()))
            {
                ExpressionString = ExpressionString.Insert(CurrentCursorPosition, parameter.GetText());
                CurrentCursorPosition += 1;
            }
        }

        private async void EqualClicked()
        {
            try
            {
                await PopupService.ShowLoadingAsync();

                //var dt = new DataTable();
                //var temp = dt.Compute(ExpressionString, string.Empty).ToString();

                var expression = new Expression(ExpressionString);

                ResultString = expression.checkSyntax()
                    ? expression.calculate().ToString(CultureInfo.InvariantCulture)
                    : ConstantHelper.IncorrectExpression;

                await App.Database.Insert(new CalculatorItem
                {
                    Expression = ExpressionString,
                    Result = ResultString,
                    CalculationTime = DateTime.Now.ToLocalTime()
                });
            }
            catch (Exception e)
            {
                ResultString = e.GetBaseException().Message;
            }
            finally
            {
                await PopupService.HideLastPopupAsync();
            }
        }

        private void ClearClicked()
        {
            ExpressionString = string.Empty;
            ResultString = string.Empty;
            CurrentCursorPosition = 0;
        }

        private void ClearEntryClicked()
        {
            if (CurrentCursorPosition == 0)
                return;

            ExpressionString = ExpressionString.Remove(CurrentCursorPosition - 1, 1);
            CurrentCursorPosition -= 1;
        }

        #endregion
    }
}