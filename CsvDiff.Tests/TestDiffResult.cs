using System.Linq;
using Xunit;

namespace CsvDiff.Tests
{
    public class TestDiffResult
    {
        private static readonly DiffResultValues MatchingValues = new DiffResultValues("a", "a");
        private static readonly DiffResultCell MatchingCell = new DiffResultCell(MatchingValues, MatchingValues);

        [Fact]
        public void ConstructorShouldSetProperties()
        {
            //Arrange
            DiffResultRow row = new DiffResultRow(new[] {MatchingCell});

            //Act
            var target = new DiffResult(true, new []{row});

            //Assert
//            Assert.Single(target.Captions);
//            Assert.Equal(captionName, target.Captions.First());
            Assert.Single(target.Rows);
            Assert.True(ReferenceEquals(MatchingCell, target.Rows.First().Cells.First()));
        }
    }
}
