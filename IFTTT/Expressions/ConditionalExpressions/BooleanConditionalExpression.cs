using IFTTT.Enums;

namespace IFTTT.Expressions.ConditionalExpressions
{
    public class BooleanConditionalExpression : IExpression<bool, ConditionalOperator, bool>, IExpressionResult<bool>
    {
        public bool A { get; set; }
        public bool B { get; set; }
        public ConditionalOperator Operator { get; set; }
        public bool Result() => Operator switch
        {
            ConditionalOperator.And => A && B,
            _ => A || B,
        };
    }
}
