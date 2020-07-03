using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class IntegerMathExpression : IExpression<int, MathOperator, int>, IExpressionResult<int>
    {
        public int A { get; set; }
        public int B { get; set; }
        public MathOperator Operator { get; set; }
        public int Result() => MathExpressionHelper.Result(A, Operator, B);
    }
}
