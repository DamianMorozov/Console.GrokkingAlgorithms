﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using System;
using System.Linq;

namespace GrokkingAlgorithms
{
    public class Program
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
            Console.WriteLine("4. Summary recursive & foreach.");
            Console.WriteLine("5. Count values recursive & foreach.");
            Console.WriteLine("6. First value recursive & foreach.");
            Console.WriteLine("7. Quick sort.");
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
                    PrintSummary();
                    break;
                case 5:
                    isPrintMenu = true;
                    PrintCount();
                    break;
                case 6:
                    isPrintMenu = true;
                    PrintFirstValue();
                    break;
                case 7:
                    isPrintMenu = true;
                    PrintQuickSort();
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

            int startValue = default;
            Console.Write($"Type start value (default is 1): ");
            SetValueSafe(Console.ReadLine(), ref startValue, 1);
            int endValue = default;
            Console.Write($"Type end value (default is 1_000_000): ");
            SetValueSafe(Console.ReadLine(), ref endValue, 1_000_000);
            Console.WriteLine(@"----------------------------------------------------------------------");

            var binarySearch = BinarySearchHelper.Instance;
            var array = ArrayHelper.Instance;
            var arr = array.GetSortArray(startValue, endValue, EnumWriteLine.False);
            var list = arr.ToList();
            Console.WriteLine($"var arr = _array.GetSortArray({startValue}, {endValue}, EnumWriteLine.False);");
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

        private static void PrintSummary()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Summary recursive & foreach                  ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var summary = SummaryHelper.Instance;
            var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var summary = SummaryHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"sortQuickLoop.Execute(arr): {summary.ExecuteForeach(arr):N0}. ");
            sw.Stop();
            Console.WriteLine($"Loop(). Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"sortQuickLoop.Execute(list): {summary.ExecuteForeach(list):N0}. ");
            sw.Stop();
            Console.WriteLine($"Loop(). Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"summaryRecursion.Execute(arr): {summary.ExecuteRecursive(arr):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"summaryRecursion.Execute(list): {summary.ExecuteRecursive(list):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static void PrintCount()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Count recursive & foreach                    ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var count = CountHelper.Instance;
            var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var count = CountHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000, EnumWriteLine.False);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"countRecursion.ExecuteRecursive(arr): {count.ExecuteRecursive(arr):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"countRecursion.ExecuteForeach(arr): {count.ExecuteForeach(arr):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"arr.Length: {arr.Length:N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"countRecursion.ExecuteRecursive(list): {count.ExecuteRecursive(list):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"countRecursion.ExecuteForeach(list): {count.ExecuteForeach(list):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"list.Count: {list.Count:N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static void PrintFirstValue()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                First value recursive & foreach                 ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var firstValue = FirstValueHelper.Instance;
            var arr = array.GetRandomArray(1_000, 1_000, EnumWriteLine.False);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var firstValue = FirstValueHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(1_000, 1_000, EnumWriteLine.False);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"firstValue.ExecuteForeach(arr): {firstValue.ExecuteForeach(arr, EnumSort.Desc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"firstValue.ExecuteForeach(list): {firstValue.ExecuteForeach(list, EnumSort.Desc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"firstValue.ExecuteRecursive(arr): {firstValue.ExecuteRecursive(arr, EnumSort.Asc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"firstValue.ExecuteRecursive(list): {firstValue.ExecuteRecursive(list, EnumSort.Asc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"firstValue.ExecuteRecursive(list): {firstValue.ExecuteRecursive(list, EnumSort.Asc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = System.Diagnostics.Stopwatch.StartNew();
            Console.Write($"firstValue.ExecuteRecursive(list): {firstValue.ExecuteRecursive(list, EnumSort.Desc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        private static void PrintQuickSort()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                           Quick sort                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var sortQuick = SortQuickHelper.Instance;
            var arr = array.GetRandomArray(1_000_000, 1_000_000, EnumWriteLine.False);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var sortQuick = SortQuickHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(1_000_000, 1_000_000, EnumWriteLine.False);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            var sortListFast = sortQuick.ExecuteRecursiveFast(arr, EnumSort.Asc);
            Console.Write($"var sortListFast = sortQuick.ExecuteRecursiveFast(arr, EnumSort.Asc);. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");

            sw = System.Diagnostics.Stopwatch.StartNew();
            var sortListFast2 = sortQuick.ExecuteRecursiveFastWithSwithPivot(arr, EnumSort.Asc);
            Console.Write($"var sortListFast2 = sortQuick.ExecuteRecursiveFastWithSwithPivot(arr, EnumSort.Asc);. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
        }

        public static bool SetValue(string input, ref int value, int defValue)
        {
            var result = false;
            try
            {
                value = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error input value. The new value will be set to: {defValue}");
                value = defValue;
            }
            return result;
        }

        public static bool SetValueSafe(string input, ref int value, int defValue)
        {
            var result = false;
            if (int.TryParse(input, out int res))
            {
                value = res;
            }
            else
            {
                Console.WriteLine($"Error input value. The new value will be set to: {defValue}");
                value = defValue;
            }
            return result;
        }
    }
}
