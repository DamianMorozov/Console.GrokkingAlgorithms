// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace GrokkingAlgorithms.Lib
{
    public class FileHelper
    {
        #region Design pattern "Lazy Singleton"

        private static FileHelper _instance;
        public static FileHelper Instance => LazyInitializer.EnsureInitialized(ref _instance);

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
            using Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            while (!streamReader.EndOfStream)
            {
                content.Append(streamReader.ReadLine());
            }
            streamReader.Close();
            streamReader.Dispose();
            return content;
        }

        public string GetFileContentAsString(string fileName)
        {
            using Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        public string[] GetFileContent(string[] files)
        {
            string[] result = Array.Empty<string>();
            foreach (string file in files)
            {
                string[] arr = GetFileContent(file);
                result = result.Concat(arr).ToArray();
            }
            return result;
        }

        public List<string> GetFileContentAsEnumerable(string[] files)
        {
            List<string> result = new();
            foreach (string file in files)
            {
                List<string> arr = GetFileContentAsEnumerable(file);
                result.AddRange(arr);
            }
            return result;
        }

        public string[] GetFileContent(string file)
        {
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
                return Array.Empty<string>();
            int rowsCount = GetFileRowsCount(file);
            if (rowsCount == 0)
                return Array.Empty<string>();
            string[] result = new string[rowsCount];
            using Stream stream = File.Open(file, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            int rowCurrent = 0;
            while (!streamReader.EndOfStream)
            {
                result[rowCurrent] = streamReader.ReadLine();
                rowCurrent++;
            }
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        public List<string> GetFileContentAsEnumerable(string file)
        {        
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
                return new List<string>();
            int rowsCount = GetFileRowsCount(file);
            if (rowsCount == 0)
                return new List<string>();
            List<string> result = new();
            using Stream stream = File.Open(file, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            while (!streamReader.EndOfStream)
            {
                result.Add(streamReader.ReadLine());
            }
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

public int GetFileRowsCount(string fileName)
        {
            using Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            int result = 0;
            while (!streamReader.EndOfStream)
            {
                streamReader.ReadLine();
                result++;
            }
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        public int GetFileTempCount(string fileName, int rowsBlock)
        {
            using Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            int result = 0;
            int rowsSkip = 0;
            while (!streamReader.EndOfStream)
            {
                if (result == 0)
                    result++;
                if (rowsSkip < rowsBlock)
                {
                    streamReader.ReadLine();
                    rowsSkip++;
                }
                else
                {
                    rowsSkip = 0;
                    result++;
                }
            }
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        public string[] GetFilesTemp(int count, string name, string ext)
        {
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = $"{name}.{ext}{i}";
            }
            return result;
        }

        //public string[] ReverseFiles(string[] files)
        //{
        //    int count = files.Count();
        //    if (count == 1)
        //        return files;
        //    string[] result = new string[count];
        //    if (count == 2)
        //    {
        //        result[0] = files[1];
        //        result[1] = files[0];
        //        return result;
        //    }
        //    for (int i = 0; i < count; i++)
        //    {
        //        result[count - 1 - i] = files[i];
        //    }
        //    return result;
        //}

        //public string[] RotateFiles(string[] files)
        //{
        //    int count = files.Count();
        //    if (count == 1)
        //        return files;
        //    string[] result = new string[count];
        //    if (count == 2)
        //    {
        //        result[0] = files[1];
        //        result[1] = files[0];
        //        return result;
        //    }
        //    //for (int i = 0; i < count; i++)
        //    //{
        //    //    if (i < count - 2)
        //    //    {
        //    //        result[i] = files[i + 2];
        //    //        result[i + 2] = files[i];
        //    //    }
        //    //    else if (i < count - 1)
        //    //    {
        //    //        result[i] = files[i + 1];
        //    //        result[i + 1] = files[i];
        //    //    }
        //    //    else
        //    //    {
        //    //        result[i] = files[i];
        //    //    }
        //    //}
        //    for (int i = 0; i < count; i++)
        //    {
        //        result[count - 1 - i] = files[i];
        //    }
        //    return result;
        //}

        public string[] GetFileContentBlock(string fileName, int startPosition, int blockSize)
        {
            string[] content = new string[blockSize];
            using Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            // Skip data.
            int count = 0;
            while (!streamReader.EndOfStream && count < startPosition)
            {
                streamReader.ReadLine();
                count++;
            }
            // Read block of data.
            count = 0;
            while (!streamReader.EndOfStream && count < blockSize)
            {
                content[count] = streamReader.ReadLine();
                count++;
            }
            streamReader.Close();
            streamReader.Dispose();
            return content;
        }

        public void SetFileContent(string fileOut, List<string> content, bool isRewriteFile) => 
            SetFileContent(fileOut, content.ToArray(), isRewriteFile);

        public void SetFileContent(string fileOut, string[] content, bool isRewriteFile)
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
                if (!string.IsNullOrEmpty(line))
                    streamWriter.WriteLine(line);
            }
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public void DeleteFiles(string[] files)
        {
            foreach (string file in files)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
        }

        public void SplitFiles(string fileIn, string[] filesOut, int rowsBlock)
        {
            using Stream stream = File.Open(fileIn, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            int rowFileOut = 0;
            foreach (string fileOut in filesOut)
            {
                using StreamWriter streamWriter = File.AppendText(fileOut);
                while (!streamReader.EndOfStream)
                {
                    if (rowFileOut < rowsBlock)
                        rowFileOut++;
                    else
                    {
                        rowFileOut = 0;
                        break;
                    }
                    streamWriter.WriteLine(streamReader.ReadLine());
                }
                streamWriter.Close();
                streamWriter.Dispose();
            }
            streamReader.Close();
            streamReader.Dispose();
        }

        public void SplitData(string[] content, string[] filesOut, int rowsBlock)
        {
            int rowFileIn = 0;
            foreach (string fileOut in filesOut)
            {
                using StreamWriter streamWriter = File.AppendText(fileOut);
                int rowFileOut = 0;
                while (rowFileIn < content.Length)
                {
                    if (rowFileOut < rowsBlock)
                    {
                        streamWriter.WriteLine(content[rowFileIn]);
                        rowFileIn++;
                        rowFileOut++;
                    }
                    else
                    {
                        break;
                    }
                }
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        public void MergeFiles(string[] filesIn, string fileOut)
        {
            if (File.Exists(fileOut))
                File.Delete(fileOut);
            using StreamWriter streamWriter = File.AppendText(fileOut);
            foreach (string fileIn in filesIn)
            {
                string content = GetFileContentAsString(fileIn);
                streamWriter.Write(content);
            }
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public void SetFileContentRemoveEmptyRows(string fileName)
        {
            string[] content = GetFileContent(fileName);
            string fileTmp = fileName + ".tmp";
            using StreamWriter streamWriter = File.CreateText(fileTmp);
            foreach (string line in content)
            {
                if (!string.IsNullOrEmpty(line))
                    streamWriter.WriteLine(line);
            }
            streamWriter.Close();
            streamWriter.Dispose();
            
            File.Delete(fileName);
            File.Move(fileTmp, fileName);
        }

        public bool IsFileSorted(string fileName, EnumSortDirect sortDirect)
        {
            using Stream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new(stream);
            string line1 = string.Empty;
            string line2 = string.Empty;
            int row = 0;
            bool result = true;
            while (!streamReader.EndOfStream)
            {
                line2 = streamReader.ReadLine();
                if (sortDirect == EnumSortDirect.Asc)
                {
                    if (string.Compare(line1, line2, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) > 0)
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    if (string.Compare(line1, line2, AppHelper.Instance.StringCultureInfo, AppHelper.Instance.StringCompareOptions) < 0)
                    {
                        result = false;
                        break;
                    }
                }
                line1 = line2;
                row++;
            }
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        #endregion
    }
}
