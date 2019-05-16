using System.Collections.Generic;

namespace CsvDiff
{
    public class DiffResult
    {
        public DiffResult(bool match, IEnumerable<DiffResultRow> rows, IEnumerable<string> captions)
        {
            Match = match;
            Rows = rows;
            Captions = captions;
        }

        public IEnumerable<string> Captions { get; }

        public IEnumerable<DiffResultRow> Rows { get; }

        public bool Match { get; }
    }
}