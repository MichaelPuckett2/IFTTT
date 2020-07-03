using IFTTT.Enums;
using System;

namespace IFTTT.Expressions.MathExpressions
{
    public class TimeSpanMathExpressionB : IExpression<TimeSpan, MathOperator, IExpressionResult<TimeSpan>>, IExpressionResult<TimeSpan>
    {
        public TimeSpan A { get; set; }
        public IExpressionResult<TimeSpan> B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A, Operator, B.Result());
    }
}
