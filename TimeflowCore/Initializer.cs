using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TimeflowCore
{
    public static class Initializer
    {
        public static string ProjectDirectoryPath { get; set; }
        public static void CreateTimeflowRepository(string projectDirectoryPath)
        {
            ProjectDirectoryPath = projectDirectoryPath;
            CreateTimeflowHiddenDirectory();

        }


        private static bool CreateTimeflowHiddenDirectory()
        {
            var completeTimeflowPath = ProjectDirectoryPath + "/.timeflow";
            if (!Directory.Exists(completeTimeflowPath))
            {
                Console.WriteLine($"Timeflow repository successfully created at: {completeTimeflowPath}");
                Directory.CreateDirectory(completeTimeflowPath); 
                return true;
            }
            Console.WriteLine("Timeflow repository has been already created.");
            return false;
        }
    }
}