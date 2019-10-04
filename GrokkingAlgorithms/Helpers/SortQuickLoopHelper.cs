using System;
using System.Collections.Generic;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class SortQuickLoopHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SortQuickLoopHelper> _instance = new Lazy<SortQuickLoopHelper>(() => new SortQuickLoopHelper());
        public static SortQuickLoopHelper Instance { get { return _instance.Value; } }
        private SortQuickLoopHelper()
        {
            //
        }

        #endregion

        public int Execute(int?[] arr)
        {
            var result = 0;
            foreach (var item in arr)
                result += item == null ? 0 : (int)item;
            return result;
        }

        public int Execute(IEnumerable<int?> list)
        {
            var result = 0;
            foreach (var item in list)
                result += item == null ? 0 : (int)item;
            return result;
        }
    }
}
