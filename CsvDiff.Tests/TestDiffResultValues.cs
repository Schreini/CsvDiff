using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffResultValues
    {
        [Fact]
        public void ConstructorShouldFillPrperties()
        {
            //Arrange
            string original = "A";
            string processed = "a";

            //Act
            var target = new DiffResultValues(original, processed);

            //Assert
            Assert.Equal(original, target.Original);
            Assert.Equal(processed, target.Processed);
        }
    }
}
