using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimeflowCore
{
    public static class Initializer
    {
        public static string ProjectDirectoryPath { get; set; }
        private static List<TimeflowDirectory> _projectStructureCache = new List<TimeflowDirectory>();
        //TODO
        private static readonly string[] _blockedDirectories = {".timeflow", ".idea"};
        public static void CreateTimeflowRepository(string projectDirectoryPath)
        {
            ProjectDirectoryPath = projectDirectoryPath;
            CreateTimeflowHiddenDirectory();
            CreateTimeflowProjectSnapshotDirectories();
            foreach (var VARIABLE in _projectStructureCache)
            {
                Console.WriteLine(VARIABLE);                
            }

        }

        public static bool DoesTimeflowRepositoryExists()
        {
            var completeTimeflowPath = ProjectDirectoryPath + "/.timeflow";
            return Directory.Exists(completeTimeflowPath);
        }

        // TODO: Should be true|false in future
        private static void CreateTimeflowHiddenDirectory()
        {
            var completeTimeflowPath = ProjectDirectoryPath + "/.timeflow";
            if (!Directory.Exists(completeTimeflowPath))
            {
                Console.WriteLine($"Timeflow repository successfully created at: {completeTimeflowPath}");
                Directory.CreateDirectory(completeTimeflowPath); 
                return;
            }
            Console.WriteLine("Timeflow repository has been already created.");
        }

        private static void CreateTimeflowProjectSnapshotDirectories()
        {
            GreedyDirectorySearch(ProjectDirectoryPath);
        }

        private static void GreedyDirectorySearch(string currentDirectory)
        {
            if (!Directory.EnumerateDirectories(currentDirectory).Any() && _blockedDirectories.Contains(Directory.GetCurrentDirectory()))
            {
                return;
            }
            foreach (var directory in Directory.EnumerateDirectories(currentDirectory))
            {
                //TODO need to be fixed - short dirs names
                if (!_blockedDirectories.Contains(directory))
                {
                    _projectStructureCache.Add(new TimeflowDirectory(directory));
                    GreedyDirectorySearch(directory);
                }
            }
        }
    }
}