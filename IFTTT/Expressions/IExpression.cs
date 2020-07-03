using System;

namespace IFTTT.Expressions
{
    public interface IExpression<TA, TOperator, TB> where TOperator : Enum
    {
        TA A { get; }
        TB B { get; }
        TOperator Operator { get; }
    }
}
