using System.Xml.Serialization;
using Tracer.Core.TracerResult;

namespace XML.TracerInfo
{
    public class TraceThreadInfo
    {
        [XmlAttribute("id")]
        public int Id;

        [XmlAttribute("time")]
        public string Time;

        [XmlElement("methods")]
        public List<TraceMethodInfo> Methods;

        public TraceThreadInfo()
        {
            Id = 0;
            Time = String.Empty;
            Methods = new List<TraceMethodInfo>();
        }

        public TraceThreadInfo(TraceThread traceThread)
        {
            Id = traceThread.ThreadId;
            Time = $"{traceThread.Time} ms";
            Methods = traceThread.Methods.Select(m => new TraceMethodInfo(m)).ToList();
        }
    }
}
