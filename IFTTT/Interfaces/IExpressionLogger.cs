using IFTTT.Models;
using System.Threading.Tasks;

namespace IFTTT.Interfaces
{
    public interface IExpressionLogger
    {
        Task LogAsync(Expression expression, bool expressionResult);
        Task LogAsync(ExpressionGroup group, bool expressionResult);
    }
}
