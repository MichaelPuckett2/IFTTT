using IFTTT.Enums;
using System;

namespace IFTTT.Expressions.MathExpressions
{
    public class TimeSpanMathExpression : IExpression<TimeSpan, MathOperator, TimeSpan>, IExpressionResult<TimeSpan>
    {
        public TimeSpan A { get; set; }
        public TimeSpan B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A, Operator, B);
    }
}
