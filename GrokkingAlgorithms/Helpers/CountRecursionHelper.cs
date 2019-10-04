using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class CountRecursionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<CountRecursionHelper> _instance = new Lazy<CountRecursionHelper>(() => new CountRecursionHelper());
        public static CountRecursionHelper Instance { get { return _instance.Value; } }
        private CountRecursionHelper()
        {
            //
        }

        #endregion

        public int Execute(int?[] arr)
        {
            if (arr.Length == 0)
                return 0;
            var list = arr.ToList();
            list.RemoveAt(0);
            return 1 + Execute(list.ToArray());
        }

        public int ExecuteForeach(int?[] arr)
        {
            var result = 0;
            for (var i = 0; i < arr.Length; i++)
                result++;
            return result;
        }

        public int Execute(IEnumerable<int?> list)
        {
            if (!list.Any())
                return 0;
            return 1 + Execute(list.Skip(1));
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
