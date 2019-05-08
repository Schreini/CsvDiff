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
            if (diffOptions.AllowWhitespaceTrimming)
            {
                left = Trim(left);
                right = Trim(right);
            }

            return Diff(left, right);
        }

        private string Trim(string input)
        {
            var rows = input.Split(new[] {@"\r\n"}, StringSplitOptions.None);
            IList<string> trimmedRows = new List<string>(rows.Length);
            foreach (var row in rows)
            {
                var cols = row.Split(new []{','}, StringSplitOptions.None);
                trimmedRows.Add(string.Join(",", cols.Select(c => c.Trim())));
            }

            return string.Join("\r\n", trimmedRows);
        }
    }
}
