using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffResult
    {
        private static readonly DiffResultValues _matchingValues = new DiffResultValues("a", "a");
        private static readonly DiffResultCell _matchingCell = new DiffResultCell(_matchingValues, _matchingValues, true);

        [Fact]
        public void ConstructorShouldSetProperties()
        {
            //Arrange
            var captionName = "cap";
            DiffResultRow row = new DiffResultRow(new DiffResultCell[] {_matchingCell});

            //Act
            var target = new DiffResult(true, new []{row}, new []{captionName});

            //Assert
            Assert.Single(target.Captions);
            Assert.Equal(captionName, target.Captions.First());
            Assert.Single(target.Rows);
            Assert.True(ReferenceEquals(_matchingCell, target.Rows.First().Cells.First()));
        }
    }
}
