// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GrokkingAlgorithms.Console.Tests")]

namespace GrokkingAlgorithms.Console
{
    internal static class Program
    {
        private static AppHelper AppHelp { get; set; } = AppHelper.Instance;

        internal static void Main()
        {
            int numberMenu = -1;
            while (numberMenu != 0)
            {
                PrintCaption();
                try
                {
                    numberMenu = Convert.ToInt32(System.Console.ReadLine());
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine("Error: " + exception.Message);
                    numberMenu = -1;
                }
                System.Console.WriteLine();
                PrintSwitch(numberMenu);
            }
        }

        internal static void PrintCaption()
        {
            System.Console.Clear();
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                       Grokking Algorithms                      ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(" 0. Exit from console.");
            System.Console.WriteLine(" 1. Binary search.");
            System.Console.WriteLine(" 2. Recursion.");
            System.Console.WriteLine(" 3. Summary recursive & foreach.");
            System.Console.WriteLine(" 4. Count values recursive & foreach.");
            System.Console.WriteLine(" 5. First value recursive & foreach.");
            System.Console.WriteLine(" 6. Sort selection.");
            System.Console.WriteLine(" 7. Quick sort.");
            System.Console.WriteLine(" 8. Quick sorting for a single file.");
            System.Console.WriteLine(" 9. Quick sorting for directory files.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.Write("Type switch: ");
        }

        internal static void PrintSwitch(int numberMenu)
        {
            System.Console.Clear();
            bool isPrintMenu = false;
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
                    PrintQuickSort();
                    break;
                case 8:
                    isPrintMenu = true;
                    PrintFileQuickSort();
                    break;
                case 9:
                    isPrintMenu = true;
                    PrintDirQuickSort();
                    break;
            }
            if (isPrintMenu)
            {
                System.Console.WriteLine(@"----------------------------------------------------------------------");
                System.Console.Write("Type any key to return in main menu.");
                System.Console.ReadKey();
            }
        }

        /// <AppHelp.SummaryHelp>
        /// Binary search.
        /// </AppHelp.SummaryHelp>
        internal static void PrintBinarySearch()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                         Binary search                          ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            System.Console.Write("Type start value (default is 1): ");
            SetValueSafe(System.Console.ReadLine(), out int startValue, 1);
            System.Console.Write("Type end value (default is 1_000_000): ");
            SetValueSafe(System.Console.ReadLine(), out int endValue, 1_000_000);
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            int?[] arr = AppHelp.ArrayHelp.SortArray(startValue, endValue, EnumSortDirect.Asc);
            List<int?> list = arr.ToList();
            System.Console.WriteLine($"var arr = _array.GetSortArray({startValue}, {endValue}, EnumSort.Asc);");
            System.Console.WriteLine("var list = arr.ToList();");
            int?[] arrDesc = AppHelp.ArrayHelp.SortArray(endValue, startValue, EnumSortDirect.Desc);
            List<int?> listDesc = arrDesc.ToList();
            System.Console.WriteLine($"var arrDesc = _array.GetSortArray({endValue}, {startValue}, EnumSort.Desc);");
            System.Console.WriteLine($"var listDesc = arrDesc.ToList();");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");

            Stopwatch sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arr, 123_456, EnumSort.Asc): {AppHelp.BinarySearchHelp.Execute(arr, 123_456, EnumSortDirect.Asc)}.  ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(list, 123_456, EnumSort.Asc): {AppHelp.BinarySearchHelp.Execute(list, 123_456, EnumSortDirect.Asc)}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arr, 12, EnumSort.Asc): {AppHelp.BinarySearchHelp.Execute(arr, 12, EnumSortDirect.Asc)}.           ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(list, 12, EnumSort.Asc): {AppHelp.BinarySearchHelp.Execute(list, 12, EnumSortDirect.Asc)}.          ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arrDesc, 123_456, EnumSort.Desc): {AppHelp.BinarySearchHelp.Execute(arrDesc, 123_456, EnumSortDirect.Desc)}.  ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(listDesc, 123_456, EnumSort.Desc): {AppHelp.BinarySearchHelp.Execute(listDesc, 123_456, EnumSortDirect.Desc)}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arrDesc, 12, EnumSort.Desc): {AppHelp.BinarySearchHelp.Execute(arrDesc, 12, EnumSortDirect.Desc)}.       ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(listDesc, 12, EnumSort.Desc): {AppHelp.BinarySearchHelp.Execute(listDesc, 12, EnumSortDirect.Desc)}.      ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <AppHelp.SummaryHelp>
        /// Recursion.
        /// </AppHelp.SummaryHelp>
        internal static void PrintRecursion()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                            Recursion                           ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            Stopwatch sw = Stopwatch.StartNew();
            System.Console.WriteLine($"Factorial(8): {AppHelp.RecursionHelp.Factorial(8):N0}");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <AppHelp.SummaryHelp>
        /// Summary recursive & foreach.
        /// </AppHelp.SummaryHelp>
        internal static void PrintSummary()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                   Summary recursive & foreach                  ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            int?[] arr = AppHelp.ArrayHelp.RandomArray(2_000, 1_000);
            List<int?> list = arr.ToList();
            System.Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000);");
            System.Console.WriteLine("var list = arr.ToList();");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");

            Stopwatch sw = Stopwatch.StartNew();
            System.Console.Write($"SummaryHelp.Execute(arr)(arr):             {AppHelp.SummaryHelp.Execute(arr):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"SummaryHelp.Execute(list):                 {AppHelp.SummaryHelp.Execute(list):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            System.Console.Write($"SummaryHelp.Execute(arr, EnumSpeed.Slow):  {AppHelp.SummaryHelp.Execute(arr, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"SummaryHelp.Execute(list, EnumSpeed.Slow): {AppHelp.SummaryHelp.Execute(list, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <AppHelp.SummaryHelp>
        /// Count recursive & foreach.
        /// </AppHelp.SummaryHelp>
        internal static void PrintCount()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                   Count recursive & foreach                    ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            int?[] arr = AppHelp.ArrayHelp.RandomArray(2_000, 1_000);
            List<int?> list = arr.ToList();
            System.Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000);");
            System.Console.WriteLine("var list = arr.ToList();");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");
            Stopwatch sw = Stopwatch.StartNew();
            System.Console.Write($"arr.Length:                          {arr.Length:N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"list.Count:                          {list.Count:N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"count.Execute(arr, EnumSpeed.Fast):  {AppHelp.CountHelp.Execute(arr, EnumSpeed.Fast):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"count.Execute(list, EnumSpeed.Fast): {AppHelp.CountHelp.Execute(list, EnumSpeed.Fast):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            System.Console.Write($"count.Execute(arr, EnumSpeed.Slow):  {AppHelp.CountHelp.Execute(arr, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"count.Execute(list, EnumSpeed.Slow): {AppHelp.CountHelp.Execute(list, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <AppHelp.SummaryHelp>
        /// First value recursive & foreach.
        /// </AppHelp.SummaryHelp>
        internal static void PrintFirstValue()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                First value recursive & foreach                 ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            int?[] arr = AppHelp.ArrayHelp.RandomArray(1_000, 1_000);
            List<int?> list = arr.ToList();
            System.Console.WriteLine("var arr = array.GetRandomArray(1_000, 1_000);");
            System.Console.WriteLine("var list = arr.ToList();");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");
            Stopwatch sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(arr, EnumSort.Asc):   {AppHelp.FirstValueHelp.Execute(arr, EnumSortDirect.Asc):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(arr, EnumSort.Desc):  {AppHelp.FirstValueHelp.Execute(arr, EnumSortDirect.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(list, EnumSort.Asc):  {AppHelp.FirstValueHelp.Execute(list, EnumSortDirect.Asc):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(list, EnumSort.Desc): {AppHelp.FirstValueHelp.Execute(list, EnumSortDirect.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(arr, EnumSort.Asc, EnumSpeed.Slow):   {AppHelp.FirstValueHelp.Execute(arr, EnumSortDirect.Asc, EnumSpeed.Slow):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(arr, EnumSort.Desc, EnumSpeed.Slow):  {AppHelp.FirstValueHelp.Execute(arr, EnumSortDirect.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(list, EnumSort.Asc, EnumSpeed.Slow):  {AppHelp.FirstValueHelp.Execute(list, EnumSortDirect.Asc):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"FirstValueHelp.Execute(list, EnumSort.Desc, EnumSpeed.Slow): {AppHelp.FirstValueHelp.Execute(list, EnumSortDirect.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <AppHelp.SummaryHelp>
        /// Sort selection.
        /// </AppHelp.SummaryHelp>
        internal static void PrintSortSelection()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                         Sort selection                         ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");
            int?[] arr = AppHelp.ArrayHelp.RandomArray(15_000, 100_000);
            Stopwatch sw = Stopwatch.StartNew();
            AppHelp.SortHelp.GetExecuteSelection(arr, EnumSortDirect.Asc);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. With return value.");
            arr = AppHelp.ArrayHelp.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            AppHelp.SortHelp.ExecuteSelection(arr, EnumSortDirect.Asc);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. Without return value.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Middle.
            System.Console.WriteLine(@"Middle:");
            arr = AppHelp.ArrayHelp.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            AppHelp.SortHelp.GetExecuteSelection(arr, EnumSortDirect.Asc, EnumSpeed.Middle);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. With return value.");
            arr = AppHelp.ArrayHelp.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            AppHelp.SortHelp.ExecuteSelection(arr, EnumSortDirect.Asc, EnumSpeed.Middle);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. Without return value.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            arr = AppHelp.ArrayHelp.RandomArray(15_000, 100_000);
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            AppHelp.SortHelp.ExecuteSelection(arr, EnumSortDirect.Asc, EnumSpeed.Slow);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}.");
        }

        /// <AppHelp.SummaryHelp>
        /// Quick sort.
        /// </AppHelp.SummaryHelp>
        internal static void PrintQuickSort()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                           Quick sort                           ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            int?[] arr = AppHelp.ArrayHelp.RandomArray(1_000_000, 1_000_000);

            // Faster.
            System.Console.WriteLine(@"Faster:");
            System.Console.WriteLine("var arr = array.GetRandomArray(1_000_000, 1_000_000);");
            Stopwatch sw = Stopwatch.StartNew();
            AppHelp.SortHelp.GetExecuteQuick(arr, EnumSortDirect.Asc);
            System.Console.Write("sortQuick.Execute(arr, EnumSortDirection.Asc);. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");

            sw = Stopwatch.StartNew();
            AppHelp.SortHelp.GetExecuteQuick(arr, EnumSortDirect.Asc, EnumSpeed.Fast, true);
            System.Console.Write("sortQuick.Execute(arr, EnumSortDirection.Asc, EnumSpeed.Fast, true);. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            System.Console.WriteLine("var arr = array.GetRandomArray(10_000, 1_000_000);");
            sw = Stopwatch.StartNew();
            arr = AppHelp.ArrayHelp.RandomArray(10_000, 1_000_000);
            AppHelp.SortHelp.GetExecuteQuick(arr.ToList());
            System.Console.Write("sortQuick.ExecuteQuick(arr.ToList());. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");

            sw = Stopwatch.StartNew();
            arr = AppHelp.ArrayHelp.RandomArray(10_000, 1_000_000);
            AppHelp.SortHelp.GetExecuteQuick(arr.ToList(), EnumSortDirect.Desc);
            System.Console.Write("sortQuick.ExecuteQuick(arr.ToList(), EnumSortDirection.Desc);. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
        }

        /// <AppHelp.SummaryHelp>
        /// Quick sorting for a single file.
        /// </AppHelp.SummaryHelp>
        /// <param name="isBlock"></param>
        internal static void PrintFileQuickSort()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                 Quick sorting for a single file                ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@$"{nameof(AppHelp.StringCultureInfo)}: {AppHelp.StringCultureInfo.Name}");
            System.Console.WriteLine(@$"{nameof(AppHelp.StringCompareOptions)}: {AppHelp.StringCompareOptions}");
            System.Console.WriteLine(@$"{nameof(AppHelp.FileBlockRows)}: {AppHelp.FileBlockRows}");

            string fileIn = AppHelp.FileHelp.GetFileName(AppHelp.FileHelp.MessageGetFileInput, true);
            string fileOut = AppHelp.FileHelp.GetFileName(AppHelp.FileHelp.MessageGetFileOutput, false);
            AppHelp.SetIsFileBlockRows();
            AppHelp.SetFileBlockSize();

            Stopwatch sw = Stopwatch.StartNew();
            AppHelp.SortHelp.ExecuteQuick(fileIn, fileOut, EnumSortDirect.Asc);
            sw.Stop();
            System.Console.WriteLine($"{nameof(sw.Elapsed)}: {sw.Elapsed}. ");
        }

        /// <AppHelp.SummaryHelp>
        /// Quick sorting for directory files.
        /// </AppHelp.SummaryHelp>
        internal static void PrintDirQuickSort()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                Quick sorting for directory files               ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@$"{nameof(AppHelp.StringCultureInfo)}: {AppHelp.StringCultureInfo}");
            System.Console.WriteLine(@$"{nameof(AppHelp.StringCompareOptions)}: {AppHelp.StringCompareOptions}");

            string dirIn = string.Empty;
            string dirOut = string.Empty;
            do
            {
                if (!string.IsNullOrEmpty(dirIn) || !string.IsNullOrEmpty(dirOut))
                    System.Console.WriteLine($"Retype directory names.");
                dirIn = AppHelp.FileHelp.GetDirectoryName(AppHelp.FileHelp.MessageGetDirectoryInput);
                dirOut = AppHelp.FileHelp.GetDirectoryName(AppHelp.FileHelp.MessageGetDirectoryOutput);
            } while (dirIn.Equals(dirOut));
            AppHelp.SetIsFileBlockRows();
            AppHelp.SetFileBlockSize();

            Stopwatch sw = Stopwatch.StartNew();
            foreach (string fileIn in Directory.GetFiles(dirIn))
            {
                string fileOut = Path.Combine(dirOut, Path.GetFileName(fileIn));
                //string contentIn = AppHelp.FileHelp.GetFileContent(fileIn);
                //IEnumerable<string> contentOut = AppHelp.SortHelp.GetExecuteQuick(contentIn.Split(Environment.NewLine), EnumSortDirect.Asc);
                //AppHelp.FileHelp.SetFileContent(fileOut, contentOut, true, true);
                AppHelp.SortHelp.ExecuteQuick(fileIn, fileOut, EnumSortDirect.Asc);
            }
            sw.Stop();
            System.Console.WriteLine($"{nameof(sw.Elapsed)}: {sw.Elapsed}. ");
        }

        internal static void SetValue(string input, out int value, int defValue)
        {
            try
            {
                value = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                System.Console.WriteLine($"Error input value. The new value will be set to: {defValue}");
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
                System.Console.WriteLine($"Error input value. The new value will be set to: {defValue}");
                value = defValue;
            }
        }
    }
}
