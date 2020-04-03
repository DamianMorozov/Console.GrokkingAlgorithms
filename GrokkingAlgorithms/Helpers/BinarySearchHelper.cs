// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class BinarySearchHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<BinarySearchHelper> _instance = new Lazy<BinarySearchHelper>(() => new BinarySearchHelper());
        public static BinarySearchHelper Instance => _instance.Value;
        private BinarySearchHelper() { }

        #endregion

        public (int? pos, int count) Execute(int?[] arr, int item, EnumSort enumSort)
        {
            var count = 0;
            if (enumSort == EnumSort.Asc)
            {
                var start = 0;
                var end = arr.Count() - 1;
                while (start <= end)
                {
                    count++;
                    var mid = (start + end) / 2;
                    var guess = arr[mid];
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
            }
            else if (enumSort == EnumSort.Desc)
            {
                var end = 0;
                var start = arr.Count() - 1;
                while (start >= end)
                {
                    count++;
                    var mid = (start + end) / 2;
                    var guess = arr[mid];
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid + 1;
                    else
                        start = mid - 1;
                }
            }
            return (null, count);
        }

        public (int? pos, int count) Execute(IEnumerable<int?> list, int item, EnumSort enumSort)
        {
            var count = 0;
            if (enumSort == EnumSort.Asc)
            {
                var start = 0;
                var end = list.Count() - 1;
                while (start <= end)
                {
                    count++;
                    var mid = (start + end) / 2;
                    var guess = list.ElementAt(mid);
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
            }
            else if (enumSort == EnumSort.Desc)
            {
                var end = 0;
                var start = list.Count() - 1;
                while (start >= end)
                {
                    count++;
                    var mid = (start + end) / 2;
                    var guess = list.ElementAt(mid);
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid + 1;
                    else
                        start = mid - 1;
                }
            }
            return (null, count);
        }
    }
}
