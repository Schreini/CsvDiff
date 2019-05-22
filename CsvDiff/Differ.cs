using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvDiff
{
    public class Differ
    {
        public DiffResult Diff(string left, string right)
        {
            if (left == null) throw new ArgumentNullException(nameof(left));
            if (right == null) throw new ArgumentNullException(nameof(right));

            var leftStringRows = SplitIntoRows(left);
            var rightStringRows = SplitIntoRows(right);

            if (leftStringRows.Length > rightStringRows.Length)
                rightStringRows = AppendEmptyRows(rightStringRows, leftStringRows.Length);

            if (rightStringRows.Length > leftStringRows.Length)
                leftStringRows = AppendEmptyRows(leftStringRows, rightStringRows.Length);

            var leftCells = new string[leftStringRows.Length][];
            var rightCells = new string[leftStringRows.Length][];

            for (var row = 0; row < leftStringRows.Length; row++)
            {
                leftCells[row] = SplitIntoCells(leftStringRows[row]);
                rightCells[row] = SplitIntoCells(rightStringRows[row]);
            }

            var maxLeftCells = leftCells.Select(r => r).ToList().Select(c => c.Length).Max(c => c);
            var maxRightCells = rightCells.Select(r => r).ToList().Select(c => c.Length).Max(c => c);

            var maxCells = Math.Max(maxLeftCells, maxRightCells);

            var resultRows = new List<DiffResultRow>();

            for (var row = 0; row < leftStringRows.Length; row++)
            {
                leftCells[row] = AppendEmptyRows(leftCells[row], maxCells);
                rightCells[row] = AppendEmptyRows(rightCells[row], maxCells);

                var resultCells = new List<DiffResultCell>();
                resultRows.Add(new DiffResultRow(resultCells));

                for (var cell = 0; cell < leftCells[row].Length; cell++)
                    resultCells.Add(new DiffResultCell(
                        new DiffResultValues(leftCells[row][cell], leftCells[row][cell]),
                        new DiffResultValues(rightCells[row][cell], rightCells[row][cell])
                    ));
            }

            return new DiffResult(left == right, resultRows);
        }

        private string[] AppendEmptyRows(string[] rows, int length)
        {
            string[] result = new string[length];
            Array.Copy(rows, result, rows.Length);

            for(int i = rows.Length; i < length; i++)
                result[i] = "";

            return result;
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
                var cols = SplitIntoCells(row);
                trimmedRows.Add(JoinCells(cols));
            }

            return JoinRows(trimmedRows);
        }

        private static string JoinCells(string[] cols)
        {
            return string.Join(",", cols.Select(c => c.Trim()));
        }

        private static string[] SplitIntoCells(string row)
        {
            return row.Split(new[] {','}, StringSplitOptions.None);
        }

        private static string JoinRows(IEnumerable<string> trimmedRows)
        {
            return string.Join("\r\n", trimmedRows);
        }

        private static string[] SplitIntoRows(string input)
        {
            var result = input.Split(new[] {"\r\n"}, StringSplitOptions.None);
            if (result[result.Length - 1].Trim() == string.Empty)
            {
                var newResult = new string[result.Length-1];
                Array.Copy(result, newResult, newResult.Length);
                result = newResult;
            }

            return result;
        }
    }
}