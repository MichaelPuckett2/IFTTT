using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class StringMathExpression : IStringExpression
    {
        public string A { get; set; }
        public string B { get; set; }
        public MathOperator Operator { get; set; }
        public string Result() => MathExpressionHelper.Result(A, Operator, B);
    }
}
