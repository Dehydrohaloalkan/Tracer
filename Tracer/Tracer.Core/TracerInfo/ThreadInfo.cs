using System.Collections.Concurrent;

namespace Tracer.Core.TracerInfo
{
    internal class ThreadInfo
    {
        public ConcurrentStack<MethodInfo> RunningMethods { get; set; }
        public List<MethodInfo> TopMethods { get; set; }

        public ThreadInfo()
        {
            RunningMethods = new ConcurrentStack<MethodInfo>();
            TopMethods = new List<MethodInfo>();
        }
    }
}
