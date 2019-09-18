using System;
using System.IO;
using System.Security.Cryptography;

namespace TimeflowCore
{
    public class TimeflowTracker : FileSystemWatcher
    {
        public string ProjectDirectoryPath { get; set; }
        public string TimeflowPath { get; set; }
        public FileSystemWatcher Watcher { get; set; }

        private static int _renamedIndex = 0;
        private static int _changedIndex = 0;
        private static int _createdIndex = 0;
        private static int _deletedIndex = 0;

        public TimeflowTracker(string projectPath)
        {
            this.ProjectDirectoryPath = projectPath;
            this.TimeflowPath = projectPath + "/.timeflow";
            this.Watcher = new FileSystemWatcher(projectPath);
            try
            {
                Initializer.CreateTimeflowRepository(this.ProjectDirectoryPath);
                this.Watcher.NotifyFilter = NotifyFilters.LastWrite
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
            try
            {
                File.Copy(e.FullPath, TimeflowPath + $"/{e.Name}-{e.ChangeType}.txt");
            }
            catch (Exception exception)
            {
            }
        }

        private void _OnDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            try
            {
                File.Copy(e.FullPath, TimeflowPath + $"/{e.Name}-{e.ChangeType}.txt");
            }
            catch (Exception exception)
            {
            }
        }

        private void _OnCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            try
            {
                File.Copy(e.FullPath, TimeflowPath + $"/{e.Name}-{e.ChangeType}.txt");
            }
            catch (Exception exception)
            {
            }
        }

        private void _OnChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
            try
            {
                File.Copy(e.FullPath, TimeflowPath + $"/{e.Name}-{e.ChangeType}.txt");
            }
            catch (Exception exception)
            {
            }
        }
    }
}