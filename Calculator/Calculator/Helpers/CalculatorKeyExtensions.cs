using Calculator.Enums;
using System.Linq;

namespace Calculator.Helpers
{
    public static class CalculatorKeyExtensions
    {
        private static readonly CalculatorKeys[] OperationKeys =
        {
            CalculatorKeys.Plus,
            CalculatorKeys.Minus,
            CalculatorKeys.Multiply,
            CalculatorKeys.Divide
        };

        private static readonly CalculatorKeys[] NumberKeys =
        {
            CalculatorKeys.Zero,
            CalculatorKeys.One,
            CalculatorKeys.Two,
            CalculatorKeys.Three,
            CalculatorKeys.Four,
            CalculatorKeys.Five,
            CalculatorKeys.Six,
            CalculatorKeys.Seven,
            CalculatorKeys.Eight,
            CalculatorKeys.Nine
        };

        public static string GetText(this CalculatorKeys key)
        {
            switch (key)
            {
                case CalculatorKeys.Zero:
                case CalculatorKeys.One:
                case CalculatorKeys.Two:
                case CalculatorKeys.Three:
                case CalculatorKeys.Four:
                case CalculatorKeys.Five:
                case CalculatorKeys.Six:
                case CalculatorKeys.Seven:
                case CalculatorKeys.Eight:
                case CalculatorKeys.Nine:
                    return ((int) key).ToString();
                case CalculatorKeys.Plus:
                    return "+";
                case CalculatorKeys.Minus:
                    return "-";
                case CalculatorKeys.Multiply:
                    return "*";
                case CalculatorKeys.Divide:
                    return "/";
                case CalculatorKeys.Point:
                    return ".";
                case CalculatorKeys.LeftParenthesis:
                    return "(";
                case CalculatorKeys.RightParenthesis:
                    return ")";
                case CalculatorKeys.Percent:
                    return "%";
                case CalculatorKeys.Caret:
                    return "^";
                default:
                    return null;
            }
        }

        public static bool IsOperationKey(this CalculatorKeys key)
        {
            return OperationKeys.Contains(key);
        }

        public static bool IsOperationKey(this string key)
        {
            return key == CalculatorKeys.Minus.GetText() ||
                   key == CalculatorKeys.Plus.GetText() ||
                   key == CalculatorKeys.Divide.GetText() ||
                   key == CalculatorKeys.Multiply.GetText();
        }

        public static bool IsNumber(this CalculatorKeys key)
        {
            return NumberKeys.Contains(key);
        }
    }
}