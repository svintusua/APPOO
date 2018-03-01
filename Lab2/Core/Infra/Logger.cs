using System;

namespace Core.Infra
{
    public class Logger : ILogger
    {
        private Logger() { }

        private static Logger _instance;
        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
