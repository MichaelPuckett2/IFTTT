using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class DoubleMathExpressionAB : IExpression<IExpressionResult<double>, MathOperator, IExpressionResult<double>>, IExpressionResult<double>
    {
        public IExpressionResult<double> A { get; set; }
        public IExpressionResult<double> B { get; set; }
        public MathOperator Operator { get; set; }
        public double Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
