using System.Text.Json.Serialization;
using Tracer.Core.TracerResult;

namespace JSON.TracerInfo
{
    public class TraceMethodInfo
    {
        [JsonInclude, JsonPropertyName("name")]
        public string Name;

        [JsonInclude, JsonPropertyName("class")]
        public string ClassName;

        [JsonInclude, JsonPropertyName("time")]
        public string Time;

        [JsonInclude, JsonPropertyName("methods")]
        public List<TraceMethodInfo> Methods;

        public TraceMethodInfo(TraceMethod traceMethod)
        {
            Name = traceMethod.Name;
            ClassName = traceMethod.ClassName;
            Time = $"{traceMethod.Time.TotalMilliseconds} ms";
            Methods = traceMethod.Methods.Select(m => new TraceMethodInfo(m)).ToList();
        }
    }
}
