using IFTTT.Enums;
using System;

namespace IFTTT.Expressions
{
    public interface IExpressionResult<T> { T Result(); }
    public interface IExpression<TA, TOperator, TB> where TOperator : Enum
    {
        TA A { get; }
        TB B { get; }
        TOperator Operator { get; }
    }

    public interface IIntegerExpression : IExpression<int, MathOperator, int>, IExpressionResult<int> { }
    public interface IIntegerExpressionA : IExpression<IExpressionResult<int>, MathOperator, int>, IExpressionResult<int> { }
    public interface IIntegerExpressionB : IExpression<int, MathOperator, IExpressionResult<int>>, IExpressionResult<int> { }
    public interface IIntegerExpressionAB : IExpression<IExpressionResult<int>, MathOperator, IExpressionResult<int>>, IExpressionResult<int> { }

    public interface IDoubleExpression : IExpression<double, MathOperator, double>, IExpressionResult<double> { }
    public interface IDoubleExpressionA : IExpression<IExpressionResult<double>, MathOperator, double>, IExpressionResult<double> { }
    public interface IDoubleExpressionB : IExpression<double, MathOperator, IExpressionResult<double>>, IExpressionResult<double> { }
    public interface IDoubleExpressionAB : IExpression<IExpressionResult<double>, MathOperator, IExpressionResult<double>>, IExpressionResult<double> { }

    public interface IStringExpression : IExpression<string, MathOperator, string>, IExpressionResult<string> { }
    public interface IStringExpressionA : IExpression<IExpressionResult<string>, MathOperator, string>, IExpressionResult<string> { }
    public interface IStringExpressionB : IExpression<string, MathOperator, IExpressionResult<string>>, IExpressionResult<string> { }
    public interface IStringExpressionAB : IExpression<IExpressionResult<string>, MathOperator, IExpressionResult<string>>, IExpressionResult<string> { }

    public interface ITimeSpanExpression : IExpression<TimeSpan, MathOperator, TimeSpan>, IExpressionResult<TimeSpan> { }    
    public interface ITimeSpanExpressionA : IExpression<IExpressionResult<TimeSpan>, MathOperator, TimeSpan>, IExpressionResult<TimeSpan> { }    
    public interface ITimeSpanExpressionB : IExpression<TimeSpan, MathOperator, IExpressionResult<TimeSpan>>, IExpressionResult<TimeSpan> { }    
    public interface ITimeSpanExpressionAB : IExpression<IExpressionResult<TimeSpan>, MathOperator, IExpressionResult<TimeSpan>>, IExpressionResult<TimeSpan> { }
}
