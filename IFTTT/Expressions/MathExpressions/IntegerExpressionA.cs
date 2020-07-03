using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class IntegerExpressionA : IIntegerExpressionA
    {
        public IIntegerExpression A { get; set; }
        public int B { get; set; }
        public MathOperator Operator { get; set; }
        public int Result() => MathExpressionHelper.Result(A.Result(), Operator, B);
    }
}
