using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class FirstRecursionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<FirstRecursionHelper> _instance = new Lazy<FirstRecursionHelper>(() => new FirstRecursionHelper());
        public static FirstRecursionHelper Instance { get { return _instance.Value; } }
        private FirstRecursionHelper()
        {
            //
        }

        #endregion

        public (int pos, int? val) Execute(int?[] arr, EnumSort sort)
        {
            if (arr.Length <= 0)
                return (-1, null);
            if (arr.Length == 1)
                return (0, arr[0]);
            var i = 0;
            int? value = null;
            for (var j = 0; j < arr.Length; j++)
            {
                if (value == null)
                    value = arr[j];
                else
                    if (arr[j] != null)
                {
                    if (sort == EnumSort.Asc)
                    {
                        if (value > arr[j])
                        {
                            value = arr[j];
                            i = j;
                        }
                    }
                    else
                    {
                        if (value < arr[j])
                        {
                            value = arr[j];
                            i = j;
                        }
                    }
                }
            }
            return (i, value);
        }

        public (int pos, int? val) Execute(IEnumerable<int?> list, EnumSort sort)
        {
            int i = 0, j = 0;
            int? value = null;
            foreach (var item in list)
            {
                if (value == null)
                    value = item;
                else
                    if (item != null)
                {
                    if (sort == EnumSort.Asc)
                    {
                        if (value > item)
                        {
                            value = item;
                            i = j;
                        }
                    }
                    else
                    {
                        if (value < item)
                        {
                            value = item;
                            i = j;
                        }
                    }
                }
                j++;
            }
            return (i, value);
        }

        public int? ExecuteRecursive(IEnumerable<int?> list, EnumSort sort)
        {
            if (!list.Any()) return null;
            if (list.Count() == 1) return list.First();
            if (list.Count() == 2) return sort == EnumSort.Desc
                ? list.First() > list.Skip(1).Take(1).First() ? list.First() : list.Skip(1).Take(1).First()
                : list.First() < list.Skip(1).Take(1).First() ? list.First() : list.Skip(1).Take(1).First();
            var sub_max = ExecuteRecursive(list.Skip(1), sort);
            return sort == EnumSort.Desc
                ? list.First() > sub_max ? list.First() : sub_max
                : list.First() < sub_max ? list.First() : sub_max;
        }
    }
}
