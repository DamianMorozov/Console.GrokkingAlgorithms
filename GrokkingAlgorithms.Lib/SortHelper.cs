﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
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

        #region Public and private fields and properties

        private readonly ArrayHelper _array = ArrayHelper.Instance;
        private readonly FirstValueHelper _firstValueHelper = FirstValueHelper.Instance;

        #endregion

        #region Selection sort methods without return value.

        /// <summary>
        /// Execute selection method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <param name="speed"></param>
        public void ExecuteSelection(int?[] arr, EnumSortDirection sortDirection, EnumSpeed speed = EnumSpeed.Fast)
        {
            if (speed == EnumSpeed.Slow)
                ExecuteSelectionSlow(arr, sortDirection);
            else if (speed == EnumSpeed.Middle)
                ExecuteSelectionMiddle(arr, sortDirection);
            else
                ExecuteSelectionFast(arr, sortDirection);
        }

        private void ExecuteSelectionSlow(int?[] arr, EnumSortDirection sortDirection)
        {
            bool check = false;
            while (!check)
            {
                check = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i + 1 < arr.Length)
                    {
                        if (sortDirection == EnumSortDirection.Asc ? arr[i] > arr[i + 1] : arr[i] < arr[i + 1])
                        {
                            arr[i] = arr[i] + arr[i + 1];
                            arr[i + 1] = arr[i] - arr[i + 1];
                            arr[i] = arr[i] - arr[i + 1];
                            check = false;
                        }
                    }
                }
            }
        }

        private void ExecuteSelectionMiddle(int?[] arr, EnumSortDirection sortDirection)
        {
            bool check = false;
            int? swap;
            while (!check)
            {
                check = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i + 1 < arr.Length)
                    {
                        if (sortDirection == EnumSortDirection.Asc ? arr[i] > arr[i + 1] : arr[i] < arr[i + 1])
                        {
                            swap = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = swap;
                            check = false;
                        }
                    }
                }
            }
        }

        private void ExecuteSelectionFast(int?[] arr, EnumSortDirection sortDirection)
        {
            List<int?> list = arr.ToList();
            for (int i = 0; i < arr.Length; i++)
            {
                (int pos, int? val) value = _firstValueHelper.Execute(list.ToArray(), sortDirection);
                arr[i] = value.val;
                list.RemoveAt(value.pos);
            }
        }

        #endregion

        #region Selection sort methods with return value.

        public T[] GetExecuteSelection<T>(T[] data, EnumSortDirection sortDirection, EnumSpeed speed = EnumSpeed.Fast)
        {
            if (speed == EnumSpeed.Slow || speed == EnumSpeed.Middle)
                return GetExecuteSelectionMiddle(data, sortDirection);
            return GetExecuteSelectionFast(data, sortDirection);
        }

        private T[] GetExecuteSelectionMiddle<T>(T[] data, EnumSortDirection sortDirection)
        {
            T[] result = _array.Copy(data);
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
                        //if (sortDirection == EnumSortDirection.Asc ? result[i] > result[i + 1] : result[i] < result[i + 1])
                        if (sortDirection == EnumSortDirection.Asc
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

        private T[] GetExecuteSelectionFast<T>(T[] data, EnumSortDirection sortDirection)
        {
            T[] result = _array.Copy(data);
            List<T> list = result.ToList();
            for (int i = 0; i < result.Length; i++)
            {
                (int pos, T val) value = _firstValueHelper.Execute(list.ToArray(), sortDirection);
                result[i] = value.val;
                list.RemoveAt(value.pos);
            }
            return result;
        }

        #endregion

        #region Quick sort methods with return value.

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <param name="speed"></param>
        /// <param name="useSwitchPivot"></param>
        /// <returns></returns>
        public IEnumerable<int?> GetExecuteQuick(int?[] arr, EnumSortDirection sortDirection, EnumSpeed speed = EnumSpeed.Fast,
            bool useSwitchPivot = false)
        {
            if (speed == EnumSpeed.Slow)
                return GetExecuteQuickRecursiveSlow(arr.ToList(), sortDirection);
            return useSwitchPivot
                ? GetExecuteQuickRecursiveFastWithSwitchPivot(arr, sortDirection)
                : GetExecuteQuickRecursiveFast(arr, sortDirection);
        }

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        public IEnumerable<int?> GetExecuteQuick(IEnumerable<int?> list, EnumSortDirection sortDirection = EnumSortDirection.Asc)
        {
            return GetExecuteQuickRecursiveSlow(list, sortDirection);
        }

        /// <summary>
        /// Slow execute method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private IEnumerable<int?> GetExecuteQuickRecursiveSlow(IEnumerable<int?> list, EnumSortDirection sortDirection)
        {
            if (list.Count() <= 1) { return list; }
            int? pivot = list.First();
            IEnumerable<int?> less;
            IEnumerable<int?> greater;

            if (sortDirection == EnumSortDirection.Asc)
            {
                less = list.Skip(1).Where(i => i <= pivot);
                greater = list.Skip(1).Where(i => i > pivot);
            }
            else
            {
                less = list.Skip(1).Where(i => i > pivot);
                greater = list.Skip(1).Where(i => i <= pivot);
            }
            return GetExecuteQuickRecursiveSlow(less, sortDirection).
                Union(new List<int?> { pivot }).
                Union(GetExecuteQuickRecursiveSlow(greater, sortDirection));
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private int?[] GetExecuteQuickRecursiveFast(int?[] arr, EnumSortDirection sortDirection)
        {
            if (arr.Length <= 1) { return arr; }
            int? pivot = arr.First();
            // Use List for fast write.
            List<int?> less = new();
            List<int?> greater = new();
            //foreach (var item in arr.ToList().Skip(1))
            foreach (int? item in _array.Sub(arr, 1, arr.Length - 1))
            {
                if (sortDirection == EnumSortDirection.Asc)
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
            return GetExecuteQuickRecursiveFast(less.ToArray(), sortDirection).
                Union(new int?[] { pivot }).
                Union(GetExecuteQuickRecursiveFast(greater.ToArray(), sortDirection)).ToArray();
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private int?[] GetExecuteQuickRecursiveFastWithSwitchPivot(int?[] arr, EnumSortDirection sortDirection)
        {
            if (arr.Length <= 1) { return arr; }
            int? pivot = arr.First();
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
            foreach (int? item in _array.Sub(arr, 1, arr.Length - 1))
            {
                if (sortDirection == EnumSortDirection.Asc)
                    if (item <= arr[pos - 1]) break;
                    else if (item > arr[pos - 1]) break;
                pos++;
            }
            pivot = arr[pos];
            // Use List for fast write.
            List<int?> less = new();
            List<int?> greater = new();

            List<int?> list = arr.ToList();
            list.RemoveAt(pos);
            //foreach (var item in list)
            foreach (int? item in list.ToArray())
            {
                if (sortDirection == EnumSortDirection.Asc)
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
            return GetExecuteQuickRecursiveFastWithSwitchPivot(less.ToArray(), sortDirection).
                Union(new int?[] { pivot }).
                Union(GetExecuteQuickRecursiveFastWithSwitchPivot(greater.ToArray(), sortDirection)).ToArray();
        }

        #endregion

        #region

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <param name="speed"></param>
        /// <param name="useSwitchPivot"></param>
        /// <returns></returns>
        public IEnumerable<string> GetExecuteQuick(string[] arr, EnumSortDirection sortDirection, EnumSpeed speed = EnumSpeed.Fast,
            bool useSwitchPivot = false)
        {
            if (speed == EnumSpeed.Slow)
                return GetExecuteQuickRecursiveSlow(arr.ToList(), sortDirection);
            return useSwitchPivot
                ? GetExecuteQuickRecursiveFastWithSwitchPivot(arr, sortDirection)
                : GetExecuteQuickRecursiveFast(arr, sortDirection);
        }

        /// <summary>
        /// Slow execute method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private IEnumerable<string> GetExecuteQuickRecursiveSlow(IEnumerable<string> list, EnumSortDirection sortDirection)
        {
            if (list.Count() <= 1) { return list; }
            string pivot = list.First();
            IEnumerable<string> less;
            IEnumerable<string> greater;

            if (sortDirection == EnumSortDirection.Asc)
            {
                less = list.Skip(1).Where(i => i.CompareTo(pivot) <= 0); // less = list.Skip(1).Where(i => i <= pivot);
                greater = list.Skip(1).Where(i => i.CompareTo(pivot) > 0); // greater = list.Skip(1).Where(i => i > pivot);
            }
            else
            {
                less = list.Skip(1).Where(i => i.CompareTo(pivot) > 0); // less = list.Skip(1).Where(i => i > pivot);
                greater = list.Skip(1).Where(i => i.CompareTo(pivot) <= 0); // greater = list.Skip(1).Where(i => i <= pivot);
            }
            return GetExecuteQuickRecursiveSlow(less, sortDirection).
                Union(new List<string> { pivot }).
                Union(GetExecuteQuickRecursiveSlow(greater, sortDirection));
        }
        
        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private string[] GetExecuteQuickRecursiveFast(string[] arr, EnumSortDirection sortDirection)
        {
            if (arr.Length <= 1) { return arr; }
            string pivot = arr.First();
            // Use List for fast write.
            List<string> less = new();
            List<string> greater = new();
            //foreach (var item in arr.ToList().Skip(1))
            foreach (string item in _array.Sub(arr, 1, arr.Length - 1))
            {
                if (sortDirection == EnumSortDirection.Asc)
                    if (item.CompareTo(pivot) <= 0) // if (item <= pivot)
                        less.Add(item);
                    else
                        greater.Add(item);
                else
                    if (item.CompareTo(pivot) > 0) // if (item > pivot)
                    less.Add(item);
                else
                    greater.Add(item);
            }
            return GetExecuteQuickRecursiveFast(less.ToArray(), sortDirection).
                Union(new string[] { pivot }).
                Union(GetExecuteQuickRecursiveFast(greater.ToArray(), sortDirection)).ToArray();
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private string[] GetExecuteQuickRecursiveFastWithSwitchPivot(string[] arr, EnumSortDirection sortDirection)
        {
            if (arr.Length <= 1) { return arr; }
            string pivot = arr.First();
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
            foreach (string item in _array.Sub(arr, 1, arr.Length - 1))
            {
                if (sortDirection == EnumSortDirection.Asc)
                    if (item.CompareTo(arr[pos - 1]) <= 0) break; // if (item <= arr[pos - 1]) break;
                    else if (item.CompareTo(arr[pos - 1]) > 0) break; // else if (item > arr[pos - 1]) break;
                pos++;
            }
            pivot = arr[pos];
            // Use List for fast write.
            List<string> less = new();
            List<string> greater = new();

            List<string> list = arr.ToList();
            list.RemoveAt(pos);
            //foreach (var item in list)
            foreach (string item in list.ToArray())
            {
                if (sortDirection == EnumSortDirection.Asc)
                    if (item.CompareTo(pivot) <= 0) // if (item <= pivot)
                        less.Add(item);
                    else
                        greater.Add(item);
                else
                    if (item.CompareTo(pivot) > 0) // if (item > pivot)
                        less.Add(item);
                else
                    greater.Add(item);
            }
            return GetExecuteQuickRecursiveFastWithSwitchPivot(less.ToArray(), sortDirection).
                Union(new string[] { pivot }).
                Union(GetExecuteQuickRecursiveFastWithSwitchPivot(greater.ToArray(), sortDirection)).ToArray();
        }

        #endregion
    }
}
