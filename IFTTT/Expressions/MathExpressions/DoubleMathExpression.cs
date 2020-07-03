using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class DoubleMathExpression : IExpression<double, MathOperator, double>, IExpressionResult<double>
    {
        public double A { get; set; }
        public double B { get; set; }
        public MathOperator Operator { get; set; }
        public double Result() => MathExpressionHelper.Result(A, Operator, B);
    }
}
