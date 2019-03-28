using Calculator.Enums;
using Calculator.Helpers;
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
            ButtonPressCommand = new Command<CalculatorKey>(ButtonPress);
        }

        private void ButtonPress(CalculatorKey parameter)
        {
            if (!string.IsNullOrEmpty(ExpressionString))
            {
                switch (parameter)
                {
                    case CalculatorKey.Equal:
                        EqualClicked(parameter);
                        return;
                    case CalculatorKey.Clear:
                        ClearClicked();
                        return;
                    case CalculatorKey.ClearEntry:
                        ClearEntryClicked();
                        return;
                    case CalculatorKey.Point:
                        PointClicked(parameter);
                        return;
                    //case CalculatorKey.LeftBracket:
                    //    return;
                    //case CalculatorKey.RightBracket:
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

        private void EqualClicked(CalculatorKey parameter)
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

        private void OperationClicked(CalculatorKey parameter)
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

        private void PointClicked(CalculatorKey parameter)
        {
            var lastSymbol = ExpressionString.Last().ToString();

            if (lastSymbol != CalculatorKey.Point.GetText())
            {
                ExpressionString += parameter.GetText();
            }
        }
    }
}