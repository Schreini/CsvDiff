﻿using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffResultCell
    {
        [Fact]
        public void ContructorShouldFillAllProperties()
        {
            //Arrange
            var left = new DiffResultValues("a", "a");
            var right = new DiffResultValues("a", "a");

            //Act
            var target = new DiffResultCell(left, right);

            //Assert
            Assert.Equal(left, target.Left);
            Assert.Equal(right, target.Right);
            Assert.True(target.IsMatch);
        }
    }
}
