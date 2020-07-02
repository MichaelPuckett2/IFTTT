﻿namespace IFTTT.Models
{
    public class IFTTTTypeExpression<T> : IFTTTExpression
    {
        public new T ExpressionA
        {
            get => (T)base.ExpressionA;
            set => base.ExpressionA = value;
        }
        public new T ExpressionB
        {
            get => (T)base.ExpressionB;
            set => base.ExpressionB = value;
        }
    }
}
