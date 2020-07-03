using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class StringMathExpressionA : IExpression<IExpressionResult<string>, MathOperator, string>, IExpressionResult<string>
    {
        public IExpressionResult<string> A { get; set; }
        public string B { get; set; }
        public MathOperator Operator { get; set; }
        public string Result() => MathExpressionHelper.Result(A.Result(), Operator, B);
    }
}
