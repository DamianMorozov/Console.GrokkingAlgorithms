// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace GrokkingAlgorithms.Helpers
{
    /// <summary>
    /// Array helper.
    /// </summary>
    public sealed class ArrayHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<ArrayHelper> _instance = new Lazy<ArrayHelper>(() => new ArrayHelper());
        public static ArrayHelper Instance => _instance.Value;
        private ArrayHelper() { }

        #endregion

        /// <summary>
        /// Get sorted array.
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <param name="sortDirection"></param>
        /// <returns></returns>
        public int?[] GetSortArray(int startValue, int endValue, EnumSortDirection sortDirection)
        {
            int?[] arr = null;
            var i = 0;
            if (sortDirection == EnumSortDirection.Asc)
            {
                arr = new int?[endValue - startValue + 1];
                for (var j = startValue; j <= endValue; j++)
                {
                    arr[i] = j;
                    i++;
                }
            }
            else if (sortDirection == EnumSortDirection.Desc)
            {
                arr = new int?[startValue - endValue + 1];
                for (var j = startValue; j >= endValue; j--)
                {
                    arr[i] = j;
                    i++;
                }
            }
            return arr;
        }

        /// <summary>
        /// Get random array.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int?[] GetRandomArray(int size, int maxValue)
        {
            var arr = new int?[size];
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                arr[i] = random.Next(maxValue);
            }
            return arr;
        }

        /// <summary>
        /// Get subarray.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public int?[] GetSubArray(int?[] data, int index, int length)
        {
            int?[] result = new int?[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Get copy of array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int?[] GetCopyArray(int?[] data)
        {
            return GetSubArray(data, 0, data.Length);
        }
    }
}
