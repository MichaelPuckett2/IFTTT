using IFTTT.Enums;
using System;

namespace IFTTT.Expressions.MathExpressions
{
    internal static class MathExpressionHelper
    {
        public static int Result(int A, MathOperator mathOperator, int B)
        {
            switch (mathOperator)
            {
                case MathOperator.Multiply:
                    return A * B;
                case MathOperator.Divide:
                    return A / B;
                case MathOperator.Mod:
                    return A % B;
                case MathOperator.Add:
                    return A + B;
                case MathOperator.Substract:
                    return A - B;
                default:
                    throw new ArithmeticException($"No possible way to {mathOperator} {nameof(IntegerMathExpression)}");
            }
        }

        public static double Result(double A, MathOperator mathOperator, double B)
        {
            switch (mathOperator)
            {
                case MathOperator.Multiply:
                    return A * B;
                case MathOperator.Divide:
                    if (B == 0) return double.NaN;
                    return A / B;
                case MathOperator.Mod:
                    return A % B;
                case MathOperator.Add:
                    return A + B;
                case MathOperator.Substract:
                    return A - B;
                default:
                    throw new ArithmeticException($"No possible way to {mathOperator} {nameof(DoubleMathExpression)}");
            }
        }

        public static string Result(string A, MathOperator mathOperator, string B)
        {
            switch (mathOperator)
            {
                case MathOperator.Add:
                    return A + B;
                case MathOperator.Multiply:
                case MathOperator.Divide:
                case MathOperator.Mod:
                case MathOperator.Substract:
                default:
                    throw new ArithmeticException($"No possible way to {mathOperator} {nameof(StringMathExpression)}");
            }
        }

        public static TimeSpan Result(TimeSpan A, MathOperator mathOperator, TimeSpan B)
        {
            switch (mathOperator)
            {
                case MathOperator.Add:
                    return A + B;
                case MathOperator.Substract:
                    return A - B;
                case MathOperator.Multiply:
                case MathOperator.Divide:
                case MathOperator.Mod:
                default:
                    throw new ArithmeticException($"No possible way to {mathOperator} {nameof(TimeSpanMathExpression)}");
            }
        }
    }
}
