using System.Xml.Serialization;
using Tracer.Core.TracerResult;

namespace XML.TracerInfo
{
    public class TraceResultInfo
    {
        [XmlElement("threads")]
        public List<TraceThreadInfo> Threads;

        public TraceResultInfo()
        {
            Threads = new List<TraceThreadInfo>();
        }

        public TraceResultInfo(TraceResult traceResult)
        {
            Threads = traceResult.Threads.Select(t => new TraceThreadInfo(t)).ToList();
        }
    }
}
