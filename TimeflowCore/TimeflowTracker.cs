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
            }
            catch (Exception e)
            {
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