using System;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestCsvDiff
    {
        [Fact]
        public void DiffWithOneMatchingColumn()
        {
            string leftAndRight = @"ColName\r\nValue";

            //arrange
            var target = new CsvDiff();

            //act
            var actual = target.Diff(leftAndRight, leftAndRight);

            //assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffWithOneDifferingColumn()
        {
            string left = @"ColName\r\nLeft";
            string right = @"ColName\r\nRight";

            //arrange
            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right);

            //assert
            Assert.False(actual.Match);
        }
    }
}
