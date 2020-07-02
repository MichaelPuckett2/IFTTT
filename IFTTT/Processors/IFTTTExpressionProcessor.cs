using IFTTT.Constants;
using IFTTT.Interfaces;
using IFTTT.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IFTTT.Processors
{
    public class IFTTTExpressionProcessor
    {
        private const int MaxDegreesOfParallism = 8;
        private readonly IFTTTLogger expressionLogger;

        public IFTTTExpressionProcessor(IFTTTLogger expressionLogger = null)
        {
            this.expressionLogger = expressionLogger;
        }

        public bool ProcessExpressionGroup(IFTTTExpressionGroup expressionGroup)
        {
            bool boolean = ProcessExpressions(expressionGroup.Expressions, expressionGroup.IsShorted, expressionGroup.Circuit);
            if (expressionGroup.IsShorted && !boolean) return boolean;

            switch (expressionGroup.Circuit)
            {
                case Circuit.Parallel:
                    boolean = ProcessLogicalParallel(expressionGroup, boolean);
                    break;

                case Circuit.Series:
                default:
                    boolean = ProcessLogicalSeries(expressionGroup, boolean);
                    break;
            }

            expressionLogger?.LogAsync(expressionGroup, boolean);
            return boolean;
        }

        public bool ProcessExpressions(IEnumerable<IFTTTExpression> expressions, bool isShorted, Circuit circuit)
        {
            var boolean = true; //Always assume true to start.
            if (!(expressions?.Any() ?? false)) return boolean;
            switch (circuit)
            {
                case Circuit.Parallel:
                    Parallel.ForEach(expressions, new ParallelOptions() { MaxDegreeOfParallelism = MaxDegreesOfParallism }, (expression, loopState) =>
                    {
                        var result = ProcessExpression(expression);
                        if (isShorted && !result) loopState.Break();
                        boolean = result && boolean;
                    });
                    break;

                case Circuit.Series:
                default:
                    foreach (var expression in expressions)
                    {
                        boolean = ProcessExpression(expression) && boolean;
                        if (isShorted && !boolean) return boolean;
                    }
                    break;
            }
            return boolean;
        }

        public bool ProcessExpression(IFTTTExpression expression)
        {
            bool result;
            switch (expression.EqualityOperator)
            {
                case EqualityOperator.NotEquals:
                    result = !(expression.ExpressionA?.Equals(expression.ExpressionB) ?? expression.ExpressionB == null);
                    break;

                case EqualityOperator.Equals:
                default:
                    result = (expression.ExpressionA?.Equals(expression.ExpressionB) ?? expression.ExpressionB == null);
                    break;
            }
            expressionLogger?.LogAsync(expression, result);
            return result;
        }

        private bool ProcessLogicalParallel(IFTTTExpressionGroup expressionGroup, bool boolean)
        {
            switch (expressionGroup.LogicalOperator)
            {
                case LogicalOperator.Or:
                    boolean = ProcessExpressionGroupInParallel(expressionGroup, boolean) || boolean;
                    break;
                case LogicalOperator.And:
                default:
                    boolean = ProcessExpressionGroupInParallel(expressionGroup, boolean) && boolean;
                    break;
            }

            return boolean;
        }

        private bool ProcessLogicalSeries(IFTTTExpressionGroup expressionGroup, bool boolean)
        {
            switch (expressionGroup.LogicalOperator)
            {
                case LogicalOperator.Or:
                    boolean = ProcessExpressionGroupInSeries(expressionGroup, boolean) || boolean;
                    break;
                case LogicalOperator.And:
                default:
                    boolean = ProcessExpressionGroupInSeries(expressionGroup, boolean) && boolean;
                    break;
            }

            return boolean;
        }

        private bool ProcessExpressionGroupInSeries(IFTTTExpressionGroup expressionGroup, bool boolean)
        {
            foreach (var group in expressionGroup.ExpressionGroups ?? Enumerable.Empty<IFTTTExpressionGroup>())
            {
                boolean = ProcessExpressionGroup(group) && boolean;
                if (expressionGroup.IsShorted && !boolean) break;
            }

            return boolean;
        }

        private bool ProcessExpressionGroupInParallel(IFTTTExpressionGroup expressionGroup, bool boolean)
        {
            if (!(expressionGroup.ExpressionGroups?.Any() ?? false)) return boolean;

            if (expressionGroup.IsShorted)
            {
                Parallel.ForEach(expressionGroup.ExpressionGroups, new ParallelOptions() { MaxDegreeOfParallelism = MaxDegreesOfParallism }, (group, loopState) =>
                {
                    if (!ProcessExpressionGroup(group))
                    {
                        loopState.Break();
                        boolean = false;
                    }
                });
            }
            else
            {
                Parallel.ForEach(expressionGroup.ExpressionGroups, new ParallelOptions() { MaxDegreeOfParallelism = MaxDegreesOfParallism }, group =>
                {
                    boolean = ProcessExpressionGroup(group) && boolean;
                });
            }

            return boolean;
        }
    }
}
