using System;
using System.Collections.Generic;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class SummaryLoopHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SummaryLoopHelper> _instance = new Lazy<SummaryLoopHelper>(() => new SummaryLoopHelper());
        public static SummaryLoopHelper Instance { get { return _instance.Value; } }
        private SummaryLoopHelper()
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
