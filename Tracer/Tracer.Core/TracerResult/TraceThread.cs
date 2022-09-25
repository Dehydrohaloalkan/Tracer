using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Tracer.Core.TracerInfo;

namespace Tracer.Core.TracerResult
{
    public class TraceThread
    {
        public int ThreadId { get; init; }
        public double Time { get; init; }
        public IReadOnlyList<TraceMethod> Methods { get; }

        public TraceThread(int threadId, double time, IReadOnlyList<TraceMethod> methods)
        {
            ThreadId = threadId;
            Time = time;
            Methods = methods;
        }

        internal TraceThread(int threadId, ThreadInfo threadInfo)
        {
            ThreadId = threadId;
            Time = threadInfo.TopMethods.Select(i => i.Stopwatch.Elapsed.TotalMilliseconds).Sum();
            Methods = threadInfo.TopMethods.Select(m => new TraceMethod(m)).ToList();
        }
    }
}
