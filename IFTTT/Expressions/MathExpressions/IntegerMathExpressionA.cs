using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class IntegerMathExpressionA : IExpression<IExpressionResult<int>, MathOperator, int>, IExpressionResult<int>
    {
        public IExpressionResult<int> A { get; set; }
        public int B { get; set; }
        public MathOperator Operator { get; set; }
        public int Result() => MathExpressionHelper.Result(A.Result(), Operator, B);
    }
}
