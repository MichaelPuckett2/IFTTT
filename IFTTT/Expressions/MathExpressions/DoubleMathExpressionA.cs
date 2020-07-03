using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class DoubleMathExpressionA : IExpression<IExpressionResult<double>, MathOperator, double>, IExpressionResult<double>
    {
        public IExpressionResult<double> A { get; set; }
        public double B { get; set; }
        public MathOperator Operator { get; set; }
        public double Result() => MathExpressionHelper.Result(A.Result(), Operator, B);
    }
}
