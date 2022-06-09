// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Summary helper.
    /// </summary>
    public sealed class SummaryHelper
    {
        #region Design pattern "Lazy Singleton"

        private static SummaryHelper _instance;
        public static SummaryHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Public and private methods

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
            int result = 0;
            foreach (int? item in arr)
                result += item == null ? 0 : (int)item;
            return result;
        }

        private int ExecuteForeach(IEnumerable<int?> list)
        {
            int result = 0;
            foreach (int? item in list)
                result += item == null ? 0 : (int)item;
            return result;
        }

        private int ExecuteRecursive(int?[] arr)
        {
            if (arr.Length == 0)
                return 0;
            int value = arr[0] != null ? (int)arr[0] : 0;
            List<int?> list = arr.ToList();
            list.RemoveAt(0);
            return value + ExecuteRecursive(list.ToArray());
        }

        private int ExecuteRecursive(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            return (list.Take(1).First() == null ? 0 : (int)list.Take(1).First()) + ExecuteRecursive(list.Skip(1));
        }

        #endregion
    }
}
