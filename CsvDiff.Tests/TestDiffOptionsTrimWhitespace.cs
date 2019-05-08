using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffOptionsTrimWhitespace
    {
        [Fact]
        public void DiffWithoutOptionsDoesCompareLeadingAndTrailingWhitespace()
        {
            //arrange
            var left = @"ColName\r\nValue";
            var right = @"ColName\r\n Value ";

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffHonorsTrimWhitespaceOptionTrue()
        {
            //Arrange
            var left = @"ColName\r\nValue";
            var right = @"ColName\r\n Value ";
            var diffOptions = new DiffOptions {AllowWhitespaceTrimming = true};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffHonorsTrimWhitespaceOptionFalse()
        {
            //Arrange
            var left = @"ColName\r\nValue";
            var right = @"ColName\r\n Value ";
            var diffOptions = new DiffOptions {AllowWhitespaceTrimming = false};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffTrimWhitespaceOptionTrueDoesNotChangeInnerWhitespace()
        {
            //Arrange
            var left = @"ColName\r\nVal  ue";
            var right = @"ColName\r\nVa lue";
            var diffOptions = new DiffOptions {AllowWhitespaceTrimming = true};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }
    }
}