// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Binary search helper.
    /// </summary>
    public sealed class BinarySearchHelper
    {
        #region Design pattern "Lazy Singleton"

        private static BinarySearchHelper _instance;
        public static BinarySearchHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Public and private methods

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="item"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        public (int? pos, int count) Execute(int?[] arr, int item, EnumSortDirect sortDirect)
        {
            int count = 0;
            if (sortDirect == EnumSortDirect.Asc)
            {
                int start = 0;
                int end = arr.Length - 1;
                while (start <= end)
                {
                    count++;
                    int mid = (start + end) / 2;
                    int? guess = arr[mid];
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
            }
            else if (sortDirect == EnumSortDirect.Desc)
            {
                int end = 0;
                int start = arr.Length - 1;
                while (start >= end)
                {
                    count++;
                    int mid = (start + end) / 2;
                    int? guess = arr[mid];
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid + 1;
                    else
                        start = mid - 1;
                }
            }
            return (null, count);
        }

        /// <summary>
        /// Execute method.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        public (int? pos, int count) Execute(IEnumerable<int?> list, int item, EnumSortDirect sortDirect)
        {
            int count = 0;
            if (sortDirect == EnumSortDirect.Asc)
            {
                int start = 0;
                int end = list.Count() - 1;
                while (start <= end)
                {
                    count++;
                    int mid = (start + end) / 2;
                    int? guess = list.ElementAt(mid);
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
            }
            else if (sortDirect == EnumSortDirect.Desc)
            {
                int end = 0;
                int start = list.Count() - 1;
                while (start >= end)
                {
                    count++;
                    int mid = (start + end) / 2;
                    int? guess = list.ElementAt(mid);
                    if (guess == item) return (mid, count);
                    if (guess > item)
                        end = mid + 1;
                    else
                        start = mid - 1;
                }
            }
            return (null, count);
        }

        #endregion
    }
}
