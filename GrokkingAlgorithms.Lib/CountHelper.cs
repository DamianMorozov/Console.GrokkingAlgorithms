// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Counter helper.
    /// </summary>
    public sealed class CountHelper
    {
        #region Design pattern "Lazy Singleton"

        private static CountHelper _instance;
        public static CountHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

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

        /// <summary>
        /// Execute method using recursion.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private int ExecuteRecursive(int?[] arr)
        {
            if (arr.Length == 0)
                return 0;
            List<int?> list = arr.ToList();
            list.RemoveAt(0);
            return 1 + ExecuteRecursive(list.ToArray());
        }

        /// <summary>
        /// Execute method using foreach.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private int ExecuteForeach(int?[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
                result++;
            return result;
        }

        /// <summary>
        /// Execute method using recursion.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private int ExecuteRecursive(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            return 1 + ExecuteRecursive(list.Skip(1));
        }

        /// <summary>
        /// Execute method using foreach.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private int ExecuteForeach(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            int result = 0;
            foreach (int? item in list)
                result++;
            return result;
        }

        #endregion
    }
}
