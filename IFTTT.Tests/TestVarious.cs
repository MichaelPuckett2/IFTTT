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
        private const string PassingGroup = "Passing Test Group";
        private const string LogicalPassingOrFailingGroup = "Logical Passing OR Failing Test Group";
        private const string FailingGroup = "Failing Test Group";

        static IFTTTExpressionGroup GetExpressionGroupA()
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
                Name = PassingGroup,
                Circuit = Circuit.Series,
                IsShorted = false, //force all checks
                Expressions = allExpressions
            };

            return expressionGroup;
        }
        static IFTTTExpressionGroup GetExpressionGroupB()
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
                Name = FailingGroup,
                Circuit = Circuit.Series,
                IsShorted = false, //force all checks
                Expressions = allExpressions
            };

            return expressionGroup;
        }

        [TestMethod]
        public void TestExpressionGroupsLogic()
        {
            //TODO Mock all but models and Actor

            //Arrange
            var expressionGroupA = GetExpressionGroupA(); //Meant to pass
            var expressionGroupB = GetExpressionGroupB(); //Meant to fail
            var allGroups = new IFTTTExpressionGroup
            {
                Name = LogicalPassingOrFailingGroup,
                ExpressionGroups = new List<IFTTTExpressionGroup> { expressionGroupA, expressionGroupB },
                LogicalOperator = LogicalOperator.Or //Passes if one or the other.
            };

            var traceLogger = new TraceExpressionLogger();
            var expressionProcessor = new IFTTTExpressionProcessor(traceLogger);

            //Act
            var result = expressionProcessor.ProcessExpressionGroup(allGroups);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestTriggers()
        {
            //TODO: Mock all but models and Actor

            //Arrange

            var triggers = new List<IFTTTTrigger>
            {
                new IFTTTTrigger
                {
                    ListForGroupName = PassingGroup,
                    TriggerGroupName = FailingGroup
                },
                new IFTTTTrigger
                {
                    ListForGroupName = FailingGroup,
                    TriggerGroupName = LogicalPassingOrFailingGroup
                }
            };

            var expressionGroupA = GetExpressionGroupA(); //Meant to pass
            var expressionGroupB = GetExpressionGroupB(); //Meant to fail

            var traceLogger = new TraceExpressionLogger();
            var expressionProcessor = new IFTTTExpressionProcessor(traceLogger);
            var actor = new IFTTTExpressionTriggerProcessor(expressionProcessor)
            {
                Triggers = triggers,
                ExpressionGroups = new IFTTTExpressionGroup[] { expressionGroupA, expressionGroupB }
            };

            //Act
            var result = expressionProcessor.ProcessExpressionGroup(expressionGroupA);


            //Assert
            Assert.IsTrue(result);
        }
    }
}
