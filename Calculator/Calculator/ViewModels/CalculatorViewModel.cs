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
        public string MathString { get; set; } = "";
        public string ResultString { get; set; } = "";

        public ICommand ButtonPressCommand { get; set; }

        public CalculatorViewModel()
        {
            ButtonPressCommand = new Command<CalculatorKey>(ButtonPress);
        }

        private void ButtonPress(CalculatorKey parameter)
        {
            if (!string.IsNullOrEmpty(MathString))
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

            MathString += parameter.GetText();
            ResultString = "";
        }

        private void EqualClicked(CalculatorKey parameter)
        {
            try
            {
                var dt = new DataTable();
                var temp = dt.Compute(MathString, "").ToString();
                if (temp == "Infinity" || temp == "-Infinity")
                {
                    ResultString = "Dividing by zero!";
                }
                else
                {
                    ResultString = temp;
                    MathString = "";
                }
            }
            catch (InvalidCastException)
            {
                ResultString = "Incorrect expression";
            }
            catch (SyntaxErrorException)
            {
                var lastSymbol = MathString.Last().ToString();
                if (lastSymbol.IsOperationKey())
                {
                    MathString = MathString.Remove(MathString.Length - 1);
                    ButtonPress(parameter);
                }
                else
                {
                    ResultString = "Incorrect expression";
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void ClearClicked()
        {
            MathString = "";
            ResultString = "";
        }

        private void ClearEntryClicked()
        {
            MathString = MathString.Remove(MathString.Length - 1);
            ResultString = "";
        }

        private void OperationClicked(CalculatorKey parameter)
        {
            var lastSymbol = MathString.Last().ToString();

            if (lastSymbol.IsOperationKey())
            {
                MathString = MathString.Replace(lastSymbol, parameter.GetText());
            }
            else
            {
                MathString += parameter.GetText();
                ResultString = "";
            }
        }

        private void PointClicked(CalculatorKey parameter)
        {
            var lastSymbol = MathString.Last().ToString();

            if (lastSymbol != CalculatorKey.Point.GetText())
            {
                MathString += parameter.GetText();
                ResultString = "";
            }
        }
    }
}