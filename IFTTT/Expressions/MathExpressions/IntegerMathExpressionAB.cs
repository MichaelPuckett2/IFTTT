using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class IntegerMathExpressionAB : IIntegerExpressionAB
    {
        public IExpressionResult<int> A { get; set; }
        public IExpressionResult<int> B { get; set; }
        public MathOperator Operator { get; set; }
        public int Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
