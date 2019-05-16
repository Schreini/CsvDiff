namespace CsvDiff
{
    public class DiffResultValues
    {
        public DiffResultValues(string original, string processed)
        {
            Original = original;
            Processed = processed;
        }

        public string Original { get; }
        public string Processed { get; }
    }
}