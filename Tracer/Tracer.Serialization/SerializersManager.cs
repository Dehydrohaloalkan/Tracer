using Tracer.Core.TracerResult;
using Tracer.Serialization.Abstraction;

namespace Tracer.Serialization
{
    public static class SerializersManager
    {
        public static void SerializeToFiles(List<ITraceResultSerializer> serializers, TraceResult traceResult,
            string fileName)
        {
            foreach (var serializer in serializers)
            {
                using var fileStream = new FileStream( $"{fileName}.{serializer.Format}", FileMode.Create);
                serializer.Serialize(traceResult, fileStream);
            }
        }
    }
}
