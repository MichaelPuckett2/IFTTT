﻿using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class IntegerMathExpressionAB : IExpression<IExpressionResult<int>, MathOperator, IExpressionResult<int>>, IExpressionResult<int>
    {
        public IExpressionResult<int> A { get; set; }
        public IExpressionResult<int> B { get; set; }
        public MathOperator Operator { get; set; }
        public int Result() => MathExpressionHelper.Result(A.Result(), Operator, B.Result());
    }
}
