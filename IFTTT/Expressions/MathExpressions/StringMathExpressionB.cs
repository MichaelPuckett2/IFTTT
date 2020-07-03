﻿using IFTTT.Enums;

namespace IFTTT.Expressions.MathExpressions
{
    public class StringMathExpressionB : IStringExpressionB
    {
        public string A { get; set; }
        public IExpressionResult<string> B { get; set; }
        public MathOperator Operator { get; set; }
        public string Result() => MathExpressionHelper.Result(A, Operator, B.Result());
    }
}
