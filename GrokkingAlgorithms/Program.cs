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
            Console.WriteLine("2. Sort selection.");
            Console.WriteLine("3. Recursion.");
            Console.WriteLine("4. Summary loop.");
            Console.WriteLine("5. Summary recursion.");
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
                case 2:
                    isPrintMenu = true;
                    PrintSortSelection();
                    break;
                case 3:
                    isPrintMenu = true;
                    PrintRecursion();
                    break;
                case 4:
                    isPrintMenu = true;
                    PrintSummaryLoop();
                    break;
                case 5:
                    isPrintMenu = true;
                    PrintSummaryRecursion();
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

            var binarySearch = BinarySearchHelper.Instance;
            var array = ArrayHelper.Instance;
            var arr = array.GetSortArray(1, 100_000_000, EnumWriteLine.False);
            Console.WriteLine($"var arr = _array.GetSortArray(1, 100_000_000, EnumWriteLine.False);");
            var list = arr.ToList();
            Console.WriteLine($"var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(arr, 123_456): {binarySearch.Execute(arr, 123_456):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(list, 123_456): {binarySearch.Execute(list, 123_456):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(arr, 12): {binarySearch.Execute(arr, 12):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"Execute(list, 12): {binarySearch.Execute(list, 12):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static void PrintSortSelection()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                         Sort selection                         ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            Console.WriteLine(@"var _array = ArrayHelper.Instance;");
            var sortSelection = SortSelectionHelper.Instance;
            Console.WriteLine(@"var _sortSelection = SortSelectionHelper.Instance;");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            sortSelection.Execute(array.GetRandomArray(25_000, 100_000), EnumSort.Asc, EnumAlgorithm.First);
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            sortSelection.Execute(array.GetRandomArray(25_000, 100_000), EnumSort.Asc, EnumAlgorithm.Second);
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            sortSelection.Execute(array.GetRandomArray(25_000, 100_000), EnumSort.Asc, EnumAlgorithm.Third);
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static void PrintRecursion()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                            Recursion                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var recursion = RecursionHelper.Instance;
            Console.WriteLine("var _recursion = RecursionHelper.Instance;");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"Factorial(8): {recursion.Factorial(8):N0}");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static void PrintSummaryLoop()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                          Summary loop                          ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var summaryLoop = SummaryLoopHelper.Instance;
            var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var summaryLoop = SummaryLoopHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"sortQuickLoop.Execute(arr): {summaryLoop.Execute(arr):N0}. ");
            sw.Stop();
            Console.WriteLine($"Loop(). Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"sortQuickLoop.Execute(list): {summaryLoop.Execute(list):N0}. ");
            sw.Stop();
            Console.WriteLine($"Loop(). Elapsed time: {sw.Elapsed}.");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static void PrintSummaryRecursion()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                       Summary recursion                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var summaryRecursion = SummaryRecursionHelper.Instance;
            var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var summaryRecursion = SummaryRecursionHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"summaryRecursion.Execute(arr): {summaryRecursion.Execute(arr):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"summaryRecursion.Execute(list): {summaryRecursion.Execute(list):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }
    }
}
