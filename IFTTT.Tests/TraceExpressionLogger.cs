using IFTTT.Interfaces;
using IFTTT.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IFTTT.Tests
{
    public class TraceExpressionLogger : IExpressionLogger
    {
        private const string NullString = "Null";

        public Task LogAsync(Expression expression, bool expressionResult) => Task.Run(() =>
        {
            Trace.WriteLine($"Expression:\t\t\t\t{expression.ExpressionA ?? NullString} {expression.EqualityOperator} {expression.ExpressionB ?? NullString} = {expressionResult}");
        });

        public Task LogAsync(ExpressionGroup group, bool expressionResult) => Task.Run(() =>
        {
            Trace.WriteLine($"Expression Group:\t\t{group.Name} = {expressionResult}");
        });
    }
}
