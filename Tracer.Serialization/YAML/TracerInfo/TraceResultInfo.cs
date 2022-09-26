using Tracer.Core.TracerResult;

namespace YAML.TracerInfo
{
    public class TraceResultInfo
    {
        public List<TraceThreadInfo> Threads;

        public TraceResultInfo(TraceResult traceResult)
        {
            Threads = traceResult.Threads.Select(t => new TraceThreadInfo(t)).ToList();
        }
    }
}
