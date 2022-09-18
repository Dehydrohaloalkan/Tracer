namespace Tracer.Core
{
    public class TraceThread
    {
        public TraceThread(int threadId, TimeSpan time, IReadOnlyList<TraceMethod> methods)
        {
            ThreadId = threadId;
            Time = time;
            Methods = methods;
        }

        public int ThreadId { get; init; }
        public TimeSpan Time { get; init; }
        public IReadOnlyList<TraceMethod> Methods { get;}
    }
}
