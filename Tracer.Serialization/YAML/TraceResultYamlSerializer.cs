using Tracer.Serialization.Abstraction;
using Tracer.Core.TracerResult;
using YAML.TracerInfo;
using YamlDotNet.Serialization;

namespace YAML
{
    public class TraceResultYamlSerializer : ITraceResultSerializer
    {
        public string Format => "Yaml";
     
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var traceResultInfo = new TraceResultInfo(traceResult);
            var serializer = new Serializer();

            using var streamWriter = new StreamWriter(to);
            serializer.Serialize(streamWriter, traceResultInfo);
            
        }
    }
}