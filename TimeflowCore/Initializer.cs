using System;
using System.IO;

namespace TimeflowCore
{
    public class Initializer
    {
        public static void CreateTimeLineRepository(string projectDirectoryPath)
        {
            CreateTimeLineHiddenDirectory(projectDirectoryPath);
            CreateTimeLineProjectSnapshotDirectories(projectDirectoryPath);
        }

        public static bool DoesTimeLineRepositoryExists(string projectDirectoryPath)
        {
            var completeTimeLinePath = projectDirectoryPath + "/.timeline";
            return Directory.Exists(completeTimeLinePath);
        }

        private static void CreateTimeLineHiddenDirectory(string projectDirectoryPath)
        {
            var completeTimeLinePath = projectDirectoryPath + "/.timeline";
            if (!Directory.Exists(completeTimeLinePath))
            {
                Directory.CreateDirectory(completeTimeLinePath); 
                return;
            }
            Console.WriteLine("TimeLine repository has been already created.");
        }

        private static void CreateTimeLineProjectSnapshotDirectories(string projectDirectoryPath)
        {
            var completeTimeLinePath = projectDirectoryPath + "/.timeline";
        }
    }
}