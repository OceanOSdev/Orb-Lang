using System;
using System.Collections.Generic;
using Orb.CodeAnalysis;
using Orb.CodeAnalysis.Syntax;
using Xunit;

namespace Orb.Tests.CodeAnalysis
{
    public class EvaluationTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("+1", 1)]
        [InlineData("-1", -1)]
        [InlineData("1+2", 3)]
        [InlineData("15-2", 13)]
        [InlineData("4*2", 8)]
        [InlineData("9/3", 3)]
        [InlineData("(12)", 12)]
        [InlineData("12 == 2", false)]
        [InlineData("7 == 7", true)]
        [InlineData("12 != 12", false)]
        [InlineData("12 != 7", true)]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("!true", false)]
        [InlineData("!false", true)]
        [InlineData("true == true", true)]
        [InlineData("true != true", false)]
        [InlineData("true == false", false)]
        [InlineData("true != false", true)]
        [InlineData("true||false", true)]
        [InlineData("true&&false", false)]
        [InlineData("{var a = 10\r\n a*a}", 100)]
        public void Evaluator_Computes_CorrectValues(string text, object expectedResult)
        {
            var syntaxTree = SyntaxTree.Parse(text);
            var compilation = new Compilation(syntaxTree);
            var variables = new Dictionary<VariableSymbol, object>();

            var result = compilation.Evaluate(variables);

            Assert.Empty(result.Diagnostics);
            Assert.Equal(expectedResult, result.Value);
        }
    }
}
