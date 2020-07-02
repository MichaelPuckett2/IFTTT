using IFTTT.Constants;
using IFTTT.Models;
using System;
using System.Collections.Generic;

namespace IFTTT.Interfaces
{
    public interface IExpressionProcessor
    {
        event EventHandler<ExpressionGroup> ExpressionGroupPassed;
        bool ProcessExpression(Expression expression);
        bool ProcessExpressionGroup(ExpressionGroup expressionGroup);
        bool ProcessExpressions(IEnumerable<Expression> expressions, bool isShorted, Circuit circuit);
    }
}