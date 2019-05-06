using System;

namespace CsvDiff
{
    public class CsvDiff
    {
        public DiffResult Diff(string left, string right)
        {
            return new DiffResult(left == right);
        }
    }

    public class DiffResult
    {
        public DiffResult(bool match)
        {
            Match = match;
        }

        public bool Match { get; }
    }
}
