using IFTTT.Constants;
using IFTTT.Models;
using IFTTT.Processors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IFTTT.Tests
{
    [TestClass]
    public class TestVarious
    {
        [TestMethod]
        public void JustTestingVarious()
        {
            //Arrange
            IFTTTExpressionGroup expressionGroupA = ArrangeGroupA(); //Meant to pass
            IFTTTExpressionGroup expressionGroupB = ArrangeGroupB(); //Meant to fail
            IFTTTExpressionGroup allGroups = new IFTTTExpressionGroup
            {
                Name = "Logical Passing OR Failing Test Group",
                ExpressionGroups = new List<IFTTTExpressionGroup> { expressionGroupA, expressionGroupB },
                LogicalOperator = LogicalOperator.Or //Passes if one or the other.
            };

            var expressionProcessor = new IFTTTExpressionProcessor(new TraceExpressionLogger());

            //Act
            var result = expressionProcessor.ProcessExpressionGroup(allGroups);

            //Assert
            Assert.IsTrue(result);
        }

        private static IFTTTExpressionGroup ArrangeGroupA()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 40
            };

            var expression1 = new IFTTTPropertyExpression<string>(person, nameof(person.FirstName), EqualityOperator.NotEquals, "Doe");
            var expression2 = new IFTTTPropertyExpression<string>(person, nameof(person.LastName), EqualityOperator.NotEquals, null);
            var expression3 = new IFTTTPropertyExpression<int>(person, nameof(person.Age), EqualityOperator.Equals, 40);
            var allExpressions = new List<IFTTTExpression> { expression1, expression2, expression3 };

            var expressionGroup = new IFTTTExpressionGroup
            {
                Name = "Passing Test Group",
                Circuit = Circuit.Series,
                IsShorted = false, //force all checks
                Expressions = allExpressions
            };

            return expressionGroup;
        }

        private static IFTTTExpressionGroup ArrangeGroupB()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = null,
                Age = 40
            };

            var expression1 = new IFTTTPropertyExpression<string>(person, nameof(person.FirstName), EqualityOperator.NotEquals, "John");
            var expression2 = new IFTTTPropertyExpression<string>(person, nameof(person.LastName), EqualityOperator.NotEquals, null);
            var expression3 = new IFTTTPropertyExpression<int>(person, nameof(person.Age), EqualityOperator.Equals, 40); 
            var allExpressions = new List<IFTTTExpression> { expression1, expression2, expression3 };

            var expressionGroup = new IFTTTExpressionGroup
            {
                Name = "Failing Test Group",
                Circuit = Circuit.Series,
                IsShorted = false, //force all checks
                Expressions = allExpressions
            };

            return expressionGroup;
        }
    }
}
