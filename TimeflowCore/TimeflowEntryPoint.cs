using System;
using System.IO;

namespace TimeflowCore
{
    static class TimeflowEntryPoint
    {
        private static TimeflowTracker _timeflowTracker;
        static void Main(string[] args)
        {
            if (args == null || args.Length != 1)
            {
                return;
            }

            if (!Directory.Exists(args[0]))
            {
                return;
            }

            var requestPath = args[0];
            _timeflowTracker = new TimeflowTracker(requestPath);
            while (true)
            {
                
            }
        }
    }
}