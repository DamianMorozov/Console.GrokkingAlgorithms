// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class ArrayHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<ArrayHelper> _instance = new Lazy<ArrayHelper>(() => new ArrayHelper());
        public static ArrayHelper Instance => _instance.Value;
        private ArrayHelper() { }

        #endregion

        public int?[] GetSortArray(int startValue, int endValue, EnumSort enumSort)
        {
            int?[] arr = null;
            var i = 0;
            if (enumSort == EnumSort.Asc)
            {
                arr = new int?[endValue - startValue + 1];
                for (var j = startValue; j <= endValue; j++)
                {
                    arr[i] = j;
                    i++;
                }
            }
            else if (enumSort == EnumSort.Desc)
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

        public int?[] GetSubArray(int?[] data, int index, int length)
        {
            int?[] result = new int?[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
