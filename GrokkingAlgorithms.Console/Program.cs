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
            System.Console.WriteLine("0. Exit from console.");
            System.Console.WriteLine("1. Binary search.");
            System.Console.WriteLine("2. Recursion.");
            System.Console.WriteLine("3. Summary recursive & foreach.");
            System.Console.WriteLine("4. Count values recursive & foreach.");
            System.Console.WriteLine("5. First value recursive & foreach.");
            System.Console.WriteLine("6. Sort selection.");
            System.Console.WriteLine("7. Quick sort.");
            System.Console.WriteLine("8. Quick sort for one file.");
            System.Console.WriteLine("9. Quick sort for directory files.");
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

        /// <summary>
        /// Binary search.
        /// </summary>
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

            BinarySearchHelper binarySearch = BinarySearchHelper.Instance;
            ArrayHelper array = ArrayHelper.Instance;
            int?[] arr = array.SortArray(startValue, endValue, EnumSortDirection.Asc);
            System.Collections.Generic.List<int?> list = arr.ToList();
            System.Console.WriteLine($"var arr = _array.GetSortArray({startValue}, {endValue}, EnumSort.Asc);");
            System.Console.WriteLine("var list = arr.ToList();");
            int?[] arrDesc = array.SortArray(endValue, startValue, EnumSortDirection.Desc);
            System.Collections.Generic.List<int?> listDesc = arrDesc.ToList();
            System.Console.WriteLine($"var arrDesc = _array.GetSortArray({endValue}, {startValue}, EnumSort.Desc);");
            System.Console.WriteLine($"var listDesc = arrDesc.ToList();");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");

            Stopwatch sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arr, 123_456, EnumSort.Asc): {binarySearch.Execute(arr, 123_456, EnumSortDirection.Asc)}.  ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(list, 123_456, EnumSort.Asc): {binarySearch.Execute(list, 123_456, EnumSortDirection.Asc)}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arr, 12, EnumSort.Asc): {binarySearch.Execute(arr, 12, EnumSortDirection.Asc)}.           ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(list, 12, EnumSort.Asc): {binarySearch.Execute(list, 12, EnumSortDirection.Asc)}.          ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arrDesc, 123_456, EnumSort.Desc): {binarySearch.Execute(arrDesc, 123_456, EnumSortDirection.Desc)}.  ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(listDesc, 123_456, EnumSort.Desc): {binarySearch.Execute(listDesc, 123_456, EnumSortDirection.Desc)}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");

            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(arrDesc, 12, EnumSort.Desc): {binarySearch.Execute(arrDesc, 12, EnumSortDirection.Desc)}.       ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"Execute(listDesc, 12, EnumSort.Desc): {binarySearch.Execute(listDesc, 12, EnumSortDirection.Desc)}.      ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Recursion.
        /// </summary>
        internal static void PrintRecursion()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                            Recursion                           ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            RecursionHelper recursion = RecursionHelper.Instance;
            System.Console.WriteLine($"{nameof(RecursionHelper)} {nameof(recursion)} = {nameof(RecursionHelper)}.{nameof(RecursionHelper.Instance)};");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            Stopwatch sw = Stopwatch.StartNew();
            System.Console.WriteLine($"Factorial(8): {recursion.Factorial(8):N0}");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Summary recursive & foreach.
        /// </summary>
        internal static void PrintSummary()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                   Summary recursive & foreach                  ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            ArrayHelper array = ArrayHelper.Instance;
            SummaryHelper summary = SummaryHelper.Instance;
            int?[] arr = array.RandomArray(2_000, 1_000);
            System.Collections.Generic.List<int?> list = arr.ToList();
            System.Console.WriteLine("var array = ArrayHelper.Instance;");
            System.Console.WriteLine("var summary = SummaryHelper.Instance;");
            System.Console.WriteLine("var arr = array.GetRandomArray(2_000, 1_000);");
            System.Console.WriteLine("var list = arr.ToList();");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");

            Stopwatch sw = Stopwatch.StartNew();
            System.Console.Write($"summary.Execute(arr)(arr):             {summary.Execute(arr):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"summary.Execute(list):                 {summary.Execute(list):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            System.Console.Write($"summary.Execute(arr, EnumSpeed.Slow):  {summary.Execute(arr, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"summary.Execute(list, EnumSpeed.Slow): {summary.Execute(list, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Count recursive & foreach.
        /// </summary>
        internal static void PrintCount()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                   Count recursive & foreach                    ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            ArrayHelper array = ArrayHelper.Instance;
            CountHelper count = CountHelper.Instance;
            int?[] arr = array.RandomArray(2_000, 1_000);
            System.Collections.Generic.List<int?> list = arr.ToList();
            System.Console.WriteLine("var array = ArrayHelper.Instance;");
            System.Console.WriteLine("var count = CountHelper.Instance;");
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
            System.Console.Write($"count.Execute(arr, EnumSpeed.Fast):  {count.Execute(arr, EnumSpeed.Fast):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"count.Execute(list, EnumSpeed.Fast): {count.Execute(list, EnumSpeed.Fast):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            System.Console.Write($"count.Execute(arr, EnumSpeed.Slow):  {count.Execute(arr, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"count.Execute(list, EnumSpeed.Slow): {count.Execute(list, EnumSpeed.Slow):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// First value recursive & foreach.
        /// </summary>
        internal static void PrintFirstValue()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                First value recursive & foreach                 ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            ArrayHelper array = ArrayHelper.Instance;
            FirstValueHelper firstValue = FirstValueHelper.Instance;
            int?[] arr = array.RandomArray(1_000, 1_000);
            System.Collections.Generic.List<int?> list = arr.ToList();
            System.Console.WriteLine("var array = ArrayHelper.Instance;");
            System.Console.WriteLine("var firstValue = FirstValueHelper.Instance;");
            System.Console.WriteLine("var arr = array.GetRandomArray(1_000, 1_000);");
            System.Console.WriteLine("var list = arr.ToList();");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");
            Stopwatch sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(arr, EnumSort.Asc):   {firstValue.Execute(arr, EnumSortDirection.Asc):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(arr, EnumSort.Desc):  {firstValue.Execute(arr, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(list, EnumSort.Asc):  {firstValue.Execute(list, EnumSortDirection.Asc):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(list, EnumSort.Desc): {firstValue.Execute(list, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(arr, EnumSort.Asc, EnumSpeed.Slow):   {firstValue.Execute(arr, EnumSortDirection.Asc, EnumSpeed.Slow):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(arr, EnumSort.Desc, EnumSpeed.Slow):  {firstValue.Execute(arr, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(list, EnumSort.Asc, EnumSpeed.Slow):  {firstValue.Execute(list, EnumSortDirection.Asc):N0}.   ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
            sw = Stopwatch.StartNew();
            System.Console.Write($"firstValue.Execute(list, EnumSort.Desc, EnumSpeed.Slow): {firstValue.Execute(list, EnumSortDirection.Desc):N0}. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Sort selection.
        /// </summary>
        internal static void PrintSortSelection()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                         Sort selection                         ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            ArrayHelper array = ArrayHelper.Instance;
            System.Console.WriteLine(@"var _array = ArrayHelper.Instance;");
            SortHelper sortSelection = SortHelper.Instance;
            System.Console.WriteLine(@"var _sortSelection = SortHelper.Instance;");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");
            int?[] arr = array.RandomArray(15_000, 100_000);
            Stopwatch sw = Stopwatch.StartNew();
            sortSelection.GetExecuteSelection(arr, EnumSortDirection.Asc);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. With return value.");
            arr = array.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            sortSelection.ExecuteSelection(arr, EnumSortDirection.Asc);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. Without return value.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Middle.
            System.Console.WriteLine(@"Middle:");
            arr = array.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            sortSelection.GetExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Middle);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. With return value.");
            arr = array.RandomArray(15_000, 100_000);
            sw = Stopwatch.StartNew();
            sortSelection.ExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Middle);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}. Without return value.");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            arr = array.RandomArray(15_000, 100_000);
            System.Console.WriteLine(@"Slower:");
            sw = Stopwatch.StartNew();
            sortSelection.ExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Slow);
            sw.Stop();
            System.Console.WriteLine($"Count items: {arr.Length:N0}. Elapsed time: {sw.Elapsed}.");
        }

        /// <summary>
        /// Quick sort.
        /// </summary>
        internal static void PrintQuickSort()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                           Quick sort                           ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            ArrayHelper array = ArrayHelper.Instance;
            SortHelper sortQuick = SortHelper.Instance;
            int?[] arr = array.RandomArray(1_000_000, 1_000_000);
            System.Console.WriteLine("var array = ArrayHelper.Instance;");
            System.Console.WriteLine("var sortQuick = SortQuickHelper.Instance;");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Faster.
            System.Console.WriteLine(@"Faster:");
            System.Console.WriteLine("var arr = array.GetRandomArray(1_000_000, 1_000_000);");
            Stopwatch sw = Stopwatch.StartNew();
            sortQuick.GetExecuteQuick(arr, EnumSortDirection.Asc);
            System.Console.Write("sortQuick.Execute(arr, EnumSortDirection.Asc);. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");

            sw = Stopwatch.StartNew();
            sortQuick.GetExecuteQuick(arr, EnumSortDirection.Asc, EnumSpeed.Fast, true);
            System.Console.Write("sortQuick.Execute(arr, EnumSortDirection.Asc, EnumSpeed.Fast, true);. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            // Slower.
            System.Console.WriteLine(@"Slower:");
            System.Console.WriteLine("var arr = array.GetRandomArray(10_000, 1_000_000);");
            sw = Stopwatch.StartNew();
            arr = array.RandomArray(10_000, 1_000_000);
            sortQuick.GetExecuteQuick(arr.ToList());
            System.Console.Write("sortQuick.ExecuteQuick(arr.ToList());. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");

            sw = Stopwatch.StartNew();
            arr = array.RandomArray(10_000, 1_000_000);
            sortQuick.GetExecuteQuick(arr.ToList(), EnumSortDirection.Desc);
            System.Console.Write("sortQuick.ExecuteQuick(arr.ToList(), EnumSortDirection.Desc);. ");
            sw.Stop();
            System.Console.WriteLine($"Elapsed time: {sw.Elapsed}. ");
        }

        /// <summary>
        /// Quick sort for file.
        /// </summary>
        internal static void PrintFileQuickSort()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                         File quick sort                        ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            FileHelper fileHelper = FileHelper.Instance;
            SortHelper sortQuick = SortHelper.Instance;

            string fileIn = fileHelper.GetFileName(fileHelper.MessageGetFileInput, true);
            string fileOut = fileHelper.GetFileName(fileHelper.MessageGetFileOutput, false);
            string contentIn = fileHelper.GetFileContent(fileIn);

            Stopwatch sw = Stopwatch.StartNew();
            IEnumerable<string> contentOut = sortQuick.GetExecuteQuick(contentIn.Split(Environment.NewLine), EnumSortDirection.Asc);
            fileHelper.SetFileContent(fileOut, contentOut, true, true);
            sw.Stop();
            System.Console.WriteLine($"{nameof(sw.Elapsed)}: {sw.Elapsed}. ");
        }

        /// <summary>
        /// Quick sort for directory.
        /// </summary>
        internal static void PrintDirQuickSort()
        {
            System.Console.WriteLine(@"----------------------------------------------------------------------");
            System.Console.WriteLine(@"---                      Directory quick sort                      ---");
            System.Console.WriteLine(@"----------------------------------------------------------------------");

            FileHelper fileHelper = FileHelper.Instance;
            SortHelper sortQuick = SortHelper.Instance;
            
            string dirIn = string.Empty;
            string dirOut = string.Empty;
            do
            {
                if (!string.IsNullOrEmpty(dirIn) || !string.IsNullOrEmpty(dirOut))
                    System.Console.WriteLine($"Retype directory names.");
                dirIn = fileHelper.GetDirectoryName(fileHelper.MessageGetDirectoryInput);
                dirOut = fileHelper.GetDirectoryName(fileHelper.MessageGetDirectoryOutput);
            } while (dirIn.Equals(dirOut));

            Stopwatch sw = Stopwatch.StartNew();
            foreach (string fileIn in Directory.GetFiles(dirIn))
            {
                string fileOut = Path.Combine(dirOut, Path.GetFileName(fileIn));
                string contentIn = fileHelper.GetFileContent(fileIn);
                IEnumerable<string> contentOut = sortQuick.GetExecuteQuick(contentIn.Split(Environment.NewLine), EnumSortDirection.Asc);
                fileHelper.SetFileContent(fileOut, contentOut, true, true);
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
