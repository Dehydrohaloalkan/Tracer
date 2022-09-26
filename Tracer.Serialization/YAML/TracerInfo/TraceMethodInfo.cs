using Tracer.Core.TracerResult;

namespace YAML.TracerInfo
{
    public class TraceMethodInfo
    {
        public string Name;
        public string ClassName;
        public string Time;
        public List<TraceMethodInfo> Methods;

        public TraceMethodInfo(TraceMethod traceMethod)
        {
            Name = traceMethod.Name;
            ClassName = traceMethod.ClassName;
            Time = $"{traceMethod.Time.TotalMilliseconds} ms";
            Methods = traceMethod.Methods.Select(m => new TraceMethodInfo(m)).ToList();
        }
    }
}
