// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Linq;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class SortSelectionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<SortSelectionHelper> _instance = new Lazy<SortSelectionHelper>(() => new SortSelectionHelper());
        public static SortSelectionHelper Instance { get { return _instance.Value; } }
        private SortSelectionHelper()
        {
            //
        }

        #endregion

        public void Execute(int?[] arr, EnumSort sort, EnumAlgorithm algorithm, EnumWriteLine writeLine = EnumWriteLine.False)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            switch (algorithm)
            {
                case EnumAlgorithm.First:
                    Algorithm1(arr, sort);
                    break;
                case EnumAlgorithm.Second:
                    Algorithm2(arr, sort);
                    break;
                case EnumAlgorithm.Third:
                    Algorithm3(arr, sort);
                    break;
            }
            sw.Stop();
            Console.Write($"Sorting: {sort}. Algorithm: {algorithm}. Elapsed time: {sw.Elapsed}.");
            if (writeLine == EnumWriteLine.True)
                Console.WriteLine($" Sorting array: {string.Join(sort == EnumSort.Asc ? " < " : " > ", arr)}.");
            else
                Console.WriteLine($" Count items: {arr.Length:N0}.");
        }

        public static void Algorithm1(int?[] arr, EnumSort sort)
        {
            bool check = false;
            while (!check)
            {
                check = true;
                for (var i = 0; i < arr.Length; i++)
                {
                    if (i + 1 < arr.Length)
                    {
                        if (sort == EnumSort.Asc ? arr[i] > arr[i + 1] : arr[i] < arr[i + 1])
                        {
                            arr[i] = arr[i] + arr[i + 1];
                            arr[i + 1] = arr[i] - arr[i + 1];
                            arr[i] = arr[i] - arr[i + 1];
                            check = false;
                        }
                    }
                }
            }
        }

        public static void Algorithm2(int?[] arr, EnumSort sort)
        {
            bool check = false;
            int? swap;
            while (!check)
            {
                check = true;
                for (var i = 0; i < arr.Length; i++)
                {
                    if (i + 1 < arr.Length)
                    {
                        if (sort == EnumSort.Asc ? arr[i] > arr[i + 1] : arr[i] < arr[i + 1])
                        {
                            swap = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = swap;
                            check = false;
                        }
                    }
                }
            }
        }

        public (int pos, int? val) GetFirstValue(int?[] arr, EnumSort sort)
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

        public void Algorithm3(int?[] arr, EnumSort sort)
        {
            var list = arr.ToList();
            for (var i = 0; i < arr.Length; i++)
            {
                var value = GetFirstValue(list.ToArray(), sort);
                arr[i] = value.val;
                list.RemoveAt(value.pos);
            }
        }
    }
}
