// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    public class AppHelper
    {
        #region Design pattern "Lazy Singleton"

        private static AppHelper _instance;
        public static AppHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

        #endregion

        #region Constructor and destructor

        public AppHelper()
        {
            // Type code here.
        }

        #endregion

        #region Public and private fields and properties

        public ArrayHelper ArrayHelp { get; private set; } = ArrayHelper.Instance;
        public BinarySearchHelper BinarySearchHelp { get; private set; } = BinarySearchHelper.Instance;
        public CountHelper CountHelp { get; private set; } = CountHelper.Instance;
        public FileHelper FileHelp { get; private set; } = FileHelper.Instance;
        public FirstValueHelper FirstValueHelp { get; private set; } = FirstValueHelper.Instance;
        public int FileRowsBlock { get; set; } = 1_024;
        public int MemoryBytesLimit { get; set; } = 500_000_000;
        public bool IsFileBlockRows { get; set; } = true;
        public RecursionHelper RecursionHelp { get; private set; } = RecursionHelper.Instance;
        public SortHelper SortHelp { get; private set; } = SortHelper.Instance;
        public SummaryHelper SummaryHelp { get; private set; } = SummaryHelper.Instance;
        public System.Globalization.CompareOptions StringCompareOptions { get; set; } = System.Globalization.CompareOptions.OrdinalIgnoreCase;
        public System.Globalization.CultureInfo StringCultureInfo { get; set; } = System.Globalization.CultureInfo.InvariantCulture;

        #endregion

        #region Public and private methods

        public void SetIsFileBlockRows()
        {
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write(@$"Use block for slicing data (press Enter for default value ({IsFileBlockRows})): ");
                string str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    break;
                }
                switch (str.ToUpper())
                {
                    case "1":
                    case "Y":
                    case "YES":
                        IsFileBlockRows = true;
                        isCorrect = true;
                        break;
                    case "0":
                    case "N":
                    case "NO":
                        IsFileBlockRows = false;
                        isCorrect = true;
                        break;
                }
            }
        }

        public void SetFileBlockSize()
        {
            if (!IsFileBlockRows)
                return;
            bool isCorrect = false;
            while (!isCorrect)
            {
                Console.Write(@$"Input block size (press Enter for default value ({FileRowsBlock})): ");
                string str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine(@$"Set default value for input block size: {FileRowsBlock}");
                    break;
                }
                if (int.TryParse(str, out int blockRows))
                {
                    FileRowsBlock = blockRows;
                    isCorrect = true;
                }
            }
        }

        #endregion
    }
}
