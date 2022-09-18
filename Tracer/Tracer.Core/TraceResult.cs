namespace Tracer.Core
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
