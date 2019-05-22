using System;
using System.Linq;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffer
    {
        [Fact]
        public void DiffWithOneDifferingColumn()
        {
            //arrange
            var left = "ColName\r\nLeft";
            var right = "ColName\r\nRight";

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
            var leftAndRight = "ColName\r\nValue";

            var target = new Differ();

            //act
            var actual = target.Diff(leftAndRight, leftAndRight);

            //assert
            Assert.True(actual.Match);
        }

        [Fact]
        public void DiffShouldThrowArgumentNullExceptionForLeft()
        {
            //Arrange
            var right = "ColName\r\nValue";
            var target = new Differ();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => target.Diff(null, right));

        }
        [Fact]
        public void DiffShouldThrowArgumentNullExceptionForRight()
        {
            //Arrange
            var left = "ColName\r\nValue";
            var target = new Differ();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => target.Diff(left, null));
        }

        [Fact]
        public void DiffShouldFillResultCells()
        {
            //Arrange
            var colName = "ColName";
            var leftAndRight = $"{colName}\r\nValue";
            var target = new Differ();

            //Act
            var actual = target.Diff(leftAndRight, leftAndRight);

            //Assert
            var diffResultCell = actual.Rows.First().Cells.First();
            Assert.True(diffResultCell.IsMatch);
            Assert.Equal(colName, diffResultCell.Left.Original);
            Assert.Equal(colName, diffResultCell.Left.Processed);
            Assert.Equal(colName, diffResultCell.Right.Original);
            Assert.Equal(colName, diffResultCell.Right.Processed);
        }

        [Fact]
        public void DiffShouldIgnoreEmptyRowAtTheEnd()
        {
            //Arrange
            var emtyRowAtEnd = "colName\r\n";
            var target = new Differ();

            //Act
            var actual = target.Diff(emtyRowAtEnd, emtyRowAtEnd);

            //Assert
            Assert.Single(actual.Rows);
        }

        [Fact]
        public void DiffShouldfillResultCellsWithMultiColumnAndMultiRows()
        {
            var colName1 = "ColName1";
            var colName2 = "ColName2";
            var colNames = $"{colName1},{colName2}";
            var left = $"{colNames}\r\nValue1,Left2";
            var right = $"{colNames}\r\nValue1,Right2";
            var target = new Differ();

            //Act
            var actual = target.Diff(left, right);

            //Assert
            var caption1 = actual.Rows.First().Cells.First();
            Assert.True(caption1.IsMatch);
            Assert.Equal(colName1, caption1.Left.Original);
            Assert.Equal(colName1, caption1.Left.Processed);
            Assert.Equal(colName1, caption1.Right.Original);
            Assert.Equal(colName1, caption1.Right.Processed);

            var caption2 = actual.Rows.First().Cells.ElementAt(1);
            Assert.True(caption2.IsMatch);
            Assert.Equal(colName2, caption2.Left.Original);
            Assert.Equal(colName2, caption2.Left.Processed);
            Assert.Equal(colName2, caption2.Right.Original);
            Assert.Equal(colName2, caption2.Right.Processed);

            var value1 = actual.Rows.ElementAt(1).Cells.First();
            Assert.True(value1.IsMatch);
            Assert.Equal("Value1", value1.Left.Original);
            Assert.Equal("Value1", value1.Left.Processed);
            Assert.Equal("Value1", value1.Right.Original);
            Assert.Equal("Value1", value1.Right.Processed);

            var Right2 = actual.Rows.ElementAt(1).Cells.ElementAt(1);
            Assert.False(Right2.IsMatch);
            Assert.Equal("Left2", Right2.Left.Original);
            Assert.Equal("Left2", Right2.Left.Processed);
            Assert.Equal("Right2", Right2.Right.Original);
            Assert.Equal("Right2", Right2.Right.Processed);
        }

        [Fact]
        public void DiffWhenLeftAreMoreRowsThenRightDifferShouldGenerateEmptyRow()
        {
            //Arrange
            var left = "row1\r\nrow2";
            var right = "row1";
            var target = new Differ();

            //Act
            var actual = target.Diff(left, right);

            //Assert
            Assert.False(actual.Match);
            Assert.Equal(2, actual.Rows.Count());
            Assert.Equal("", actual.Rows.ElementAt(1).Cells.ElementAt(0).Right.Original);
        }

        [Fact]
        public void DiffWhenRightAreMoreRowsThenLeftDifferShouldGenerateEmptyRow()
        {
            //Arrange
            var left = "row1";
            var right = "row1\r\nrow2";
            var target = new Differ();

            //Act
            var actual = target.Diff(left, right);

            //Assert
            Assert.False(actual.Match);
            Assert.Equal(2, actual.Rows.Count());
            Assert.Equal("", actual.Rows.ElementAt(1).Cells.ElementAt(0).Left.Original);
        }
    }
}