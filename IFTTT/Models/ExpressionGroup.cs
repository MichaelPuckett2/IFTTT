using IFTTT.Constants;
using System.Collections.Generic;

namespace IFTTT.Models
{
    public class ExpressionGroup
    {
        private static int counter;
        public ExpressionGroup()
        {
            counter++;
            if (string.IsNullOrEmpty(Name)) Name = $"{nameof(ExpressionGroup)}:{counter}";
        }

        public string Name { get; set; }

        public Circuit Circuit { get; set; } = Circuit.Series;
        public bool IsShorted { get; set; } = true;
        public IEnumerable<Expression> Expressions { get; set; }
        public LogicalOperator LogicalOperator { get; set; } = LogicalOperator.And;
        public IEnumerable<ExpressionGroup> ExpressionGroups { get; set; }
    }
}
