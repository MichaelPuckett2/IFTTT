using IFTTT.Enums;

namespace IFTTT.Expressions.ConditionalExpressions
{
    public class BooleanConditionalExpressionA : IExpression<IExpressionResult<bool>, ConditionalOperator, bool>, IExpressionResult<bool>
    {
        public IExpressionResult<bool> A { get; set; }
        public bool B { get; set; }
        public ConditionalOperator Operator { get; set; }
        public bool Result() => Operator switch
        {
            ConditionalOperator.And => A.Result() && B,
            _ => A.Result() || B,
        };
    }
}
