using IFTTT.Enums;
using System;

namespace IFTTT.Expressions.MathExpressions
{
    public class TimeSpanMathExpressionAB : IExpression<IExpressionResult<TimeSpan>, MathOperator, IExpressionResult<TimeSpan>>, IExpressionResult<TimeSpan>
    {
        public IExpressionResult<TimeSpan> A { get; set; }
        public IExpressionResult<TimeSpan> B { get; set; }
        public MathOperator Operator { get; set; }
        public TimeSpan Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
