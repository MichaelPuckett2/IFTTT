using IFTTT.Enums;
using System;

namespace IFTTT.Expressions.MathExpressions
{
    internal static class MathExpressionHelper
    {
        public static int Result(int A, MathOperator mathOperator, int B)
        {
            return mathOperator switch
            {
                MathOperator.Multiply => A * B,
                MathOperator.Divide => A / B,
                MathOperator.Mod => A % B,
                MathOperator.Add => A + B,
                MathOperator.Substract => A - B,
                _ => throw new ArithmeticException($"No possible way to {mathOperator} {nameof(IntegerMathExpression)}"),
            };
        }

        public static double Result(double A, MathOperator mathOperator, double B)
        {
            return mathOperator switch
            {
                MathOperator.Multiply => A * B,
                MathOperator.Divide => A / B,
                MathOperator.Mod => A % B,
                MathOperator.Add => A + B,
                MathOperator.Substract => A - B,
                _ => throw new ArithmeticException($"No possible way to {mathOperator} {nameof(DoubleMathExpression)}"),
            };
        }

        public static string Result(string A, MathOperator mathOperator, string B)
        {
            return mathOperator switch
            {
                MathOperator.Add => A + B,
                _ => throw new ArithmeticException($"No possible way to {mathOperator} {nameof(StringMathExpression)}"),
            };
        }

        public static TimeSpan Result(TimeSpan A, MathOperator mathOperator, TimeSpan B)
        {
            return mathOperator switch
            {
                MathOperator.Add => A + B,
                MathOperator.Substract => A - B,
                _ => throw new ArithmeticException($"No possible way to {mathOperator} {nameof(TimeSpanMathExpression)}"),
            };
        }
    }
}
