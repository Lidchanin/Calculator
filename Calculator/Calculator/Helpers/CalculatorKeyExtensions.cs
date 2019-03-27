using Calculator.Enums;
using System.Linq;

namespace Calculator.Helpers
{
    public static class CalculatorKeyExtensions
    {
        private static readonly CalculatorKey[] OperationKeys =
        {
            CalculatorKey.Plus,
            CalculatorKey.Minus,
            CalculatorKey.Multiply,
            CalculatorKey.Divide
        };

        private static readonly CalculatorKey[] NumberKeys =
        {
            CalculatorKey.Zero,
            CalculatorKey.One,
            CalculatorKey.Two,
            CalculatorKey.Three,
            CalculatorKey.Four,
            CalculatorKey.Five,
            CalculatorKey.Six,
            CalculatorKey.Seven,
            CalculatorKey.Eight,
            CalculatorKey.Nine
        };

        public static string GetText(this CalculatorKey key)
        {
            switch (key)
            {
                case CalculatorKey.Zero:
                case CalculatorKey.One:
                case CalculatorKey.Two:
                case CalculatorKey.Three:
                case CalculatorKey.Four:
                case CalculatorKey.Five:
                case CalculatorKey.Six:
                case CalculatorKey.Seven:
                case CalculatorKey.Eight:
                case CalculatorKey.Nine:
                    return ((int) key).ToString();
                case CalculatorKey.Plus:
                    return "+";
                case CalculatorKey.Minus:
                    return "-";
                case CalculatorKey.Multiply:
                    return "*";
                case CalculatorKey.Divide:
                    return "/";
                case CalculatorKey.Point:
                    return ".";
                case CalculatorKey.LeftBracket:
                    return "(";
                case CalculatorKey.RightBracket:
                    return ")";
                default:
                    return null;
            }
        }

        public static bool IsOperationKey(this CalculatorKey key)
        {
            return OperationKeys.Contains(key);
        }

        public static bool IsOperationKey(this string key)
        {
            return key == CalculatorKey.Minus.GetText() ||
                   key == CalculatorKey.Plus.GetText() ||
                   key == CalculatorKey.Divide.GetText() ||
                   key == CalculatorKey.Multiply.GetText();
        }

        public static bool IsNumber(this CalculatorKey key)
        {
            return NumberKeys.Contains(key);
        }
    }
}