using System;
using System.IO;

namespace TimeflowCore
{
    public class TimeflowTracker : FileSystemWatcher
    {
        public string ProjectDirectoryPath { get; set; }
        public FileSystemWatcher Watcher { get; set; }

        public TimeflowTracker(string projectPath)
        {
            this.ProjectDirectoryPath = projectPath;
            this.Watcher = new FileSystemWatcher(projectPath);
            try
            {
                Initializer.CreateTimeflowRepository(this.ProjectDirectoryPath);
                this.Watcher.NotifyFilter =  NotifyFilters.LastWrite
                                            | NotifyFilters.FileName
                                            | NotifyFilters.DirectoryName;
                this.Watcher.IncludeSubdirectories = true;
                this.Watcher.Changed += _OnChanged;
                this.Watcher.Created += _OnCreated;
                this.Watcher.Deleted += _OnDeleted;
                this.Watcher.Renamed += _OnRenamed;
                this.Watcher.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void _OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private void _OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private void _OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }

        private void _OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }
    }
}