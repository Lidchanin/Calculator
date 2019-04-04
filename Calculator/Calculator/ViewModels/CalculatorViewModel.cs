using Calculator.Enums;
using Calculator.Helpers;
using Calculator.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Calculator.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public string ExpressionString { get; set; }
        public string ResultString { get; set; }

        public ICommand ButtonPressCommand { get; set; }

        public CalculatorViewModel()
        {
            ButtonPressCommand = new Command<CalculatorKeys>(ButtonPress);
        }

        public CalculatorViewModel(string expression, string result)
        {
            ButtonPressCommand = new Command<CalculatorKeys>(ButtonPress);

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
                        EqualClicked(parameter);
                        return;
                    case CalculatorKeys.Clear:
                        ClearClicked();
                        return;
                    case CalculatorKeys.ClearEntry:
                        ClearEntryClicked();
                        return;
                    case CalculatorKeys.Point:
                        PointClicked(parameter);
                        return;
                    //case CalculatorKeys.LeftBracket:
                    //    return;
                    //case CalculatorKeys.RightBracket:
                    //    return;
                    default:
                    {
                        if (parameter.IsOperationKey())
                        {
                            OperationClicked(parameter);
                            return;
                        }

                        break;
                    }
                }
            }

            ExpressionString += parameter.GetText();
        }

        private async void EqualClicked(CalculatorKeys parameter)
        {
            try
            {
                var dt = new DataTable();
                var temp = dt.Compute(ExpressionString, string.Empty).ToString();

                if (temp == ConstantHelper.PositiveInfinity || temp == ConstantHelper.NegativeInfinity)
                {
                    ResultString = ConstantHelper.DividingByZero;
                }
                else
                {
                    ResultString = temp;

                    await App.Database.Insert(new CalculatorItem
                    {
                        Expression = ExpressionString,
                        Result = ResultString,
                        CalculationTime = DateTime.Now.ToLocalTime()
                    });
                }
            }
            catch (InvalidCastException)
            {
                ResultString = ConstantHelper.IncorrectExpression;
            }
            catch (SyntaxErrorException)
            {
                var lastSymbol = ExpressionString.Last().ToString();
                if (lastSymbol.IsOperationKey())
                {
                    ExpressionString = ExpressionString.Remove(ExpressionString.Length - 1, 1);
                    ButtonPress(parameter);
                }
                else
                {
                    ResultString = ConstantHelper.IncorrectExpression;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void ClearClicked()
        {
            ExpressionString = string.Empty;
            ResultString = string.Empty;
        }

        private void ClearEntryClicked()
        {
            ExpressionString = ExpressionString.Remove(ExpressionString.Length - 1, 1);
        }

        private void OperationClicked(CalculatorKeys parameter)
        {
            var lastSymbol = ExpressionString.Last().ToString();

            if (lastSymbol.IsOperationKey())
            {
                ExpressionString = ExpressionString.Remove(ExpressionString.Length - 1, 1) + parameter.GetText();
            }
            else
            {
                ExpressionString += parameter.GetText();
            }
        }

        private void PointClicked(CalculatorKeys parameter)
        {
            var lastSymbol = ExpressionString.Last().ToString();

            if (lastSymbol != CalculatorKeys.Point.GetText())
            {
                ExpressionString += parameter.GetText();
            }
        }

        #endregion
    }
}