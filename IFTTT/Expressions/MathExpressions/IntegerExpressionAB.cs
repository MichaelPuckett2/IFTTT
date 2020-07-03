using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class IntegerExpressionAB : IIntegerExpressionAB
    {
        public IIntegerExpression A { get; set; }
        public IIntegerExpression B { get; set; }
        public MathOperator Operator { get; set; }
        public int Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
