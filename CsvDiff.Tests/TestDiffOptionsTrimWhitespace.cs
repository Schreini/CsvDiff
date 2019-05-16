using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffOptionsTrimWhitespace
    {
        [Fact]
        public void DiffHonorsTrimWhitespaceOptionFalse()
        {
            //Arrange
            var left = @"ColName\r\nValue";
            var right = @"ColName\r\n Value ";
            var diffOptions = new DiffOptions {TrimWhitespace = false};

            var target = new Differ();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffHonorsTrimWhitespaceOptionTrue()
        {
            //Arrange
            var left = @"ColName\r\nValue";
            var right = @"ColName\r\n Value ";
            var diffOptions = new DiffOptions {TrimWhitespace = true};

            var target = new Differ();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffTrimWhitespaceOptionTrueDoesNotChangeInnerWhitespace()
        {
            //Arrange
            var left = @"ColName\r\nVal  ue";
            var right = @"ColName\r\nVa lue";
            var diffOptions = new DiffOptions {TrimWhitespace = true};

            var target = new Differ();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffTrimWhitespaceOptionTrueWorksWithMultipleColumns()
        {
            //Arrange
            var left = @"Col1,Col2\r\n Val1 ,Val2";
            var right = @"Col1,Col2\r\nVal1, Val2 ";
            var diffOptions = new DiffOptions {TrimWhitespace = true};

            var target = new Differ();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffWithoutOptionsDoesCompareLeadingAndTrailingWhitespace()
        {
            //arrange
            var left = @"ColName\r\nValue";
            var right = @"ColName\r\n Value ";

            var target = new Differ();

            //act
            var actual = target.Diff(left, right);

            //assert
            Assert.False(actual.Match);
        }
    }
}