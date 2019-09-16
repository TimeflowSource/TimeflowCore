using System;
using System.IO;
using System.Linq;

namespace TimeflowCore
{
    public class Initializer
    {
        public static void CreateTimeflowRepository(string projectDirectoryPath)
        {
            CreateTimeflowHiddenDirectory(projectDirectoryPath);
            CreateTimeflowProjectSnapshotDirectories(projectDirectoryPath);
        }

        public static bool DoesTimeflowRepositoryExists(string projectDirectoryPath)
        {
            var completeTimeflowPath = projectDirectoryPath + "/.timeflow";
            return Directory.Exists(completeTimeflowPath);
        }

        private static void CreateTimeflowHiddenDirectory(string projectDirectoryPath)
        {
            var completeTimeflowPath = projectDirectoryPath + "/.timeflow";
            if (!Directory.Exists(completeTimeflowPath))
            {
                Console.WriteLine($"Timeflow repository successfully created at: {completeTimeflowPath}");
                Directory.CreateDirectory(completeTimeflowPath); 
                return;
            }
            Console.WriteLine("Timeflow repository has been already created.");
        }

        private static void CreateTimeflowProjectSnapshotDirectories(string projectDirectoryPath)
        {
            GreedyDirectorySearch(projectDirectoryPath);
        }

        private static void GreedyDirectorySearch(string currentDirectory)
        {
            if (!Directory.EnumerateDirectories(currentDirectory).Any())
            {
                return;
            }
            foreach (var directory in Directory.EnumerateDirectories(currentDirectory))
            {
                Console.WriteLine(directory);
                GreedyDirectorySearch(directory);
            }
        }
    }
}