using System.Collections.Generic;

namespace CsvDiff
{
    public class DiffResultColumn
    {
        public string Caption;
        public IEnumerable<DiffResultCell> Values;
    }
}