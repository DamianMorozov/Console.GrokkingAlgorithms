// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class SummaryHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SummaryHelper> _instance = new Lazy<SummaryHelper>(() => new SummaryHelper());
        public static SummaryHelper Instance { get { return _instance.Value; } }
        private SummaryHelper()
        {
            //
        }

        #endregion

        public int ExecuteForeach(int?[] arr)
        {
            var result = 0;
            foreach (var item in arr)
                result += item == null ? 0 : (int)item;
            return result;
        }

        public int ExecuteForeach(IEnumerable<int?> list)
        {
            var result = 0;
            foreach (var item in list)
                result += item == null ? 0 : (int)item;
            return result;
        }

        public int ExecuteRecursive(int?[] arr)
        {
            if (arr.Length == 0)
                return 0;
            var value = arr[0] != null ? (int)arr[0] : 0;
            var list = arr.ToList();
            list.RemoveAt(0);
            return value + ExecuteRecursive(list.ToArray());
        }

        public int ExecuteRecursive(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            return (list.Take(1).First() == null ? 0 : (int)list.Take(1).First()) + ExecuteRecursive(list.Skip(1));
        }
    }
}
