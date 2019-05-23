using System;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffOptionsIgnoreCase
    {
        public static string CrLf = Environment.NewLine;

        [Fact]
        public void DiffDifferentCasingShouldFail()
        {
            //Arrange
            var left = $"Col1,Col2{CrLf}val1,Val2";
            var right = $"Col1,Col2{CrLf}Val1,val2";

            var target = new Differ();

            //act
            var actual = target.Diff(left, right);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffOptionIgnoreCaseFalse()
        {
            //Arrange
            var left = $"Col1,Col2{CrLf}val1,Val2";
            var right = $"Col1,Col2{CrLf}Val1,val2";
            var diffOptions = new DiffOptions {IgnoreCase = false};

            var target = new Differ();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffOptionIgnoreCaseTrue()
        {
            //Arrange
            var left = $"Col1,Col2{CrLf}val1,Val2";
            var right = $"Col1,Col2{CrLf}Val1,val2";
            var diffOptions = new DiffOptions {IgnoreCase = true};

            var target = new Differ();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }
    }
}