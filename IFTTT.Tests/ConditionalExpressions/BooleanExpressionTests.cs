using IFTTT.Enums;
using IFTTT.Expressions;
using IFTTT.Expressions.ConditionalExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IFTTT.Tests.ConditionalExpressions
{
    [TestClass]
    public class BooleanExpressionTests
    {
        [TestMethod]
        public void TestBooleanExpression()
        {
            //Arrange
            var actor = new BooleanConditionalExpression
            {
                A = true,
                B = false,
                Operator = ConditionalOperator.Or
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCustomBooleanExpression()
        {
            //Arrange
            var name = "Michael";
            var age = 40;

            var minimumLengthTest = new Predicate<string>((x) => x.Length > 6);
            var minimumAgeTest = new Predicate<int>((x) => x > 21);

            var actor = new FuncBooleanTest
            {
                AValue = name,
                Operator = ConditionalOperator.And,
                BValue = age,
                A = minimumLengthTest,
                B = minimumAgeTest
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.IsTrue(result);
        }

        class FuncBooleanTest : IExpression<Predicate<string>, ConditionalOperator, Predicate<int>>, IExpressionResult<bool>
        {
            public string AValue { get; set; }
            public int BValue { get; set; }
            public Predicate<string> A { get; set; }
            public Predicate<int> B { get; set; }
            public ConditionalOperator Operator { get; set; }
            public bool Result() => Operator switch
            {
                ConditionalOperator.Or => A.Invoke(AValue) || B.Invoke(BValue),
                _ => A.Invoke(AValue) && B.Invoke(BValue)
            };
        }
    }
}
