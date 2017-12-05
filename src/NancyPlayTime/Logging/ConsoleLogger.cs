using System;

namespace NancyPlayTime.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
}