// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Sort helper.
    /// </summary>
    public sealed class SortHelper
    {
        #region Design pattern "Lazy Singleton"

        private static SortHelper _instance;
        public static SortHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

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

        private int GetRowsBlock(bool isNeedMoreBlock)
        {
            return !isNeedMoreBlock ? AppHelper.Instance.FileRowsBlock : AppHelper.Instance.FileRowsBlock * 2;
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
            if (Equals(fileIn, fileOut))
            {
                Console.WriteLine($"Input file must be different than output file!");
                return;
            }
            int rowsCount = FileHelper.Instance.GetFileRowsCount(fileIn);

            // Check sorted.
            if (FileHelper.Instance.IsFileSorted(fileIn, sortDirect))
            {
                Console.WriteLine($"Input file was sorted and just copied!");
                if (File.Exists(fileOut))
                    File.Delete(fileOut);
                File.Copy(fileIn, fileOut);
                return;
            }

            // Transform all data per one time.
            if (!AppHelper.Instance.IsFileBlockRows || rowsCount < GetRowsBlock(false))
            {
                string[] content = FileHelper.Instance.GetFileContent(fileIn);
                ExecuteQuickBlock(fileOut, sortDirect, content, true);
            }
            // Transform all data per few times through blocks.
            else
            {
                do
                {
                    //int fileTempCount = FileHelper.Instance.GetFileTempCount(fileIn, GetRowsBlock(step % 2 == 0));
                    int fileTempCount = FileHelper.Instance.GetFileTempCount(fileIn, GetRowsBlock(false));
                    string[] filesTemp = FileHelper.Instance.GetFilesTemp(fileTempCount, fileIn, "tmp");
                    FileHelper.Instance.DeleteFiles(filesTemp);
                    FileHelper.Instance.SplitFiles(fileIn, filesTemp, GetRowsBlock(false));
                    if (fileTempCount == 1)
                    {
                        IEnumerable<string> contentTemp = FileHelper.Instance.GetFileContentAsEnumerable(filesTemp[0]);
                        string[] content = GetExecuteQuickRecursiveFast(contentTemp.ToArray(), sortDirect);
                        FileHelper.Instance.SetFileContent(fileOut, content, true);
                    }
                    else if (fileTempCount == 2)
                    {
                        IEnumerable<string> contentTemp = FileHelper.Instance.GetFileContentAsEnumerable(filesTemp);
                        string[] content = GetExecuteQuickRecursiveFast(contentTemp.ToArray(), sortDirect);
                        FileHelper.Instance.SetFileContent(fileOut, content, true);
                    }
                    else
                    {
                        foreach (string fileTemp in filesTemp)
                        {
                            IEnumerable<string> contentTemp = FileHelper.Instance.GetFileContentAsEnumerable(fileTemp);
                            //ExecuteQuickBlock(fileTemp, sortDirect, contentTemp.Split(Environment.NewLine), true);
                            string[] content = GetExecuteQuickRecursiveFast(contentTemp.ToArray(), sortDirect);
                            FileHelper.Instance.SetFileContent(fileTemp, content, true);
                        }
                        for (int i = 0; i < filesTemp.Count() - 1; i++)
                        {
                            long processMemoryBytes = Process.GetCurrentProcess().WorkingSet64;
                            if (processMemoryBytes > AppHelper.Instance.MemoryBytesLimit)
                            {
                                Console.WriteLine($"Allocated memory: {processMemoryBytes/1024:######} KB will be free.");
                                GC.Collect();
                            }
                            //string fileMerge = $"{filesTemp[i]}.merge";
                            //FileHelper.Instance.MergeFiles(new string[2] { filesTemp[i], filesTemp[i + 1] }, fileMerge);
                            //string[] contentMerge = FileHelper.Instance.GetFileContent(fileMerge);
                            IEnumerable<string> contentMerge = FileHelper.Instance.GetFileContentAsEnumerable(
                                new string[2] { filesTemp[i], filesTemp[i + 1] });
                            string[] content = GetExecuteQuickRecursiveFast(contentMerge.ToArray(), sortDirect);
                            //FileHelper.Instance.SetFileContent(fileMerge, content, true);
                            FileHelper.Instance.SetFileContent(filesTemp[i], Array.Empty<string>(), true);
                            FileHelper.Instance.SetFileContent(filesTemp[i + 1], Array.Empty<string>(), true);
                            FileHelper.Instance.SplitData(content, new string[2] { filesTemp[i], filesTemp[i + 1] }, GetRowsBlock(false));
                            //File.Delete(fileMerge);
                        }
                        FileHelper.Instance.MergeFiles(filesTemp, fileOut);
                    }
                    FileHelper.Instance.DeleteFiles(filesTemp);
                    fileIn = fileOut;
                    //step = step < 2 ? (byte)(step + 1) : (byte)0;
                } while (!FileHelper.Instance.IsFileSorted(fileOut, sortDirect));
            }
        }

        private void ExecuteQuickBlockData(string fileIn, string fileOut, EnumSortDirect sortDirect, int rowsBlock, int rowsFile, int rowStart)
        {
            bool isRewriteFile = true;
            string[] dataBlock;

            // Working with initial data.
            if (rowStart > 0)
            {
                dataBlock = FileHelper.Instance.GetFileContentBlock(fileIn, 0, rowStart);
                ExecuteQuickBlock(fileOut, sortDirect, dataBlock, isRewriteFile);
                if (isRewriteFile)
                    isRewriteFile = false;
            }

            // Working with sliced data.
            int count = (rowsFile - rowStart) / rowsBlock;
            int i;
            for (i = 0; i < count; i++)
            {
                dataBlock = FileHelper.Instance.GetFileContentBlock(fileIn, rowStart + (i * rowsBlock), rowsBlock);
                ExecuteQuickBlock(fileOut, sortDirect, dataBlock, isRewriteFile);
                if (isRewriteFile)
                    isRewriteFile = false;
            }

            // Working with remaining data.
            int elapsedRows = rowsFile - rowStart - (rowsBlock * i);
            dataBlock = FileHelper.Instance.GetFileContentBlock(fileIn, rowStart + (i * rowsBlock), elapsedRows);
            ExecuteQuickBlock(fileOut, sortDirect, dataBlock, isRewriteFile);
        }

        private void ExecuteQuickBlock(string fileOut, EnumSortDirect sortDirect, string[] content, bool isRewriteFile)
        {
            FileHelper.Instance.SetFileContent(fileOut, GetExecuteQuickRecursiveFast(content, sortDirect), isRewriteFile);
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
