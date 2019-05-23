using System;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffOptionsAllowRowReordering
    {
        public static string CrLf = Environment.NewLine;

        [Fact]
        public void DiffOneColumnThreeRowsShouldReorderRowsToMatch()
        {
            //Arrange
            var left = $"Col1{CrLf}Val1{CrLf}Val2";
            var right = $"Col1{CrLf}Val2{CrLf}Val1";
            var options = new DiffOptions {AllowRowReordering = true};
            var target = new Differ();

            //Act
            var actual = target.Diff(left, right, options);

            //Assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffTwoColumnThreeRowsShouldReorderRowsToMatch()
        {
            //Arrange
            var left = $"Col1,Col2{CrLf}Val1,Val1{CrLf}Val2,Val2";
            var right = $"Col1,Col2{CrLf}Val2,Val2{CrLf}Val1,Val1";
            var options = new DiffOptions {AllowRowReordering = true};
            var target = new Differ();

            //Act
            var actual = target.Diff(left, right, options);

            //Assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffTwoColumnThreeRowsWithDifferingWhitespaceShouldReorderRowsToMatch()
        {
            //Arrange
            var left = $"Col1,Col2{CrLf} Val1 ,Val1{CrLf}Val2,Val2";
            var right = $"Col1,Col2{CrLf} Val2 ,Val2{CrLf}Val1,Val1";
            var options = new DiffOptions {AllowRowReordering = true, TrimWhitespace = true};
            var target = new Differ();

            //Act
            var actual = target.Diff(left, right, options);

            //Assert
            Assert.True(actual.Match);
        }
    }
}