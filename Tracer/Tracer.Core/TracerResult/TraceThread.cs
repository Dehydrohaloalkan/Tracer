using Tracer.Core.TracerResult;

namespace Tracer.Core.TraceResult
{
    public class TraceThread
    {
        public TraceThread(int threadId, TimeSpan time, IReadOnlyList<TraceMethod> methods)
        {
            ThreadId = threadId;
            Time = time;
            Methods = methods;
        }

        public int ThreadId { get; internal set; }
        public TimeSpan Time { get; internal set; }
        public IReadOnlyList<TraceMethod> Methods { get; }
    }
}
