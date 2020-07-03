using IFTTT.Enums;
using System;

namespace IFTTT.Expressions
{
    public interface IExpression { } //I don't like this. I'm trying to collect all expressions into a single type.
    public interface IExpression<TA, TOperator, TB, TResult> : IExpression where TOperator : Enum
    {
        TA A { get; }
        TB B { get; }
        TOperator Operator { get; }
        TResult Result();
    }
    public interface IIntegerExpression : IExpression<int, MathOperator, int, int> { }
    public interface IIntegerExpressionA : IExpression<IIntegerExpression, MathOperator, int, int> { }
    public interface IIntegerExpressionAB : IExpression<IIntegerExpression, MathOperator, IIntegerExpression, int> { }
    public interface IDoubleExpression : IExpression<double, MathOperator, double, double> { }
    public interface IDoubleExpressionA : IExpression<IDoubleExpression, MathOperator, double, double> { }
    public interface IDoubleExpressionAB : IExpression<IDoubleExpression, MathOperator, IDoubleExpression, double> { }
}
