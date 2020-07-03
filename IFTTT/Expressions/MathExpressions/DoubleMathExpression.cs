using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class DoubleMathExpression : IDoubleExpression
    {
        public double A { get; set; }
        public double B { get; set; }
        public MathOperator Operator { get; set; }
        public double Result() => MathExpressionHelper.Result(A, Operator, B);
    }
}
