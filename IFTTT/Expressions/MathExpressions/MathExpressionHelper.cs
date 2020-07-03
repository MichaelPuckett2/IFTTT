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
                    throw new ArithmeticException($"No possible way to {mathOperator} {nameof(IntegerExpression)}");
            }
        }

        public static double Result(double A, MathOperator mathOperator, double B)
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
                    throw new ArithmeticException($"No possible way to {mathOperator} {nameof(DoubleExpression)}");
            }
        }
    }
}
