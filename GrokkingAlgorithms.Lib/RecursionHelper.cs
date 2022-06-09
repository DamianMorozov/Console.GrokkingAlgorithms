// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    /// <summary>
    /// Recursion helper.
    /// </summary>
    public sealed class RecursionHelper
    {
        #region Design pattern "Lazy Singleton"

        private static RecursionHelper _instance;
        public static RecursionHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Public and private methods

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

        #endregion
    }
}