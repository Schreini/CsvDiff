using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffOptionsIgnoreCase
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
        public void DiffOptionIgnoreCaseFalse()
        {
            //Arrange
            var left = @"Col1,Col2\r\nval1,Val2";
            var right = @"Col1,Col2\r\nVal1,val2";
            var diffOptions = new DiffOptions {IgnoreCase = false};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffOptionIgnoreCaseTrue()
        {
            //Arrange
            var left = @"Col1,Col2\r\nval1,Val2";
            var right = @"Col1,Col2\r\nVal1,val2";
            var diffOptions = new DiffOptions {IgnoreCase = true};

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }
    }
}