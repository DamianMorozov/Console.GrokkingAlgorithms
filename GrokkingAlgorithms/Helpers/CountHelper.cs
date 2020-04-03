// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class CountHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<CountHelper> _instance = new Lazy<CountHelper>(() => new CountHelper());
        public static CountHelper Instance => _instance.Value;
        private CountHelper() { }

        #endregion

        public int ExecuteRecursive(int?[] arr)
        {
            if (arr.Length == 0)
                return 0;
            var list = arr.ToList();
            list.RemoveAt(0);
            return 1 + ExecuteRecursive(list.ToArray());
        }

        public int ExecuteForeach(int?[] arr)
        {
            var result = 0;
            for (var i = 0; i < arr.Length; i++)
                result++;
            return result;
        }

        public int ExecuteRecursive(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            return 1 + ExecuteRecursive(list.Skip(1));
        }

        public int ExecuteForeach(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            var result = 0;
            foreach (var item in list)
                result++;
            return result;
        }
    }
}
