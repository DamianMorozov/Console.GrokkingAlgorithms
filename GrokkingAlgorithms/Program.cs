// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using System;
using System.Linq;

namespace GrokkingAlgorithms
{
    internal class Program
    {
        private static void Main()
        {
            var numberMenu = -1;
            while (numberMenu != 0)
            {
                PrintCaption();
                try
                {
                    numberMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    numberMenu = -1;
                }
                Console.WriteLine();
                PrintSwitch(numberMenu);
            }
        }

        private static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                       Grokking Algorithms                      ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine("0. Exit from console.");
            Console.WriteLine("1. Binary search.");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.Write("Type switch: ");
        }

        private static void PrintSwitch(int numberMenu)
        {
            Console.Clear();
            var isPrintMenu = false;
            switch (numberMenu)
            {
                case 1:
                    isPrintMenu = true;
                    PrintBinarySearch();
                    break;
            }
            if (isPrintMenu)
            {
                Console.WriteLine(@"----------------------------------------------------------------------");
                Console.Write("Type any key to return in main menu.");
                Console.ReadKey();
            }
        }

        private static void PrintBinarySearch()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                         Binary search                          ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var _binarySearch = BinarySearchHelper.Instance;
            var _array = ArrayHelper.Instance;
            var arr = _array.GetSortArray(1, 100_000_000, EnumWriteLine.False);
            Console.WriteLine($"var arr = _array.GetSortArray(1, 100_000_000, EnumWriteLine.False);");
            var list = arr.ToList();
            Console.WriteLine($"var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(arr, 123_456): {_binarySearch.Execute(arr, 123_456):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(list, 123_456): {_binarySearch.Execute(list, 123_456):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(arr, 12): {_binarySearch.Execute(arr, 12):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(list, 12): {_binarySearch.Execute(list, 12):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }
    }
}
