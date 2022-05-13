// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// First value helper.
    /// </summary>
    public sealed class FirstValueHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<FirstValueHelper> _instance = new(() => new FirstValueHelper());
        public static FirstValueHelper Instance => _instance.Value;
        private FirstValueHelper() { }

        #endregion

        /// <summary>
        /// Execute method. Fast - for & foreach. Slow - recursion.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        public (int pos, int? val) Execute(int?[] arr, EnumSortDirect sortDirect)
        {
            return ExecuteForeach(arr, sortDirect);
        }

        /// <summary>
        /// Execute method. Fast - for & foreach. Slow - recursion.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        public (int pos, T val) Execute<T>(T[] arr, EnumSortDirect sortDirect)
        {
            return ExecuteForeach(arr, sortDirect);
        }

        /// <summary>
        /// Execute method. Fast - for & foreach. Slow - recursion.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sortDirect"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public (int pos, int? val) Execute(IEnumerable<int?> list, EnumSortDirect sortDirect, EnumSpeed speed = EnumSpeed.Fast)
        {
            return speed == EnumSpeed.Slow ? (-1, ExecuteRecursive(list, sortDirect)) : ExecuteForeach(list, sortDirect);
        }

        private (int pos, int? val) ExecuteForeach(int?[] arr, EnumSortDirect sortDirect)
        {
            if (arr.Length <= 0)
                return (-1, null);
            if (arr.Length == 1)
                return (0, arr[0]);
            var i = 0;
            int? value = null;
            for (var j = 0; j < arr.Length; j++)
            {
                if (value == null)
                    value = arr[j];
                else
                    if (arr[j] != null)
                {
                    if (sortDirect == EnumSortDirect.Asc)
                    {
                        if (value > arr[j])
                        {
                            value = arr[j];
                            i = j;
                        }
                    }
                    else
                    {
                        if (value < arr[j])
                        {
                            value = arr[j];
                            i = j;
                        }
                    }
                }
            }
            return (i, value);
        }

        private (int pos, T val) ExecuteForeach<T>(T[] arr, EnumSortDirect sortDirect)
        {
            if (arr.Length <= 0)
                return (-1, default(T));
            if (arr.Length == 1)
                return (0, arr[0]);
            var i = 0;
            var value = default(T);
            var comparer = Comparer<T>.Default;
            for (var j = 0; j < arr.Length; j++)
            {
                if (value == null)
                    value = arr[j];
                else
                    if (arr[j] != null)
                {
                    if (sortDirect == EnumSortDirect.Asc)
                    {
                        //if (value > arr[j])
                        if (comparer.Compare(value, arr[j]) > 0)
                        {
                            value = arr[j];
                            i = j;
                        }
                    }
                    else
                    {
                        //if (value < arr[j])
                        if (comparer.Compare(value, arr[j]) < 0)
                        {
                            value = arr[j];
                            i = j;
                        }
                    }
                }
            }
            return (i, value);
        }

        private (int pos, int? val) ExecuteForeach(IEnumerable<int?> list, EnumSortDirect sortDirect)
        {
            int i = 0, j = 0;
            int? value = null;
            foreach (var item in list)
            {
                if (value == null)
                    value = item;
                else
                    if (item != null)
                {
                    if (sortDirect == EnumSortDirect.Asc)
                    {
                        if (value > item)
                        {
                            value = item;
                            i = j;
                        }
                    }
                    else
                    {
                        if (value < item)
                        {
                            value = item;
                            i = j;
                        }
                    }
                }
                j++;
            }
            return (i, value);
        }

        private int? ExecuteRecursive(IEnumerable<int?> list, EnumSortDirect sortDirect)
        {
            if (!list.Any()) return null;
            if (list.Count() == 1) return list.First();
            if (list.Count() == 2) return sortDirect == EnumSortDirect.Desc
                ? list.First() > list.Skip(1).Take(1).First() ? list.First() : list.Skip(1).Take(1).First()
                : list.First() < list.Skip(1).Take(1).First() ? list.First() : list.Skip(1).Take(1).First();
            var sub_max = ExecuteRecursive(list.Skip(1), sortDirect);
            return sortDirect == EnumSortDirect.Desc
                ? list.First() > sub_max ? list.First() : sub_max
                : list.First() < sub_max ? list.First() : sub_max;
        }
    }
}
