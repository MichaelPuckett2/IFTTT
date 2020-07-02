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

        static ExpressionGroup GetExpressionGroupA()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 40
            };

            var expression1 = new PropertyExpression<string>(person, nameof(person.FirstName), EqualityOperator.NotEquals, "Doe");
            var expression2 = new PropertyExpression<string>(person, nameof(person.LastName), EqualityOperator.NotEquals, null);
            var expression3 = new PropertyExpression<int>(person, nameof(person.Age), EqualityOperator.Equals, 40);
            var allExpressions = new List<Expression> { expression1, expression2, expression3 };

            var expressionGroup = new ExpressionGroup
            {
                Name = PassingGroup,
                Circuit = Circuit.Series,
                IsShorted = false, //force all checks
                Expressions = allExpressions
            };

            return expressionGroup;
        }
        static ExpressionGroup GetExpressionGroupB()
        {
            var person = new Person
            {
                FirstName = "John",
                LastName = null,
                Age = 40
            };

            var expression1 = new PropertyExpression<string>(person, nameof(person.FirstName), EqualityOperator.NotEquals, "John");
            var expression2 = new PropertyExpression<string>(person, nameof(person.LastName), EqualityOperator.NotEquals, null);
            var expression3 = new PropertyExpression<int>(person, nameof(person.Age), EqualityOperator.Equals, 40);
            var allExpressions = new List<Expression> { expression1, expression2, expression3 };

            var expressionGroup = new ExpressionGroup
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
            var allGroups = new ExpressionGroup
            {
                Name = LogicalPassingOrFailingGroup,
                ExpressionGroups = new List<ExpressionGroup> { expressionGroupA, expressionGroupB },
                LogicalOperator = LogicalOperator.Or //Passes if one or the other.
            };

            var traceLogger = new TraceExpressionLogger();
            var expressionProcessor = new ExpressionProcessor(traceLogger);

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

            var triggers = new List<Trigger>
            {
                new Trigger
                {
                    ListForGroupName = PassingGroup,
                    TriggerGroupName = FailingGroup
                },
                new Trigger
                {
                    ListForGroupName = FailingGroup,
                    TriggerGroupName = LogicalPassingOrFailingGroup
                }
            };

            var expressionGroupA = GetExpressionGroupA(); //Meant to pass
            var expressionGroupB = GetExpressionGroupB(); //Meant to fail

            var traceLogger = new TraceExpressionLogger();
            var expressionProcessor = new ExpressionProcessor(traceLogger);
            var actor = new ExpressionTriggerProcessor(expressionProcessor)
            {
                Triggers = triggers,
                ExpressionGroups = new ExpressionGroup[] { expressionGroupA, expressionGroupB }
            };

            //Act
            var result = expressionProcessor.ProcessExpressionGroup(expressionGroupA);


            //Assert
            Assert.IsTrue(result);
        }
    }
}
