using IFTTT.Constants;
using System.Collections.Generic;

namespace IFTTT.Models
{
    public class IFTTTExpressionGroup
    {
        private static int counter;
        public IFTTTExpressionGroup()
        {
            counter++;
            if (string.IsNullOrEmpty(Name)) Name = $"{nameof(IFTTTExpressionGroup)}:{counter}";
        }

        public string Name { get; set; }

        public Circuit Circuit { get; set; } = Circuit.Series;
        public bool IsShorted { get; set; } = true;
        public IEnumerable<IFTTTExpression> Expressions { get; set; }
        public LogicalOperator LogicalOperator { get; set; } = LogicalOperator.And;
        public IEnumerable<IFTTTExpressionGroup> ExpressionGroups { get; set; }
    }
}
