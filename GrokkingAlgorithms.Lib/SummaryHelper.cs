// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Summary helper.
    /// </summary>
    public sealed class SummaryHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SummaryHelper> _instance = new(() => new SummaryHelper());
        public static SummaryHelper Instance => _instance.Value;
        private SummaryHelper() { }

        #endregion

        /// <summary>
        /// Execute method. Fast - for & foreach. Slow - recursion.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public int Execute(int?[] arr, EnumSpeed speed = EnumSpeed.Fast)
        {
            return speed == EnumSpeed.Slow ? ExecuteRecursive(arr) : ExecuteForeach(arr);
        }

        /// <summary>
        /// Execute method. Fast - for & foreach. Slow - recursion.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public int Execute(IEnumerable<int?> list, EnumSpeed speed = EnumSpeed.Fast)
        {
            return speed == EnumSpeed.Slow ? ExecuteRecursive(list) : ExecuteForeach(list);
        }

        private int ExecuteForeach(int?[] arr)
        {
            var result = 0;
            foreach (var item in arr)
                result += item == null ? 0 : (int)item;
            return result;
        }

        private int ExecuteForeach(IEnumerable<int?> list)
        {
            var result = 0;
            foreach (var item in list)
                result += item == null ? 0 : (int)item;
            return result;
        }

        private int ExecuteRecursive(int?[] arr)
        {
            if (arr.Length == 0)
                return 0;
            var value = arr[0] != null ? (int)arr[0] : 0;
            var list = arr.ToList();
            list.RemoveAt(0);
            return value + ExecuteRecursive(list.ToArray());
        }

        private int ExecuteRecursive(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            return (list.Take(1).First() == null ? 0 : (int)list.Take(1).First()) + ExecuteRecursive(list.Skip(1));
        }
    }
}
