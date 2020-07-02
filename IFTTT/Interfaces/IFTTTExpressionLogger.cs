using IFTTT.Models;
using System.Threading.Tasks;

namespace IFTTT.Interfaces
{
    public interface IFTTTLogger
    {
        Task LogAsync(IFTTTExpression expression, bool expressionResult);
        Task LogAsync(IFTTTExpressionGroup group, bool expressionResult);
    }
}
