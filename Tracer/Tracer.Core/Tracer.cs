using System.Collections.Concurrent;
using System.Diagnostics;
using Tracer.Core.TracerInfo;
using Tracer.Core.TracerResult;

namespace Tracer.Core
{
    public class Tracer : ITracer
    {
        private readonly ConcurrentDictionary<int, ThreadInfo> _threads = new();

        public void StartTrace()
        {
            var stackMethod = new StackTrace().GetFrame(1)!.GetMethod()!;

            MethodInfo methodInfo = new MethodInfo()
            {
                Name = stackMethod.Name,
                ClassName = stackMethod.DeclaringType != null ? stackMethod.DeclaringType.Name : string.Empty
            };

            var threadId = Thread.CurrentThread.ManagedThreadId;
            var threadInfo = _threads.GetOrAdd(threadId, _ => new ThreadInfo());

            if (threadInfo.RunningMethods.Count > 0)
            {
                var parent = threadInfo.RunningMethods.First();
                parent.Methods.Add(methodInfo);
            }
            else
            {
                threadInfo.TopMethods.Add(methodInfo);
            }

            threadInfo.RunningMethods.Push(methodInfo);
            methodInfo.Stopwatch.Start();

        }

        public void StopTrace()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            if (!_threads[threadId].RunningMethods.TryPop(out var methodInfo))
                return;
            methodInfo.Stopwatch.Stop();
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(_threads.Values.Select((t, index) => new TraceThread(index, t)).ToList());
        }
    }
}
