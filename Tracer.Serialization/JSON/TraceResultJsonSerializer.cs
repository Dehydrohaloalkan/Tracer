using System.Text.Json;
using JSON.TracerInfo;
using Tracer.Core.TracerResult;
using Tracer.Serialization.Abstraction;

namespace JSON
{
    public class TraceResultJsonSerializer : ITraceResultSerializer
    {
        public string Format => "Json";

        public void Serialize(TraceResult traceResult, Stream to)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            var traceResultInfo = new TraceResultInfo(traceResult);
            JsonSerializer.Serialize(to, traceResultInfo, options);
        }

    }
}