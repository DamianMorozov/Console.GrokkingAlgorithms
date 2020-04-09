// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    /// <summary>
    /// Quick sort helper.
    /// </summary>
    public sealed class SortQuickHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SortQuickHelper> _instance = new Lazy<SortQuickHelper>(() => new SortQuickHelper());
        public static SortQuickHelper Instance => _instance.Value;
        private SortQuickHelper() { }

        #endregion
        
        private readonly ArrayHelper _array = ArrayHelper.Instance;

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sort"></param>
        /// <param name="speed"></param>
        public IEnumerable<int?> Execute(int?[] arr, EnumSort sort, EnumSpeed speed)
        {
            if (speed == EnumSpeed.Slow)
                return ExecuteRecursiveSlow(arr.ToList(), sort);
            return ExecuteRecursiveFast(arr, sort);
        }

        /// <summary>
        /// Slow execute method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public IEnumerable<int?> ExecuteRecursiveSlow(IEnumerable<int?> list, EnumSort sort)
        {
            if (list.Count() <= 1) { return list; }
            int? pivot = list.First();
            IEnumerable<int?> less;
            IEnumerable<int?> greater;

            if (sort == EnumSort.Asc)
            {
                less = list.Skip(1).Where(i => i <= pivot);
                greater = list.Skip(1).Where(i => i > pivot);
            }
            else
            {
                less = list.Skip(1).Where(i => i > pivot);
                greater = list.Skip(1).Where(i => i <= pivot);
            }
            return ExecuteRecursiveSlow(less, sort).
                Union(new List<int?> { pivot }).
                Union(ExecuteRecursiveSlow(greater, sort));
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int?[] ExecuteRecursiveFast(int?[] arr, EnumSort sort)
        {
            if (arr.Length <= 1) { return arr; }
            int? pivot = arr.First();
            // Use List for fast write.
            var less = new List<int?>();
            var greater = new List<int?>();
            //foreach (var item in arr.ToList().Skip(1))
            foreach (var item in _array.GetSubArray(arr, 1, arr.Length - 1))
            {
                if (sort == EnumSort.Asc)
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
            return ExecuteRecursiveFast(less.ToArray(), sort).
                Union(new int?[] { pivot }).
                Union(ExecuteRecursiveFast(greater.ToArray(), sort)).ToArray();
        }

        /// <summary>
        /// Fast execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int?[] ExecuteRecursiveFastWithSwitchPivot(int?[] arr, EnumSort sort)
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
                if (sort == EnumSort.Asc)
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
                if (sort == EnumSort.Asc)
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
            return ExecuteRecursiveFastWithSwitchPivot(less.ToArray(), sort).
                Union(new int?[] { pivot }).
                Union(ExecuteRecursiveFastWithSwitchPivot(greater.ToArray(), sort)).ToArray();
        }
    }
}
