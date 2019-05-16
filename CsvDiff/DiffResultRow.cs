using System.Collections.Generic;

namespace CsvDiff
{
    public class DiffResultRow
    {
        public DiffResultRow(IEnumerable<DiffResultCell> cells)
        {
            Cells = cells;
        }

        public IEnumerable<DiffResultCell> Cells { get; }
    }
}