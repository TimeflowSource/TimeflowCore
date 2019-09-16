using System;

namespace TimeflowCore
{
    static class TimeflowEntryPoint
    {
        private static TimeflowTracker _timeflowTracker;
        static void Main(string[] args)
        {
            var currentState = true;
            Console.WriteLine("Enter valid path to directory: ");
            var requestPath = Console.ReadLine();
            _timeflowTracker = new TimeflowTracker(requestPath);
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "init")
                    _timeflowTracker.Init();
                if (command == "exit")
                    _timeflowTracker.Start();
                else if (command == "start")
                    _timeflowTracker.Stop();
                else if (command == "stop")
                    currentState = false;
                if (!currentState)
                {
                    break;
                }
            }
        }
    }

}