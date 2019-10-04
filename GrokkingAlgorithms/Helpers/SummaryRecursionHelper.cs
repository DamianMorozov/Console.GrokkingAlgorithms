using System;
using System.Collections.Generic;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class SummaryRecursionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SummaryRecursionHelper> _instance = new Lazy<SummaryRecursionHelper>(() => new SummaryRecursionHelper());
        public static SummaryRecursionHelper Instance { get { return _instance.Value; } }
        private SummaryRecursionHelper()
        {
            //
        }

        #endregion

        public int Execute(int?[] arr)
        {
            if (arr.Length == 0)
                return 0;
            var value = arr[0] != null ? (int)arr[0] : 0;
            var list = arr.ToList();
            list.RemoveAt(0);
            return value + Execute(list.ToArray());
        }

        public int Execute(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            return (list.Take(1).First() == null ? 0 : (int)list.Take(1).First()) + Execute(list.Skip(1));
        }
    }
}
