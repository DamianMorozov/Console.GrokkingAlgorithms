// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Sort helper.
    /// </summary>
    public sealed class SortHelper
    {
        #region Design pattern "Lazy Singleton"

        private static readonly Lazy<SortHelper> _instance = new(() => new SortHelper());
        public static SortHelper Instance => _instance.Value;

        #endregion

        #region Constructor and destructor

        private SortHelper()
        {
            // Type code here.
        }

        #endregion

        #region Selection sort methods without return value.

        /// <summary>
        /// Execute selection method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <param name="speed"></param>
        public void ExecuteSelection(int?[] content, EnumSortDirect sortDirect, EnumSpeed speed = EnumSpeed.Fast)
        {
            if (speed == EnumSpeed.Slow)
                ExecuteSelectionSlow(content, sortDirect);
            else if (speed == EnumSpeed.Middle)
                ExecuteSelectionMiddle(content, sortDirect);
            else
                ExecuteSelectionFast(content, sortDirect);
        }

        private void ExecuteSelectionSlow(int?[] content, EnumSortDirect sortDirect)
        {
            bool check = false;
            while (!check)
            {
                check = true;
                for (int i = 0; i < content.Length; i++)
                {
                    if (i + 1 < content.Length)
                    {
                        if (sortDirect == EnumSortDirect.Asc ? content[i] > content[i + 1] : content[i] < content[i + 1])
                        {
                            content[i] = content[i] + content[i + 1];
                            content[i + 1] = content[i] - content[i + 1];
                            content[i] = content[i] - content[i + 1];
                            check = false;
                        }
                    }
                }
            }
        }

        private void ExecuteSelectionMiddle(int?[] content, EnumSortDirect sortDirect)
        {
            bool check = false;
            int? swap;
            while (!check)
            {
                check = true;
                for (int i = 0; i < content.Length; i++)
                {
                    if (i + 1 < content.Length)
                    {
                        if (sortDirect == EnumSortDirect.Asc ? content[i] > content[i + 1] : content[i] < content[i + 1])
                        {
                            swap = content[i];
                            content[i] = content[i + 1];
                            content[i + 1] = swap;
                            check = false;
                        }
                    }
                }
            }
        }

        private void ExecuteSelectionFast(int?[] content, EnumSortDirect sortDirect)
        {
            List<int?> list = content.ToList();
            for (int i = 0; i < content.Length; i++)
            {
                (int pos, int? val) value = AppHelper.Instance.FirstValueHelp.Execute(list.ToArray(), sortDirect);
                content[i] = value.val;
                list.RemoveAt(value.pos);
            }
        }

        #endregion

        #region Selection sort methods with return value.

        public T[] GetExecuteSelection<T>(T[] content, EnumSortDirect sortDirect, EnumSpeed speed = EnumSpeed.Fast)
        {
            if (speed == EnumSpeed.Slow || speed == EnumSpeed.Middle)
                return GetExecuteSelectionMiddle(content, sortDirect);
            return GetExecuteSelectionFast(content, sortDirect);
        }

        private T[] GetExecuteSelectionMiddle<T>(T[] content, EnumSortDirect sortDirect)
        {
            T[] result = AppHelper.Instance.ArrayHelp.Copy(content);
            Comparer<T> comparer = Comparer<T>.Default;
            bool check = false;
            T swap;
            while (!check)
            {
                check = true;
                for (int i = 0; i < result.Length; i++)
                {
                    if (i + 1 < result.Length)
                    {
                        //if (sortDirect == EnumSortDirection.Asc ? result[i] > result[i + 1] : result[i] < result[i + 1])
                        if (sortDirect == EnumSortDirect.Asc
                            // ? result[i] > result[i + 1] 
                            ? comparer.Compare(result[i], result[i + 1]) > 0
                            // : result[i] < result[i + 1]
                            : comparer.Compare(result[i], result[i + 1]) < 0)
                        {
                            swap = result[i];
                            result[i] = result[i + 1];
                            result[i + 1] = swap;
                            check = false;
                        }
                    }
                }
            }
            return result;
        }

        private T[] GetExecuteSelectionFast<T>(T[] content, EnumSortDirect sortDirect)
        {
            T[] result = AppHelper.Instance.ArrayHelp.Copy(content);
            List<T> list = result.ToList();
            for (int i = 0; i < result.Length; i++)
            {
                (int pos, T val) value = AppHelper.Instance.FirstValueHelp.Execute(list.ToArray(), sortDirect);
                result[i] = value.val;
                list.RemoveAt(value.pos);
            }
            return result;
        }

        #endregion

        #region Quick sort methods with return value for int.

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <param name="speed"></param>
        /// <param name="useSwitchPivot"></param>
        /// <returns></returns>
        public IEnumerable<int?> GetExecuteQuick(int?[] content, EnumSortDirect sortDirect, EnumSpeed speed = EnumSpeed.Fast,
            bool useSwitchPivot = false)
        {
            if (speed == EnumSpeed.Slow)
                return GetExecuteQuickRecursiveSlow(content.ToList(), sortDirect);
            return useSwitchPivot
                ? GetExecuteQuickRecursiveFastWithSwitchPivot(content, sortDirect)
                : GetExecuteQuickRecursiveFast(content, sortDirect);
        }

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        public IEnumerable<int?> GetExecuteQuick(IEnumerable<int?> content, EnumSortDirect sortDirect = EnumSortDirect.Asc) =>
            GetExecuteQuickRecursiveSlow(content, sortDirect);

        /// <summary>
        /// Slow execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        private IEnumerable<int?> GetExecuteQuickRecursiveSlow(IEnumerable<int?> content, EnumSortDirect sortDirect)
        {
            if (content.Count() <= 1) { return content; }
            int? pivot = content.First();
            IEnumerable<int?> less;
            IEnumerable<int?> greater;

            if (sortDirect == EnumSortDirect.Asc)
            {
                less = content.Skip(1).Where(i => i <= pivot);
                greater = content.Skip(1).Where(i => i > pivot);
            }
            else
            {
                less = content.Skip(1).Where(i => i > pivot);
                greater = content.Skip(1).Where(i => i <= pivot);
            }
            return GetExecuteQuickRecursiveSlow(less, sortDirect).
                Union(new List<int?> { pivot }).
                Union(GetExecuteQuickRecursiveSlow(greater, sortDirect));
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        private int?[] GetExecuteQuickRecursiveFast(int?[] content, EnumSortDirect sortDirect)
        {
            if (content.Length <= 1) { return content; }
            int? pivot = content.First();
            // Use List for fast write.
            List<int?> less = new();
            List<int?> greater = new();
            //foreach (var item in arr.ToList().Skip(1))
            foreach (int? item in AppHelper.Instance.ArrayHelp.Sub(content, 1, content.Length - 1))
            {
                if (sortDirect == EnumSortDirect.Asc)
                    if (item <= pivot)
                        less.Add(item);
                    else
                        greater.Add(item);
                else
                    if (item > pivot)
                        less.Add(item);
                else
                    greater.Add(item);
            }
            return GetExecuteQuickRecursiveFast(less.ToArray(), sortDirect).
                Union(new int?[] { pivot }).
                Union(GetExecuteQuickRecursiveFast(greater.ToArray(), sortDirect)).ToArray();
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        private int?[] GetExecuteQuickRecursiveFastWithSwitchPivot(int?[] content, EnumSortDirect sortDirect)
        {
            if (content.Length <= 1) { return content; }
            int? pivot = content.First();
            int pos = 1;
            //		foreach (var item in SubArray(arr, 1, arr.Length-1))
            //		{
            //			if (sort == EnumSort.Asc)
            //				if (item <= pivot) { pivot = item; break; }
            //			else
            //				if (item > pivot) { pivot = item; break; }
            //			pivot = item;
            //			pos++;
            //		}
            foreach (int? item in AppHelper.Instance.ArrayHelp.Sub(content, 1, content.Length - 1))
            {
                if (sortDirect == EnumSortDirect.Asc)
                    if (item <= content[pos - 1]) break;
                    else if (item > content[pos - 1]) break;
                pos++;
            }
            pivot = content[pos];
            // Use List for fast write.
            List<int?> less = new();
            List<int?> greater = new();

            List<int?> list = content.ToList();
            list.RemoveAt(pos);
            //foreach (var item in list)
            foreach (int? item in list.ToArray())
            {
                if (sortDirect == EnumSortDirect.Asc)
                    if (item <= pivot)
                        less.Add(item);
                    else
                        greater.Add(item);
                else
                    if (item > pivot)
                        less.Add(item);
                else
                    greater.Add(item);
            }
            return GetExecuteQuickRecursiveFastWithSwitchPivot(less.ToArray(), sortDirect).
                Union(new int?[] { pivot }).
                Union(GetExecuteQuickRecursiveFastWithSwitchPivot(greater.ToArray(), sortDirect)).ToArray();
        }

        #endregion

        #region Quick sort methods with return value for string.

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <param name="speed"></param>
        /// <param name="useSwitchPivot"></param>
        /// <returns></returns>
        public IEnumerable<string> GetExecuteQuick(string[] content, EnumSortDirect sortDirect, bool useSwitchPivot = false)
        {
            return useSwitchPivot
                ? GetExecuteQuickRecursiveFastWithSwitchPivot(content, sortDirect)
                : GetExecuteQuickRecursiveFast(content, sortDirect);
        }

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="fileIn"></param>
        /// <param name="fileOut"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        public void ExecuteQuick(string fileIn, string fileOut, EnumSortDirect sortDirect)
        {
            if (!File.Exists(fileIn))
                return;
            string fileTemp = fileOut + ".tmp";
            ulong blockRows = AppHelper.Instance.FileBlockRows;
            ulong fileRows = AppHelper.Instance.FileHelp.GetFileRowsCount(fileIn);

            // All data.
            if (!AppHelper.Instance.IsFileBlockRows || fileRows < blockRows)
            {
                //Console.WriteLine(fileRows < blockRows
                //    ? @$"Processing data (file have less rows ({fileRows}) than block limit ({blockRows}))..."
                //    : @$"Processing data (block mode is disabled)..."
                //);
                string contentIn = AppHelper.Instance.FileHelp.GetFileContent(fileIn);
                ExecuteQuickBlock(fileOut, sortDirect, contentIn.Split(Environment.NewLine), true);
            }
            // Block data.
            else
            {
                //Console.WriteLine(@$"Processing data (block mode is enabled)...");
                bool isStartMove = false;
                bool isBlockDouble = false;
                do
                {
                    if (!isBlockDouble)
                        ExecuteQuickBlockData(fileIn, fileOut, sortDirect, blockRows, fileRows);
                    else
                    {
                        // StartPosition = 0.
                        if (!isStartMove)
                        {
                            ExecuteQuickBlockData(fileIn, fileOut, sortDirect, blockRows * 2, fileRows);
                            isStartMove = true;
                        }
                        // Move StartPosition.
                        else
                        {
                            ExecuteQuickBlockData(fileIn, fileOut, sortDirect, blockRows * 2, fileRows, blockRows / 2);
                            isStartMove = false;
                        }
                    }
                    isBlockDouble = !isBlockDouble;
                    // Rotate files.
                    if (File.Exists(fileTemp))
                        File.Delete(fileTemp);
                    File.Copy(fileOut, fileTemp);
                    fileIn = fileTemp;
                } while (!FileHelper.IsFileSorted(fileOut, sortDirect));
                if (File.Exists(fileTemp))
                    File.Delete(fileTemp);
            }
            //Console.WriteLine(@$"Processing data complete.");
        }

        private void ExecuteQuickBlockData(string fileIn, string fileOut, EnumSortDirect sortDirect, ulong blockRows, ulong fileRows, ulong startRow = 0)
        {
            bool isRewriteFile = true;
            string[] dataBlock;

            // Working with initial data.
            if (startRow > 0)
            {
                //if (startRow % 2 != 0) startRow++;
                dataBlock = AppHelper.Instance.FileHelp.GetFileContentBlock(fileIn, 0, startRow);
                ExecuteQuickBlock(fileOut, sortDirect, dataBlock, isRewriteFile);
                if (isRewriteFile)
                    isRewriteFile = false;
            }

            // Working with sliced data.
            ulong count = (fileRows - startRow) / blockRows;
            ulong i;
            for (i = 0; i < count; i++)
            {
                dataBlock = AppHelper.Instance.FileHelp.GetFileContentBlock(fileIn, startRow + (i * blockRows), blockRows);
                ExecuteQuickBlock(fileOut, sortDirect, dataBlock, isRewriteFile);
                if (isRewriteFile)
                    isRewriteFile = false;
            }

            // Working with remaining data.
            ulong elapsedRows = fileRows - startRow - (blockRows * i);
            dataBlock = AppHelper.Instance.FileHelp.GetFileContentBlock(fileIn, startRow + (i * blockRows), elapsedRows);
            ExecuteQuickBlock(fileOut, sortDirect, dataBlock, isRewriteFile);
        }

        private void ExecuteQuickBlock(string fileOut, EnumSortDirect sortDirect, string[] content, bool isRewriteFile)
        {
            //IEnumerable<string> contentTransform = GetExecuteQuickRecursiveSlow(content.ToList(), sortDirect);
            IEnumerable<string> contentTransform = GetExecuteQuickRecursiveFast(content, sortDirect);
            AppHelper.Instance.FileHelp.SetFileContent(fileOut, contentTransform, isRewriteFile, true);
        }

        /// <summary>
        /// Slow execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        private IEnumerable<string> GetExecuteQuickRecursiveSlow(IEnumerable<string> content, EnumSortDirect sortDirect)
        {
            if (content.Count() <= 1) { return content; }
            string pivot = content.First();
            IEnumerable<string> less;
            IEnumerable<string> greater;

            if (sortDirect == EnumSortDirect.Asc)
            {
                // 1st: less = list.Skip(1).Where(i => i <= pivot);
                // 2nd: less = list.Skip(1).Where(i => i.CompareTo(pivot) <= 0); 
                // 3rd: current
                less = content.Skip(1).Where(i => string.Compare(i, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) <= 0);
                // 1st: greater = list.Skip(1).Where(i => i > pivot);
                // 2nd: greater = list.Skip(1).Where(i => i.CompareTo(pivot) > 0);
                // 3rd: current
                greater = content.Skip(1).Where(i => string.Compare(i, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) > 0);
            }
            else
            {
                // 1st: less = list.Skip(1).Where(i => i > pivot);
                // 2nd: less = list.Skip(1).Where(i => i.CompareTo(pivot) > 0);
                // 3rd: current
                less = content.Skip(1).Where(i => string.Compare(i, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) > 0);
                // 1st: greater = list.Skip(1).Where(i => i <= pivot);
                // 2nd: greater = list.Skip(1).Where(i => i.CompareTo(pivot) <= 0);
                // 3rd: current
                greater = content.Skip(1).Where(i => string.Compare(i, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) <= 0);
            }
            return GetExecuteQuickRecursiveSlow(less, sortDirect).
                Union(new List<string> { pivot }).
                Union(GetExecuteQuickRecursiveSlow(greater, sortDirect));
        }
        
        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        private string[] GetExecuteQuickRecursiveFast(string[] content, EnumSortDirect sortDirect)
        {
            if (content.Length <= 1) { return content; }
            string pivot = content.First();
            // Use List for fast write.
            List<string> less = new();
            List<string> greater = new();
            //foreach (var item in arr.ToList().Skip(1))
            foreach (string item in AppHelper.Instance.ArrayHelp.Sub(content, 1, content.Length - 1))
            {
                if (sortDirect == EnumSortDirect.Asc)
                    // 1st: if (item <= pivot)
                    // 2nd: if (item.CompareTo(pivot) <= 0)
                    // 3rd: current
                    if (string.Compare(item, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) <= 0)
                        less.Add(item);
                    else
                        greater.Add(item);
                else
                    // 1st: if (item > pivot)
                    // 2nd: if (item.CompareTo(pivot) > 0)
                    // 3rd: current
                    if (string.Compare(item, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) > 0)
                        less.Add(item);
                else
                    greater.Add(item);
            }
            return GetExecuteQuickRecursiveFast(less.ToArray(), sortDirect).
                Union(new string[] { pivot }).
                Union(GetExecuteQuickRecursiveFast(greater.ToArray(), sortDirect)).ToArray();
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        private string[] GetExecuteQuickRecursiveFastWithSwitchPivot(string[] content, EnumSortDirect sortDirect)
        {
            if (content.Length <= 1) { return content; }
            string pivot = content.First();
            int pos = 1;
            //		foreach (var item in SubArray(arr, 1, arr.Length-1))
            //		{
            //			if (sort == EnumSort.Asc)
            //				if (item <= pivot) { pivot = item; break; }
            //			else
            //				if (item > pivot) { pivot = item; break; }
            //			pivot = item;
            //			pos++;
            //		}
            foreach (string item in AppHelper.Instance.ArrayHelp.Sub(content, 1, content.Length - 1))
            {
                if (sortDirect == EnumSortDirect.Asc)
                    // 1st: if (item <= arr[pos - 1]) break;
                    // 2nd: if (item.CompareTo(arr[pos - 1]) <= 0) break;
                    // 3rd: current
                    if (string.Compare(item, content[pos - 1], AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) <= 0) break;
                    // 1st: else if (item > arr[pos - 1]) break;
                    // 2nd: else if (item.CompareTo(arr[pos - 1]) > 0) break;
                    // 3rd: current
                    else if (string.Compare(item, content[pos - 1], AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) > 0) break;
                pos++;
            }
            pivot = content[pos];
            // Use List for fast write.
            List<string> less = new();
            List<string> greater = new();

            List<string> list = content.ToList();
            list.RemoveAt(pos);
            //foreach (var item in list)
            foreach (string item in list.ToArray())
            {
                if (sortDirect == EnumSortDirect.Asc)
                    // 1st: if (item <= pivot)
                    // 2nd: if (item.CompareTo(pivot) <= 0)
                    // 3rd: current
                    if (string.Compare(item, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) <= 0)
                        less.Add(item);
                    else
                        greater.Add(item);
                else
                    // 1st: if (item > pivot)
                    // 2nd: if (item.CompareTo(pivot) > 0)
                    // 3rd: current
                    if (string.Compare(item, pivot, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) > 0)
                        less.Add(item);
                else
                    greater.Add(item);
            }
            return GetExecuteQuickRecursiveFastWithSwitchPivot(less.ToArray(), sortDirect).
                Union(new string[] { pivot }).
                Union(GetExecuteQuickRecursiveFastWithSwitchPivot(greater.ToArray(), sortDirect)).ToArray();
        }

        #endregion
    }
}
