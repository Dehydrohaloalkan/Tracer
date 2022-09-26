using System.Text.Json.Serialization;
using Tracer.Core.TracerResult;

namespace JSON.TracerInfo
{
    public class TraceThreadInfo
    {
        [JsonInclude, JsonPropertyName("id")]
        public int Id;

        [JsonInclude, JsonPropertyName("time")]
        public string Time;
        
        [JsonInclude, JsonPropertyName("methods")]
        public List<TraceMethodInfo> Methods;

        public TraceThreadInfo(TraceThread traceThread)
        {
            Id = traceThread.ThreadId;
            Time = $"{traceThread.Time} ms";
            Methods = traceThread.Methods.Select(m => new TraceMethodInfo(m)).ToList();
        }
    }
}
