using IFTTT.Enums;
using IFTTT.Expressions;
using IFTTT.Expressions.MathExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IFTTT.Tests.MathExpressions
{
    [TestClass]
    public class MathExpressionTests
    {
        //During these tests we switch the Operators a bit to make sure those are passing as well.

        [TestMethod]
        public void TestIntegerExpression()
        {
            //Arrange
            var actor = new IntegerMathExpression
            {
                A = 10,
                B = 10,
                Operator = MathOperator.Add
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void TestIntegerExpressionA()
        {
            //Arrange
            var expressionA = new IntegerMathExpression
            {
                A = 10,
                B = 10,
                Operator = MathOperator.Add
            };

            var actor = new IntegerMathExpressionA
            {
                A = expressionA,
                B = 10,
                Operator = MathOperator.Substract
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void TestIntegerExpressionAB()
        {
            //Arrange
            var expressionA = new IntegerMathExpression
            {
                A = 10,
                B = 10,
                Operator = MathOperator.Add
            };

            var expressionB = new IntegerMathExpression
            {
                A = 10,
                B = 10,
                Operator = MathOperator.Substract
            };

            var actor = new IntegerMathExpressionAB
            {
                A = expressionA,
                B = expressionB,
                Operator = MathOperator.Multiply
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestDoubleExpression()
        {
            //Arrange
            var actor = new DoubleMathExpression
            {
                A = 10.5,
                B = 10.5,
                Operator = MathOperator.Add
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, 21);
        }

        [TestMethod]
        public void TestDoubleExpressionA()
        {
            //Arrange
            var expressionA = new DoubleMathExpression
            {
                A = 10.5,
                B = 10.5,
                Operator = MathOperator.Add
            };

            var actor = new DoubleMathExpressionA
            {
                A = expressionA,
                B = 10.5,
                Operator = MathOperator.Substract
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, 10.5);
        }

        [TestMethod]
        public void TestDoubleExpressionAB()
        {
            //Arrange
            var expressionA = new DoubleMathExpression
            {
                A = 10.5,
                B = 10.5,
                Operator = MathOperator.Add
            };

            var expressionB = new DoubleMathExpression
            {
                A = 10.5,
                B = 10.5,
                Operator = MathOperator.Substract
            };

            var actor = new DoubleMathExpressionAB
            {
                A = expressionA,
                B = expressionB,
                Operator = MathOperator.Multiply
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestStringExpression()
        {
            //Arrange
            var expressionA = new StringMathExpression
            {
                A = "Michael ",
                B = "Brian ",
                Operator = MathOperator.Add
            };

            var expressionB = new StringMathExpressionA
            {
                A = expressionA,
                B = "Puckett",
                Operator = MathOperator.Add
            };

            var actor = new StringMathExpressionB
            {
                A = "Mr. ",
                B = expressionB,
                Operator = MathOperator.Add
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, "Mr. Michael Brian Puckett");
        }

        [TestMethod]
        public void TestStringFailExpression()
        {
            //Arrange
            var actor = new StringMathExpression
            {
                A = "Michael ",
                B = "Brian ",
                Operator = MathOperator.Substract
            };

            //Act
            //Assert
            Assert.ThrowsException<ArithmeticException>(actor.Result);
        }

        [TestMethod]
        public void TestTimeSpanExpression()
        {
            //Arrange
            var expressionA = new TimeSpanMathExpression
            {
                A = TimeSpan.FromHours(1),
                B = TimeSpan.FromHours(1),
                Operator = MathOperator.Add
            };

            var expressionB = new TimeSpanMathExpressionA
            {
                A = expressionA,
                B = TimeSpan.FromHours(1),
                Operator = MathOperator.Substract
            };

            var actor = new TimeSpanMathExpressionB
            {
                A = TimeSpan.FromHours(1),
                B = expressionB,
                Operator = MathOperator.Add
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, TimeSpan.FromHours(2));
        }

        [TestMethod]
        public void TestTimeSpanFailExpression()
        {
            //Arrange
            var actor = new TimeSpanMathExpression
            {
                A = TimeSpan.Zero,
                B = TimeSpan.Zero,
                Operator = MathOperator.Multiply
            };

            //Act
            //Assert
            Assert.ThrowsException<ArithmeticException>(() => actor.Result());
        }

        [TestMethod]
        public void TestCustomExpression()
        {
            //Arrange
            var actor = new TestWeirdExpression
            {
                A = true,
                B = false,
                Operator = ConditionalOperator.And
            };

            //Act
            var result = actor.Result();

            //Assert
            Assert.AreEqual(result, "One is Not True");
        }

        internal class TestWeirdExpression : IExpression<bool, ConditionalOperator, bool>, IExpressionResult<string>
        {
            public bool A { get; set; }
            public bool B { get; set; }
            public ConditionalOperator Operator { get; set; }
            public string Result()
            {
                return Operator switch
                {
                    ConditionalOperator.And => A && B ? "Both True" : "One is Not True",
                    _ => A || B ? "One or Both are True" : "Neither is True",
                };
            }
        }
    }
}
