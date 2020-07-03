using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class StringMathExpressionAB : IExpression<IExpressionResult<string>, MathOperator, IExpressionResult<string>>, IExpressionResult<string>
    {
        public IExpressionResult<string> A { get; set; }
        public IExpressionResult<string> B { get; set; }
        public MathOperator Operator { get; set; }
        public string Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
