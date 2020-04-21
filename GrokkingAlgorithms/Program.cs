﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GrokkingAlgorithms.Tests")]

namespace GrokkingAlgorithms
{
    internal static class Program
    {
        internal static void Main()
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

        internal static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                       Grokking Algorithms                      ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine("0. Exit from console.");
            Console.WriteLine("1. Binary search.");
            Console.WriteLine("2. Recursion.");
            Console.WriteLine("3. Summary recursive & foreach.");
            Console.WriteLine("4. Count values recursive & foreach.");
            Console.WriteLine("5. First value recursive & foreach.");
            Console.WriteLine("6. Sort selection.");
            Console.WriteLine("7. Quick sort.");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.Write("Type switch: ");
        }

        internal static void PrintSwitch(int numberMenu)
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
                    PrintRecursion();
                    break;
                case 3:
                    isPrintMenu = true;
                    PrintSummary();
                    break;
                case 4:
                    isPrintMenu = true;
                    PrintCount();
                    break;
                case 5:
                    isPrintMenu = true;
                    PrintFirstValue();
                    break;
                case 6:
                    isPrintMenu = true;
                    PrintSortSelection();
                    break;
                case 7:
                    isPrintMenu = true;
                    PrintSortQuick();
                    break;
            }
            if (isPrintMenu)
            {
                Console.WriteLine(@"----------------------------------------------------------------------");
                Console.Write("Type any key to return in main menu.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        internal static void PrintBinarySearch()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                         Binary search                          ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.Write("Type start value (default is 1): ");
            SetValueSafe(Console.ReadLine(), out var startValue, 1);
            Console.Write("Type end value (default is 1_000_000): ");
            SetValueSafe(Console.ReadLine(), out var endValue, 1_000_000);
            Console.WriteLine(@"----------------------------------------------------------------------");

            var binarySearch = BinarySearchHelper.Instance;
            var array = ArrayHelper.Instance;
            var arr = array.SortArray(startValue, endValue, EnumSortDirection.Asc);
            var list = arr.ToList();
            Console.WriteLine($"var arr = _array.GetSortArray({startValue}, {endValue}, EnumSort.Asc);");
            Console.WriteLine("var list = arr.ToList();");
            var arrDesc = array.SortArray(endValue, startValue, EnumSortDirection.Desc);
            var listDesc = arrDesc.ToList();
            Console.WriteLine($"var arrDesc = _array.GetSortArray({endValue}, {startValue}, EnumSort.Desc);");
            Console.WriteLine($"var listDesc = arrDesc.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            Console.WriteLine(@"Faster:");

            var sw = Stopwatch.StartNew();
            Console.Write($"Execute(arr, 123_456, EnumSort.Asc): {binarySearch.Execute(arr, 123_456, EnumSortDirection.Asc)}.  ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"Execute(list, 123_456, EnumSort.Asc): {binarySearch.Execute(list, 123_456, EnumSortDirection.Asc)}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            Console.Write($"Execute(arr, 12, EnumSort.Asc): {binarySearch.Execute(arr, 12, EnumSortDirection.Asc)}.           ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"Execute(list, 12, EnumSort.Asc): {binarySearch.Execute(list, 12, EnumSortDirection.Asc)}.          ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            Console.Write($"Execute(arrDesc, 123_456, EnumSort.Desc): {binarySearch.Execute(arrDesc, 123_456, EnumSortDirection.Desc)}.  ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"Execute(listDesc, 123_456, EnumSort.Desc): {binarySearch.Execute(listDesc, 123_456, EnumSortDirection.Desc)}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            Console.Write($"Execute(arrDesc, 12, EnumSort.Desc): {binarySearch.Execute(arrDesc, 12, EnumSortDirection.Desc)}.       ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"Execute(listDesc, 12, EnumSort.Desc): {binarySearch.Execute(listDesc, 12, EnumSortDirection.Desc)}.      ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Recursion.
        /// </summary>
        internal static void PrintRecursion()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                            Recursion                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var recursion = RecursionHelper.Instance;
            Console.WriteLine("var _recursion = RecursionHelper.Instance;");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var sw = Stopwatch.StartNew();
            Console.WriteLine($"Factorial(8): {recursion.Factorial(8):N0}");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Summary recursive & foreach.
        /// </summary>
        internal static void PrintSummary()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Summary recursive & foreach                  ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var summary = SummaryHelper.Instance;
            var arr = array.RandomArray(2_000, 1_000);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var summary = SummaryHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            Console.WriteLine(@"Faster:");

            var sw = Stopwatch.StartNew();
            Console.Write($"summary.Execute(arr)(arr):             {summary.Execute(arr):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"summary.Execute(list):                 {summary.Execute(list):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            Console.Write($"summary.Execute(arr, EnumSpeed.Slow):  {summary.Execute(arr, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"summary.Execute(list, EnumSpeed.Slow): {summary.Execute(list, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Count recursive & foreach.
        /// </summary>
        internal static void PrintCount()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Count recursive & foreach                    ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var count = CountHelper.Instance;
            var arr = array.RandomArray(2_000, 1_000);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var count = CountHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            Console.WriteLine(@"Faster:");
            var sw = Stopwatch.StartNew();
            Console.Write($"arr.Length:                          {arr.Length:N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"list.Count:                          {list.Count:N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"count.Execute(arr, EnumSpeed.Fast):  {count.Execute(arr, EnumSpeed.Fast):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"count.Execute(list, EnumSpeed.Fast): {count.Execute(list, EnumSpeed.Fast):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            Console.Write($"count.Execute(arr, EnumSpeed.Slow):  {count.Execute(arr, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"count.Execute(list, EnumSpeed.Slow): {count.Execute(list, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// First value recursive & foreach.
        /// </summary>
        internal static void PrintFirstValue()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                First value recursive & foreach                 ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var firstValue = FirstValueHelper.Instance;
            var arr = array.RandomArray(1_000, 1_000);
            var list = arr.ToList();
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var firstValue = FirstValueHelper.Instance;");
            Console.WriteLine("var arr = array.GetRandomArray(1_000, 1_000);");
            Console.WriteLine("var list = arr.ToList();");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            Console.WriteLine(@"Faster:");
            var sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(arr, EnumSort.Asc):   {firstValue.Execute(arr, EnumSortDirection.Asc):N0}.   ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(arr, EnumSort.Desc):  {firstValue.Execute(arr, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(list, EnumSort.Asc):  {firstValue.Execute(list, EnumSortDirection.Asc):N0}.   ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(list, EnumSort.Desc): {firstValue.Execute(list, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(arr, EnumSort.Asc, EnumSpeed.Slow):   {firstValue.Execute(arr, EnumSortDirection.Asc, EnumSpeed.Slow):N0}.   ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(arr, EnumSort.Desc, EnumSpeed.Slow):  {firstValue.Execute(arr, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(list, EnumSort.Asc, EnumSpeed.Slow):  {firstValue.Execute(list, EnumSortDirection.Asc):N0}.   ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            Console.Write($"firstValue.Execute(list, EnumSort.Desc, EnumSpeed.Slow): {firstValue.Execute(list, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Sort selection.
        /// </summary>
        internal static void PrintSortSelection()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                         Sort selection                         ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            Console.WriteLine(@"var _array = ArrayHelper.Instance;");
            var sortSelection = SortHelper.Instance;
            Console.WriteLine(@"var _sortSelection = SortHelper.Instance;");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            Console.WriteLine(@"Faster:");
            var arr = array.RandomArray(15_000, 100_000);
            var sw = Stopwatch.StartNew();
            sortSelection.GetExecuteSelection(arr, EnumSortDirection.Asc);
            sw.Stop();
            Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. With return value.");
            arr = array.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            sortSelection.ExecuteSelection(arr, EnumSortDirection.Asc);
            sw.Stop();
            Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. Without return value.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Middle.
            Console.WriteLine(@"Middle:");
            arr = array.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            sortSelection.GetExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Middle);
            sw.Stop();
            Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. With return value.");
            arr = array.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            sortSelection.ExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Middle);
            sw.Stop();
            Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. Without return value.");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            arr = array.RandomArray(15_000, 100_000);
            Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            sortSelection.ExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Slow);
            sw.Stop();
            Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Quick sort.
        /// </summary>
        internal static void PrintSortQuick()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                           Quick sort                           ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var array = ArrayHelper.Instance;
            var sortQuick = SortHelper.Instance;
            var arr = array.RandomArray(1_000_000, 1_000_000);
            Console.WriteLine("var array = ArrayHelper.Instance;");
            Console.WriteLine("var sortQuick = SortQuickHelper.Instance;");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            Console.WriteLine(@"Faster:");
            Console.WriteLine("var arr = array.GetRandomArray(1_000_000, 1_000_000);");
            var sw = Stopwatch.StartNew();
            sortQuick.GetExecuteQuick(arr, EnumSortDirection.Asc);
            Console.Write("sortQuick.Execute(arr, EnumSortDirection.Asc);. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");

            sw = Stopwatch.StartNew();
            sortQuick.GetExecuteQuick(arr, EnumSortDirection.Asc, EnumSpeed.Fast, true);
            Console.Write("sortQuick.Execute(arr, EnumSortDirection.Asc, EnumSpeed.Fast, true);. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
            Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            Console.WriteLine(@"Slower:");
            Console.WriteLine("var arr = array.GetRandomArray(10_000, 1_000_000);");
            sw = Stopwatch.StartNew();
            arr = array.RandomArray(10_000, 1_000_000);
            sortQuick.GetExecuteQuick(arr.ToList());
            Console.Write("sortQuick.ExecuteQuick(arr.ToList());. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
            
            sw = Stopwatch.StartNew();
            arr = array.RandomArray(10_000, 1_000_000);
            sortQuick.GetExecuteQuick(arr.ToList(), EnumSortDirection.Desc);
            Console.Write("sortQuick.ExecuteQuick(arr.ToList(), EnumSortDirection.Desc);. ");
            sw.Stop();
            Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
        }

        internal static void SetValue(string input, out int value, int defValue)
        {
            try
            {
                value = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error input value. The new value will be set to: {defValue}");
                value = defValue;
            }
        }

        internal static void SetValueSafe(string input, out int value, int defValue)
        {
            if (int.TryParse(input, out int res))
            {
                value = res;
            }
            else
            {
                Console.WriteLine($"Error input value. The new value will be set to: {defValue}");
                value = defValue;
            }
        }
    }
}
