using IFTTT.Interfaces;
using IFTTT.Models;
using System.Collections.Generic;
using System.Linq;

namespace IFTTT.Processors
{
    public class ExpressionTriggerProcessor
    {
        private readonly IExpressionProcessor expressionProcessor;

        public ExpressionTriggerProcessor(IExpressionProcessor expressionProcessor)
        {
            this.expressionProcessor = expressionProcessor;
            this.expressionProcessor.ExpressionGroupPassed += ExpressionProcessor_ExpressionGroupPassed;
        }

        public IEnumerable<Trigger> Triggers { get; set; }
        public IEnumerable<ExpressionGroup> ExpressionGroups { get; set; }

        private void ExpressionProcessor_ExpressionGroupPassed(object sender, ExpressionGroup e)
        {
            var trigger = Triggers.FirstOrDefault(x => x.ListForGroupName == e.Name);
            if (trigger != null)
            {
                var group = ExpressionGroups.FirstOrDefault(x => x.Name == trigger.TriggerGroupName);
                if (group != null) expressionProcessor.ProcessExpressionGroup(group);
            }
        }
    }
}
