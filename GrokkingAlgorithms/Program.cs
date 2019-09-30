// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
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

            var _arrayHelper = ArrayHelper.Instance;
            var arr = _arrayHelper.GetSortArray(1, 10_000_000, EnumWriteLine.False);
            var list = arr.ToList();

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"BinarySearch(arr, 123_456): {BinarySearch(arr, 123_456):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"BinarySearch(list, 123_456): {BinarySearch(list, 123_456):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"BinarySearch(arr, 12): {BinarySearch(arr, 12):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"BinarySearch(list, 12): {BinarySearch(list, 12):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static (int? pos, int count) BinarySearch(int?[] arr, int item)
        {
            var count = 0;
            var start = 0;
            var end = arr.Count() - 1;
            while (start <= end)
            {
                count++;
                var mid = (start + end) / 2;
                var guess = arr[mid];
                if (guess == item) return (mid, count);
                if (guess > item)
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            return (null, count);
        }

        private static (int? pos, int count) BinarySearch(IEnumerable<int?> list, int item)
        {
            var count = 0;
            var start = 0;
            var end = list.Count() - 1;
            while (start <= end)
            {
                count++;
                var mid = (start + end) / 2;
                var guess = list.ElementAt(mid);
                if (guess == item) return (mid, count);
                if (guess > item)
                    end = mid - 1;
                else
                    start = mid + 1;
            }
            return (null, count);
        }
    }
}
