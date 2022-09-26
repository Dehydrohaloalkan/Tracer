using System.Xml.Serialization;
using Tracer.Core.TracerResult;
using Tracer.Serialization.Abstraction;
using XML.TracerInfo;

namespace XML
{
    public class TraceResultXmlSerializer : ITraceResultSerializer
    {
        public string Format => "Xml";
     
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var traceResultInfo = new TraceResultInfo(traceResult);
            XmlSerializer serializer = new XmlSerializer(typeof(TraceResultInfo));
            serializer.Serialize(to, traceResultInfo);
        }
    }
}