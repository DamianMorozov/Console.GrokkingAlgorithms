// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Array helper.
    /// </summary>
    public sealed class ArrayHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<ArrayHelper> _instance = new(() => new ArrayHelper());
        public static ArrayHelper Instance => _instance.Value;
        private ArrayHelper() { }

        #endregion

        /// <summary>
        /// Get sorted array.
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <param name="sortDirect"></param>
        /// <returns></returns>
        public int?[] SortArray(int startValue, int endValue, EnumSortDirect sortDirect)
        {
            int?[] arr = null;
            var i = 0;
            if (sortDirect == EnumSortDirect.Asc)
            {
                arr = new int?[endValue - startValue + 1];
                for (var j = startValue; j <= endValue; j++)
                {
                    arr[i] = j;
                    i++;
                }
            }
            else if (sortDirect == EnumSortDirect.Desc)
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
        public int?[] RandomArray(int size, int maxValue)
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
        public int?[] Sub(int?[] data, int index, int length)
        {
            int?[] result = new int?[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Get subarray.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public T[] Sub<T>(T[] data, int index, int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Get copy of array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int?[] Copy(int?[] data)
        {
            return Sub(data, 0, data.Length);
        }

        /// <summary>
        /// Get copy of array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public T[] Copy<T>(T[] data)
        {
            return Sub(data, 0, data.Length);
        }
    }
}
