using IFTTT.Enums;
using System;

namespace IFTTT.Expressions.MathExpressions
{
    public class TimeSpanMathExpression : ITimeSpanExpression
    {
        public TimeSpan A { get; set; }
        public TimeSpan B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A, Operator, B);
    }

    public class TimeSpanMathExpressionA : ITimeSpanExpressionA
    {
        public IExpressionResult<TimeSpan> A { get; set; }
        public TimeSpan B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A.Result(), Operator, B);
    }

    public class TimeSpanMathExpressionB : ITimeSpanExpressionB
    {
        public TimeSpan A { get; set; }
        public IExpressionResult<TimeSpan> B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A, Operator, B.Result());
    }

    public class TimeSpanMathExpressionAB : ITimeSpanExpressionAB
    {
        public IExpressionResult<TimeSpan> A { get; set; }
        public IExpressionResult<TimeSpan> B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
