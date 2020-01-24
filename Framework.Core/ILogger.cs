using System.Diagnostics;

namespace Framework.Core
{
    public interface ILogger
    {
        void Log(LogData logData);
    }

    public class Logger : ILogger
    {
        public void Log(LogData logData)
        {
            Debug.WriteLine($"------------------------------------------------------------------------------------ ");

            Debug.WriteLine($"Log Date : {logData.Created} - UserName: {logData.UserName} - Data: {logData.Data} ");

            Debug.WriteLine($"------------------------------------------------------------------------------------ ");

        }
    }
}
