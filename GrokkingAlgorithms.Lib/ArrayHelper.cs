// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Array helper.
    /// </summary>
    public sealed class ArrayHelper
    {
        #region Design pattern "Lazy Singleton"

        private static ArrayHelper _instance;
        public static ArrayHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Public and private methods

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
            int i = 0;
            switch (sortDirect)
            {
                case EnumSortDirect.Asc:
                    {
                        arr = new int?[endValue - startValue + 1];
                        for (int j = startValue; j <= endValue; j++)
                        {
                            arr[i] = j;
                            i++;
                        }
                        break;
                    }
                case EnumSortDirect.Desc:
                    {
                        arr = new int?[startValue - endValue + 1];
                        for (int j = startValue; j >= endValue; j--)
                        {
                            arr[i] = j;
                            i++;
                        }
                        break;
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
            int?[] arr = new int?[size];
            Random random = new();
            for (int i = 0; i < size; i++)
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
            T[] result = new T[length];
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

        #endregion
    }
}
