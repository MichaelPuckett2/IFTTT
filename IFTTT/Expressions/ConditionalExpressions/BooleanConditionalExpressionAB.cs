using IFTTT.Enums;

namespace IFTTT.Expressions.ConditionalExpressions
{
    public class BooleanConditionalExpressionAB : IExpression<IExpressionResult<bool>, ConditionalOperator, IExpressionResult<bool>>, IExpressionResult<bool>
    {
        public IExpressionResult<bool> A { get; set; }
        public IExpressionResult<bool> B { get; set; }
        public ConditionalOperator Operator { get; set; }
        public bool Result() => Operator switch
        {
            ConditionalOperator.And => A.Result() && B.Result(),
            _ => A.Result() || B.Result(),
        };
    }
}
