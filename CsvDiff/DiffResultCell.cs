namespace CsvDiff
{
    public class DiffResultCell
    {
        public DiffResultCell(DiffResultValues left, DiffResultValues right)
        {
            //todo: Assert Null Values are not allowed with Tests
            Left = left;
            Right = right;
            IsMatch = left.Processed == right.Processed;
        }

        public bool IsMatch { get; }

        public DiffResultValues Left { get; }
        public DiffResultValues Right { get; }
    }
}