// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    /// <summary>
    /// Sort helper.
    /// </summary>
    public sealed class SortHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SortHelper> _instance = new Lazy<SortHelper>(() => new SortHelper());
        public static SortHelper Instance => _instance.Value;
        private SortHelper() { }

        #endregion

        private readonly ArrayHelper _array = ArrayHelper.Instance;
        private readonly FirstValueHelper _firstValueHelper = FirstValueHelper.Instance;

        /// <summary>
        /// Execute selection method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <param name="speed"></param>
        public void ExecuteSelection(int?[] arr, EnumSortDirection sortDirection, EnumSpeed speed = EnumSpeed.Fast)
        {
            if (speed == EnumSpeed.Slow)
                SelectionExecuteSlow(arr, sortDirection);
            else if (speed == EnumSpeed.Middle)
                SelectionExecuteMiddle(arr, sortDirection);
            else
                SelectionExecuteFast(arr, sortDirection);
        }

        #region Selection method.

        private void SelectionExecuteSlow(int?[] arr, EnumSortDirection sortDirection)
        {
            bool check = false;
            while (!check)
            {
                check = true;
                for (var i = 0; i < arr.Length; i++)
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

        private void SelectionExecuteMiddle(int?[] arr, EnumSortDirection sortDirection)
        {
            bool check = false;
            int? swap;
            while (!check)
            {
                check = true;
                for (var i = 0; i < arr.Length; i++)
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

        private void SelectionExecuteFast(int?[] arr, EnumSortDirection sortDirection)
        {
            var list = arr.ToList();
            for (var i = 0; i < arr.Length; i++)
            {
                var value = _firstValueHelper.Execute(list.ToArray(), sortDirection);
                arr[i] = value.val;
                list.RemoveAt(value.pos);
            }
        }

        #endregion

        #region Quick method.

        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <param name="speed"></param>
        /// <param name="useSwitchPivot"></param>
        /// <returns></returns>
        public IEnumerable<int?> ExecuteQuick(int?[] arr, EnumSortDirection sortDirection, EnumSpeed speed = EnumSpeed.Fast,
            bool useSwitchPivot = false)
        {
            if (speed == EnumSpeed.Slow)
                return QuickExecuteRecursiveSlow(arr.ToList(), sortDirection);
            return useSwitchPivot
                ? QuickExecuteRecursiveFastWithSwitchPivot(arr, sortDirection)
                : QuickExecuteRecursiveFast(arr, sortDirection);
        }
        
        /// <summary>
        /// Quick execute method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        public IEnumerable<int?> ExecuteQuick(IEnumerable<int?> list, EnumSortDirection sortDirection = EnumSortDirection.Asc)
        {
            return QuickExecuteRecursiveSlow(list, sortDirection);
        }

        /// <summary>
        /// Slow execute method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private IEnumerable<int?> QuickExecuteRecursiveSlow(IEnumerable<int?> list, EnumSortDirection sortDirection)
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
            return QuickExecuteRecursiveSlow(less, sortDirection).
                Union(new List<int?> { pivot }).
                Union(QuickExecuteRecursiveSlow(greater, sortDirection));
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private int?[] QuickExecuteRecursiveFast(int?[] arr, EnumSortDirection sortDirection)
        {
            if (arr.Length <= 1) { return arr; }
            int? pivot = arr.First();
            // Use List for fast write.
            var less = new List<int?>();
            var greater = new List<int?>();
            //foreach (var item in arr.ToList().Skip(1))
            foreach (var item in _array.GetSubArray(arr, 1, arr.Length - 1))
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
            return QuickExecuteRecursiveFast(less.ToArray(), sortDirection).
                Union(new int?[] { pivot }).
                Union(QuickExecuteRecursiveFast(greater.ToArray(), sortDirection)).ToArray();
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        private int?[] QuickExecuteRecursiveFastWithSwitchPivot(int?[] arr, EnumSortDirection sortDirection)
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
            foreach (var item in _array.GetSubArray(arr, 1, arr.Length - 1))
            {
                if (sortDirection == EnumSortDirection.Asc)
                    if (item <= arr[pos - 1]) break;
                    else
                    if (item > arr[pos - 1]) break;
                pos++;
            }
            pivot = arr[pos];
            // Use List for fast write.
            var less = new List<int?>();
            var greater = new List<int?>();

            var list = arr.ToList();
            list.RemoveAt(pos);
            //foreach (var item in list)
            foreach (var item in list.ToArray())
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
            return QuickExecuteRecursiveFastWithSwitchPivot(less.ToArray(), sortDirection).
                Union(new int?[] { pivot }).
                Union(QuickExecuteRecursiveFastWithSwitchPivot(greater.ToArray(), sortDirection)).ToArray();
        }

        #endregion
    }
}
