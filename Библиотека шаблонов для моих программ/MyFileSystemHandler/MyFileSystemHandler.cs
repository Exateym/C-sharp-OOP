using System.IO;
using System.Text;
using MyGenericCollections.MyArray;
using MyGenericCollections.MySet;

namespace MyProgramTemplates
{
    namespace MyFileSystemHandler
    {
        public static class MyFileSystemHandler
        {
            public static bool IsTextFileEmpty(string pathToFile)
            {
                using (StreamReader streamReader = new StreamReader(pathToFile))
                {
                    if (streamReader.Peek() == -1)
                    {
                        return true;
                    }
                    return false;
                }
            }

            public static Encoding GetEncodingOfTextFile(string pathToFile)
            {
                using (StreamReader streamReader = new StreamReader(pathToFile, Encoding.Default, true))
                {
                    if (!IsTextFileEmpty(pathToFile))
                    {
                        /* Чтение первого возможного символа из входного потока должно
                        переопределить кодировку, с которой работает объект StreamReader. */
                        streamReader.Read();
                    }
                    return streamReader.CurrentEncoding;
                }
            }

            public static MyArray<string> GetLinesFromTextFile(string pathToFile)
            {
                if (GetEncodingOfTextFile(pathToFile) != Encoding.Unicode)
                {
                    throw new DecoderFallbackException("Текстовый файл должен быть закодирован форматом UTF-16 с прямым порядком байтов!");
                }
                MyArray<string> myArray = new MyArray<string>();
                using (StreamReader streamReader = new StreamReader(pathToFile, Encoding.Unicode))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                        {
                            myArray.AddElementToEnd(line.Trim());
                        }
                    }
                }
                return myArray;
            }

            public static MySet<string> GetFullPathsToFilesFromDirectory(string directoryPath)
            {
                string fullDirectoryPath = Path.GetFullPath(directoryPath);
                string[] fileNames = Directory.GetFiles(fullDirectoryPath);
                MySet<string> mySet = new MySet<string>();
                foreach (string fileName in fileNames)
                {
                    mySet.AddElementToEnd(fileName);
                }
                return mySet;
            }

            public static MySet<string> FilterFullPathsToFilesByExtension(MySet<string> fullPathsToFiles, string extension)
            {
                MySet<string> filteredFullPathsToFiles = new MySet<string>();
                foreach (string fullPathToFile in fullPathsToFiles)
                {
                    FileInfo fileInfo = new FileInfo(fullPathToFile);
                    if (fileInfo.Extension == extension)
                    {
                        filteredFullPathsToFiles.AddElementToEnd(fullPathToFile);
                    }
                }
                return filteredFullPathsToFiles;
            }

            public static MySet<string> GetFileNamesFromFullPathsToFiles(MySet<string> fullPathsToFiles)
            {
                MySet<string> fileNames = new MySet<string>();
                foreach (string fullPathToFile in fullPathsToFiles)
                {
                    FileInfo fileInfo = new FileInfo(fullPathToFile);
                    fileNames.AddElementToEnd(fileInfo.Name);
                }
                return fileNames;
            }

            public static void WriteLinesToTextFileFromMyArray(string pathToFile, bool append, in MyArray<string> myArray)
            {
                if (!IsTextFileEmpty(pathToFile) && append && GetEncodingOfTextFile(pathToFile) != Encoding.Unicode)
                {
                    throw new DecoderFallbackException("Текстовый файл должен быть закодирован форматом UTF-16 с прямым порядком байтов!");
                }
                using (StreamWriter streamWriter = new StreamWriter(pathToFile, append, Encoding.Unicode))
                {
                    for (int index = 0; index < myArray.Length; index++)
                    {
                        foreach (char symbol in myArray[index])
                        {
                            streamWriter.Write(symbol);
                        }
                        if (index != myArray.Length - 1)
                        {
                            streamWriter.Write('\n');
                        }
                    }
                }
            }
        }
    }
}