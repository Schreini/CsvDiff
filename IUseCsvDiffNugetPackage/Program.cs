﻿using System;

namespace IUseCsvDiffNugetPackage
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var differ = new CsvDiff.CsvDiff();

            var result = differ.Diff("a", "a");
            Console.WriteLine(result);
        }
    }
}