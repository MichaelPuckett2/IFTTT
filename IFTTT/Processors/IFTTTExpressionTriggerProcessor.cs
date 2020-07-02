using IFTTT.Interfaces;
using IFTTT.Models;
using System.Collections.Generic;

namespace IFTTT.Processors
{
    public class IFTTTExpressionTriggerProcessor
    {
        private readonly IIFTTTExpressionProcessor expressionProcessor;

        public IFTTTExpressionTriggerProcessor(IIFTTTExpressionProcessor expressionProcessor)
        {
            this.expressionProcessor = expressionProcessor;
            this.expressionProcessor.ExpressionGroupPassed += ExpressionProcessor_ExpressionGroupPassed;
        }

        public IEnumerable<IFTTTTrigger> Triggers { get; set; }
        public IEnumerable<IFTTTExpressionGroup> ExpressionGroups { get; set; }

        private void ExpressionProcessor_ExpressionGroupPassed(object sender, IFTTTExpressionGroup e)
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
