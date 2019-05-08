using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffOptionsCaseInsensitive
    {
        [Fact]
        public void DiffDifferentCasingShouldFail()
        {
            //Arrange
            var left = @"Col1,Col2\r\nval1,Val2";
            var right = @"Col1,Col2\r\nVal1,val2";

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffOptionCaseInsensitiveFalse()
        {
            //Arrange
            var left = @"Col1,Col2\r\nval1,Val2";
            var right = @"Col1,Col2\r\nVal1,val2";
            var diffOptions = new DiffOptions {CaseInsensitive = false};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffOptionCaseInsensitiveTrue()
        {
            //Arrange
            var left = @"Col1,Col2\r\nval1,Val2";
            var right = @"Col1,Col2\r\nVal1,val2";
            var diffOptions = new DiffOptions {CaseInsensitive = true};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffTrimWhitespaceOptionTrueWorksWithMultipleColumns()
        {
            //Arrange
            var left = @"Col1,Col2\r\n Val1 ,Val2";
            var right = @"Col1,Col2\r\nVal1, Val2 ";
            var diffOptions = new DiffOptions {AllowWhitespaceTrimming = true};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }
    }
}