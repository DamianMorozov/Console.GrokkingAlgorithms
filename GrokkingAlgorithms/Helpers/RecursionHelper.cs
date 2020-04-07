// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class RecursionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<RecursionHelper> _instance = new Lazy<RecursionHelper>(() => new RecursionHelper());
        public static RecursionHelper Instance { get { return _instance.Value; } }
        private RecursionHelper() { }

        #endregion

        public int Factorial(int x)
        {
            if (x <= 1)
                return x;
            else
                return x * Factorial(x - 1);
        }
    }
}