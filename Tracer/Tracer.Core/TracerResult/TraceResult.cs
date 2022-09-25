namespace Tracer.Core.TracerResult
{
    public class TraceResult
    {
        public IReadOnlyList<TraceThread> Threads { get; }
        
        public TraceResult(IReadOnlyList<TraceThread> threads)
        {
            Threads = threads;
        }
    }
}
