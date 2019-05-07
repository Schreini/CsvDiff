namespace CsvDiff
{
    public class DiffResult
    {
        public DiffResult(bool match)
        {
            Match = match;
        }

        public bool Match { get; }
    }
}