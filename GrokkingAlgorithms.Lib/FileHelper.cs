// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GrokkingAlgorithms.Lib
{
    public class FileHelper
    {
        #region Design pattern "Singleton".

        private static readonly Lazy<FileHelper> _instance = new(() => new FileHelper());
        public static FileHelper Instance => _instance.Value;

        #endregion

        #region Constructor and destructor

        public FileHelper()
        {
            // Type code here.
        }

        #endregion

        #region Public and private fields and properties

        public string MessageGetFileInput => "Input file name:  ";
        public string MessageGetFileOutput => "Output file name: ";
        public string MessageGetDirectoryInput => "Input directory name: ";
        public string MessageGetDirectoryOutput => "Output directory name: ";

        #endregion

        #region Public and private methods

        public string GetFileName(string message, bool isCheckExists)
        {
            string result = string.Empty;
            while (!File.Exists(result))
            {
                Console.Write(message);
                result = Console.ReadLine();
                if (!isCheckExists)
                    break;
            }
            return result;
        }

        public string GetDirectoryName(string message)
        {
            string result = string.Empty;
            while (!Directory.Exists(result))
            {
                Console.Write(message);
                result = Console.ReadLine();
            }
            return result;
        }

        public string GetOutFileName(string fileName, string addName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;
            string result = Path.Combine(Path.GetDirectoryName(fileName), 
                $"{Path.GetFileNameWithoutExtension(fileName)}{addName}{Path.GetExtension(fileName)}");
            return result;
        }

        public StringBuilder GetFileContentAsStringBuilder(string fileName)
        {
            StringBuilder content = new();
            using StreamReader streamReader = File.OpenText(fileName);
            do
            {
                content.Append(streamReader.ReadLine());
            }
            while (!streamReader.EndOfStream);
            streamReader.Close();
            streamReader.Dispose();
            return content;
        }

        public string GetFileContent(string fileName)
        {
            string content = string.Empty;
            using StreamReader streamReader = File.OpenText(fileName);
            content = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader.Dispose();
            return content;
        }

        public ulong GetFileRowsCount(string fileName)
        {
            using StreamReader streamReader = File.OpenText(fileName);
            ulong result = 0;
            do
            {
                streamReader.ReadLine();
                result++;
            } while (!streamReader.EndOfStream);
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        public string[] GetFileContentBlock(string fileName, ulong startPosition, ulong blockSize)
        {
            string[] content = new string[blockSize];
            using Stream stream = File.Open(fileName, FileMode.Open);
            using StreamReader streamReader = new(stream);
            // Skip data.
            ulong count = 0;
            while (count < startPosition)
            {
                streamReader.ReadLine();
                count++;
            }
            // Read block of data.
            count = 0;
            while (count < blockSize)
            {
                content[count] = streamReader.ReadLine();
                count++;
            }
            streamReader.Close();
            streamReader.Dispose();
            return content;
        }

        public void SetFileContent(string fileOut, IEnumerable<string> content, bool isRewriteFile, bool isSkipEmpty) => 
            SetFileContent(fileOut, content.ToArray(), isRewriteFile, isSkipEmpty);

        public void SetFileContent(string fileOut, string[] content, bool isRewriteFile, bool isSkipEmpty)
        {
            StreamWriter streamWriter;
            if (isRewriteFile && File.Exists(fileOut))
            {
                File.Delete(fileOut);
                streamWriter = File.CreateText(fileOut);
            }
            else
            {
                streamWriter = File.AppendText(fileOut);
            }
            foreach (string line in content)
            {
                if (!isSkipEmpty || !string.IsNullOrEmpty(line))
                    streamWriter.WriteLine(line);
            }
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public void SetFileContentRemoveEmptyRows(string fileName)
        {
            string content = GetFileContent(fileName);
            string fileTmp = fileName + ".tmp";
            using StreamWriter streamWriter = File.CreateText(fileTmp);
            foreach (string line in content.Split(Environment.NewLine))
            {
                if (!string.IsNullOrEmpty(line))
                    streamWriter.WriteLine(line);
            }
            streamWriter.Close();
            streamWriter.Dispose();
            
            File.Delete(fileName);
            File.Move(fileTmp, fileName);
        }

        public static bool IsFileSorted(string fileName, EnumSortDirect sortDirect)
        {
            bool result = true;
            using StreamReader streamReader = File.OpenText(fileName);
            string line1 = string.Empty;
            string line2 = string.Empty;
            ulong row = 0;
            do
            {
                line2 = streamReader.ReadLine();
                switch (sortDirect)
                {
                    case EnumSortDirect.Asc:
                        if (string.Compare(line1, line2, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) > 0)
                        {
                            //Console.WriteLine($"'{line1}' < '{line2}' at row {row}");
                            result = false;
                            break;
                        }
                        break;
                    case EnumSortDirect.Desc:
                        if (string.Compare(line1, line2, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) < 0)
                        {
                            //Console.WriteLine($"'{line1}' > '{line2}' at row {row}");
                            result = false;
                            break;
                        }
                        break;
                }
                line1 = line2;
                row++;
            } while (result && !streamReader.EndOfStream);
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        #endregion
    }
}
