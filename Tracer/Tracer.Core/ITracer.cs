using Tracer.Core.TracerResult;

namespace Tracer.Core
{
    public interface ITracer
    {
        public void StartTrace();
        public void StopTrace();
        public TraceResult GetTraceResult();
    }
}
