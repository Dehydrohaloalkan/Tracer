namespace Tracer.Core.TracerResult
{
    public class TraceResult
    {
        public TraceResult(IReadOnlyList<TraceThread> threads)
        {
            Threads = threads;
        }

        public IReadOnlyList<TraceThread> Threads { get; }
    }
}
