using IFTTT.Enums;

namespace IFTTT.Expressions.ConditionalExpressions
{
    public class BooleanConditionalExpressionB : IExpression<bool, ConditionalOperator, IExpressionResult<bool>>, IExpressionResult<bool>
    {
        public bool A { get; set; }
        public IExpressionResult<bool> B { get; set; }
        public ConditionalOperator Operator { get; set; }
        public bool Result() => Operator switch
        {
            ConditionalOperator.And => A && B.Result(),
            _ => A || B.Result(),
        };
    }
}
