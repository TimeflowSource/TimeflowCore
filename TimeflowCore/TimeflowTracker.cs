using System;

namespace TimeflowCore
{
    public class TimeflowTracker
    {      
        public string ProjectDirectoryPath { get; set; }

        public TimeflowTracker(string projectPath)
        {
            this.ProjectDirectoryPath = projectPath;
        }
        
        public void Init()
        {
            try
            {
                Initializer.CreateTimeLineRepository(this.ProjectDirectoryPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
}