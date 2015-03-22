using System.Diagnostics;

namespace Infrastrusture.Logging
{
    public interface ILogger
    {
        void Log(string message);
    }
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Debug.Write(message);
        }
    }
}
