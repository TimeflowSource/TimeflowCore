using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimeflowCore
{
    public class TimeflowDirectory
    {
        public string DirectoryName { get; set; }
        public List<string> DirectoryFiles { get; set; }
        
        //TODO
        private static readonly string[] _blockedDirectories = {".timeflow", ".idea"};
        
        public TimeflowDirectory(string directoryName)
        {
            DirectoryName = _GetLastElementFromPath(directoryName);
            DirectoryFiles = _ParseRawFilesPath(directoryName);
        }
        
        private string _GetLastElementFromPath(string path)
        {
            string[] partsOfPath = path.Split('/');
            return partsOfPath[partsOfPath.Length - 1];
        }

        private List<string> _ParseRawFilesPath(string directoryName)
        {
            List<string> resultFiles = new List<string>();
            foreach (var file in Directory.GetFileSystemEntries(directoryName))
            {
                var fileShort = _GetLastElementFromPath(file);
                if (!_blockedDirectories.Contains(fileShort))
                {
                    resultFiles.Add(fileShort);
                }
            }

            return resultFiles;
        }

        public override string ToString()
        {
            var stringResult = "";
            stringResult += DirectoryName + "\n\n";
            foreach (var directoryFile in DirectoryFiles)
            {
                stringResult += directoryFile.ToString() + "\n";
            }
            return stringResult;
        }
    }
}