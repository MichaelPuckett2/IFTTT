using IFTTT.Constants;

namespace IFTTT.Models
{
    public class Expression
    {
        public object ExpressionA { get; set; }
        public EqualityOperator EqualityOperator { get; set; }
        public object ExpressionB { get; set; }
    }    
}
