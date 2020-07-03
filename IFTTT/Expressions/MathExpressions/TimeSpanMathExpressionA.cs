using IFTTT.Enums;
using System;

namespace IFTTT.Expressions.MathExpressions
{
    public class TimeSpanMathExpressionA : IExpression<IExpressionResult<TimeSpan>, MathOperator, TimeSpan>, IExpressionResult<TimeSpan>
    {
        public IExpressionResult<TimeSpan> A { get; set; }
        public TimeSpan B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A.Result(), Operator, B);
    }
}
