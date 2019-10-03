using System;

namespace GrokkingAlgorithms.Helpers
{
    public sealed class RecursionHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<RecursionHelper> _instance = new Lazy<RecursionHelper>(() => new RecursionHelper());
        public static RecursionHelper Instance { get { return _instance.Value; } }
        private RecursionHelper()
        {
            //
        }

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