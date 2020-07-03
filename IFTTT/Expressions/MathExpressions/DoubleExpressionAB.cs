using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class DoubleExpressionAB : IDoubleExpressionAB
    {
        public IDoubleExpression A { get; set; }
        public IDoubleExpression B { get; set; }
        public MathOperator Operator { get; set; }
        public double Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
