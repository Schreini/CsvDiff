using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvDiff
{
    public class CsvDiff
    {
        public DiffResult Diff(string left, string right)
        {
            return new DiffResult(left == right);
        }

        public DiffResult Diff(string left, string right, DiffOptions diffOptions)
        {
            if (diffOptions.TrimWhitespace)
            {
                left = Trim(left);
                right = Trim(right);
            }

            if (diffOptions.IgnoreCase)
            {
                left = left.ToUpperInvariant();
                right = right.ToUpperInvariant();
            }

            if (diffOptions.AllowRowReordering)
            {
                left = Sort(left);
                right = Sort(right);
            }

            return Diff(left, right);
        }

        private string Sort(string input)
        {
            var rows = SplitIntoRows(input);
            var ordered = rows.OrderBy(r => r);
            return JoinRows(ordered);
        }

        private string Trim(string input)
        {
            var rows = SplitIntoRows(input);
            IList<string> trimmedRows = new List<string>(rows.Length);
            foreach (var row in rows)
            {
                var cols = row.Split(new []{','}, StringSplitOptions.None);
                trimmedRows.Add(string.Join(",", cols.Select(c => c.Trim())));
            }

            return JoinRows(trimmedRows);
        }

        private static string JoinRows(IEnumerable<string> trimmedRows)
        {
            return string.Join(@"\r\n", trimmedRows);
        }

        private static string[] SplitIntoRows(string input)
        {
            return input.Split(new[] {@"\r\n"}, StringSplitOptions.None);
        }
    }
}
