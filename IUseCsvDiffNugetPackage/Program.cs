using System;

namespace IUseCsvDiffNugetPackage
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var differ = new CsvDiff.Differ();
            var captions = "GebDatum,Vorname,Nachname\r\n";
            var LAndR = "1969-06-11,Peter,Dinkelage\r\n";
            var left2 = "1986-10-23,Emilia,Clarke\r\n";
            var right2 = "1963-03-16,Jerome,Flynn\r\n";

            var left = captions + LAndR + left2;
            var right = captions + LAndR + right2;

            var result = differ.Diff(left, right);

            foreach (var row in result.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    Console.Write(string.Join('|', cell.IsMatch,cell.Left.Original, cell.Right.Original, "\t\t"));
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}