using System;
using System.IO;

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
                Console.WriteLine($"{completeTimeflowPath}");
                Directory.CreateDirectory(completeTimeflowPath); 
                return;
            }
            Console.WriteLine("Timeflow repository has been already created.");
        }

        private static void CreateTimeflowProjectSnapshotDirectories(string projectDirectoryPath)
        {
            var completeTimeflowPath = projectDirectoryPath + "/.timeflow";
        }
    }
}