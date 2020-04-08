// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    /// <summary>
    /// Sort selection helper.
    /// </summary>
    public sealed class SortSelectionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SortSelectionHelper> _instance = new Lazy<SortSelectionHelper>(() => new SortSelectionHelper());
        public static SortSelectionHelper Instance => _instance.Value;
        private SortSelectionHelper() { }

        #endregion

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sort"></param>
        /// <param name="speed"></param>
        public void Execute(int?[] arr, EnumSort sort, EnumSpeed speed = EnumSpeed.Fast)
        {
            if (speed == EnumSpeed.Slow)
                ExecuteSlow(arr, sort);
            else if (speed == EnumSpeed.Middle)
                ExecuteMiddle(arr, sort);
            else
                ExecuteFast(arr, sort);
        }

        private void ExecuteSlow(int?[] arr, EnumSort sort)
        {
            bool check = false;
            while (!check)
            {
                check = true;
                for (var i = 0; i < arr.Length; i++)
                {
                    if (i + 1 < arr.Length)
                    {
                        if (sort == EnumSort.Asc ? arr[i] > arr[i + 1] : arr[i] < arr[i + 1])
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

        private void ExecuteMiddle(int?[] arr, EnumSort sort)
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
                        if (sort == EnumSort.Asc ? arr[i] > arr[i + 1] : arr[i] < arr[i + 1])
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

        public (int pos, int? val) GetFirstValue(int?[] arr, EnumSort sort)
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
                    if (sort == EnumSort.Asc)
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

        private void ExecuteFast(int?[] arr, EnumSort sort)
        {
            var list = arr.ToList();
            for (var i = 0; i < arr.Length; i++)
            {
                var value = GetFirstValue(list.ToArray(), sort);
                arr[i] = value.val;
                list.RemoveAt(value.pos);
            }
        }
    }
}
