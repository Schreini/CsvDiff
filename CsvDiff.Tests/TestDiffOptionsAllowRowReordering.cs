using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffOptionsAllowRowReordering
    {
        [Fact]
        public void DiffOneColumnThreeRowsShouldReorderRowsToMatch()
        {
            //Arrange
            var left = @"Col1\r\nVal1\r\nVal2";
            var right = @"Col1\r\nVal2\r\nVal1";
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
            var left = @"Col1,Col2\r\nVal1,Val1\r\nVal2,Val2";
            var right = @"Col1,Col2\r\nVal2,Val2\r\nVal1,Val1";
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
            var left = @"Col1,Col2\r\n Val1 ,Val1\r\nVal2,Val2";
            var right = @"Col1,Col2\r\n Val2 ,Val2\r\nVal1,Val1";
            var options = new DiffOptions {AllowRowReordering = true, TrimWhitespace = true};
            var target = new Differ();

            //Act
            var actual = target.Diff(left, right, options);

            //Assert
            Assert.True(actual.Match);
        }
    }
}