using IFTTT.Constants;
using IFTTT.Models;
using System;
using System.Collections.Generic;

namespace IFTTT.Interfaces
{
    public interface IIFTTTExpressionProcessor
    {
        event EventHandler<IFTTTExpressionGroup> ExpressionGroupPassed;
        bool ProcessExpression(IFTTTExpression expression);
        bool ProcessExpressionGroup(IFTTTExpressionGroup expressionGroup);
        bool ProcessExpressions(IEnumerable<IFTTTExpression> expressions, bool isShorted, Circuit circuit);
    }
}