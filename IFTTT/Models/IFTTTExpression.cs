using IFTTT.Constants;

namespace IFTTT.Models
{
    public class IFTTTExpression
    {
        public object ExpressionA { get; set; }
        public EqualityOperator EqualityOperator { get; set; }
        public object ExpressionB { get; set; }
    }    
}
