using System.Text.Json.Serialization;
using Tracer.Core.TracerResult;

namespace JSON.TracerInfo
{
    public class TraceResultInfo
    {
        [JsonInclude, JsonPropertyName("threads")]
        public List<TraceThreadInfo> Threads;

        public TraceResultInfo(TraceResult traceResult)
        {
            Threads = traceResult.Threads.Select(t => new TraceThreadInfo(t)).ToList();
        }
    }
}
