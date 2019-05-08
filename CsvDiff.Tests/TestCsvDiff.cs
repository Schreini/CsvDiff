using System;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestCsvDiff
    {
        [Fact]
        public void DiffWithOneMatchingColumn()
        {
            //arrange
            string leftAndRight = @"ColName\r\nValue";

            var target = new CsvDiff();

            //act
            var actual = target.Diff(leftAndRight, leftAndRight);

            //assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffWithOneDifferingColumn()
        {
            //arrange
            string left = @"ColName\r\nLeft";
            string right = @"ColName\r\nRight";

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right);

            //assert
            Assert.False(actual.Match);
        }
    }
}
