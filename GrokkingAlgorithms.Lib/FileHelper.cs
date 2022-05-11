// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public string MessageGetFileInput => "Input file name: ";
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

        public string GetFileContent(string fileName)
        {
            using StreamReader streamReader = File.OpenText(fileName);
            string content = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader.Dispose();
            return content;
        }

        public void SetFileContent(string fileName, string content, bool isRewriteFile, bool isSkipEmpty) => 
            SetFileContent(fileName, content.Split(Environment.NewLine), isRewriteFile, isSkipEmpty);

        public void SetFileContent(string fileName, IEnumerable<string> content, bool isRewriteFile, bool isSkipEmpty) => 
            SetFileContent(fileName, content.ToArray(), isRewriteFile, isSkipEmpty);

        public void SetFileContent(string fileName, string[] content, bool isRewriteFile, bool isSkipEmpty)
        {
            if (isRewriteFile && File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using StreamWriter streamWriter = File.CreateText(fileName);
            foreach (string line in content)
            {
                if (isSkipEmpty && !string.IsNullOrEmpty(line))
                    streamWriter.WriteLine(line);
            }
            streamWriter.Close();
            streamWriter.Dispose();
        }

        #endregion
    }
}
