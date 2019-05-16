using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffer
    {
        [Fact]
        public void DiffWithOneDifferingColumn()
        {
            //arrange
            var left = @"ColName\r\nLeft";
            var right = @"ColName\r\nRight";

            var target = new Differ();

            //act
            var actual = target.Diff(left, right);

            //assert
            Assert.False(actual.Match);
        }

        [Fact]
        public void DiffWithOneMatchingColumn()
        {
            //arrange
            var leftAndRight = @"ColName\r\nValue";

            var target = new Differ();

            //act
            var actual = target.Diff(leftAndRight, leftAndRight);

            //assert
            Assert.True(actual.Match);
        }
    }
}