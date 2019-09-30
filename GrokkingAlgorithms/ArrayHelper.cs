// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace GrokkingAlgorithms
{
    public sealed class ArrayHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<ArrayHelper> _instance = new Lazy<ArrayHelper>(() => new ArrayHelper());
        public static ArrayHelper Instance { get { return _instance.Value; } }
        private ArrayHelper()
        {
            //
        }

        #endregion

        public int?[] GetSortArray(int startValue, int endValue, EnumWriteLine writeLine = EnumWriteLine.False)
        {
            var arr = new int?[endValue - startValue + 1];
            var i = 0;
            for (var j = startValue; j <= endValue; j++)
            {
                arr[i] = j;
                i++;
            }
            if (writeLine == EnumWriteLine.True)
                Console.WriteLine($"Source array {string.Join(" ; ", arr)}.");
            return arr;
        }

    }
}
