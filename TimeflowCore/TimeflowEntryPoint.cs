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
                Console.WriteLine("Write command |init|start|stop|exit");
                var command = Console.ReadLine();
                if (command == "init")
                    _timeflowTracker.Init();
                if (command == "start")
                    _timeflowTracker.Start();
                else if (command == "stop")
                    _timeflowTracker.Stop();
                else if (command == "exit")
                    currentState = false;
                if (!currentState)
                {
                    break;
                }
            }
        }
    }

}