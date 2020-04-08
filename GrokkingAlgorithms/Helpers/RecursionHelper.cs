// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace GrokkingAlgorithms.Helpers
{
    /// <summary>
    /// Recursion helper.
    /// </summary>
    public sealed class RecursionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<RecursionHelper> _instance = new Lazy<RecursionHelper>(() => new RecursionHelper());
        public static RecursionHelper Instance => _instance.Value;
        private RecursionHelper() { }

        #endregion

        /// <summary>
        /// Factorial method.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Factorial(int x)
        {
            if (x <= 1)
                return x;
            return x * Factorial(x - 1);
        }
    }
}