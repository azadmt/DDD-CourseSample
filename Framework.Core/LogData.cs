using System;

namespace Framework.Core
{
    public class LogData
    {
        public LogData(string userName, string machineAddress, string message, string data, Guid traceId)
        {
            UserName = userName;
            MachineAddress = machineAddress;
            Data = data;
            Message = message;
            TraceId = traceId;
            Created = DateTime.Now;
        }
        public Guid TraceId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; private set; }
        public string MachineAddress { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
