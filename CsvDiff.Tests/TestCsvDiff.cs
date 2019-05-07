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

        [Fact]
        public void DiffWithoutOptionsDoesCompareLeadingAndTrailingWhitespace()
        {
            //arrange
            string left = @"ColName\r\nValue";
            string right = @"ColName\r\n Value ";

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
            string left = @"ColName\r\nValue";
            string right = @"ColName\r\n Value ";
            var diffOptions = new DiffOptions() {AllowWhitespaceTrimming = true};

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
            string left = @"ColName\r\nValue";
            string right = @"ColName\r\n Value ";
            var diffOptions = new DiffOptions() { AllowWhitespaceTrimming = false };

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
            string left = @"ColName\r\nVal  ue";
            string right = @"ColName\r\nVa lue";
            var diffOptions = new DiffOptions() { AllowWhitespaceTrimming = true };

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.False(actual.Match);
        }


        [Fact]
        public void DiffTrimWhitespaceOptionTrueWorksWithMultipleColumns()
        {
            //Arrange
            string left = @"Col1,Col2\r\n Val1 ,Val2";
            string right = @"Col1,Col2\r\nVal1, Val2 ";
            var diffOptions = new DiffOptions() { AllowWhitespaceTrimming = true };

            var target = new CsvDiff();

            //act
            var actual = target.Diff(left, right, diffOptions);

            //assert
            Assert.True(actual.Match);
        }

    }
}
