using IFTTT.Enums;
using IFTTT.Expressions.ConditionalExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
