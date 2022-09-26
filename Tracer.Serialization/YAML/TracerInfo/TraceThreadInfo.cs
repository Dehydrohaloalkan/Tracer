using Tracer.Core.TracerResult;

namespace YAML.TracerInfo
{
    public class TraceThreadInfo
    {
        public int Id;
        public string Time;
        public List<TraceMethodInfo> Methods;

        public TraceThreadInfo(TraceThread traceThread)
        {
            Id = traceThread.ThreadId;
            Time = $"{traceThread.Time} ms";
            Methods = traceThread.Methods.Select(m => new TraceMethodInfo(m)).ToList();
        }
    }
}
