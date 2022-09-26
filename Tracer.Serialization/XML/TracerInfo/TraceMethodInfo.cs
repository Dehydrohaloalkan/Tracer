using System.Xml.Serialization;
using Tracer.Core.TracerResult;

namespace XML.TracerInfo
{
    public class TraceMethodInfo
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("class")]
        public string ClassName;

        [XmlAttribute("time")]
        public string Time;

        [XmlElement("methods")]
        public List<TraceMethodInfo> Methods;

        public TraceMethodInfo()
        {
            Name = String.Empty;
            ClassName = String.Empty;
            Time = String.Empty;
            Methods = new List<TraceMethodInfo>();
        }

        public TraceMethodInfo(TraceMethod traceMethod)
        {
            Name = traceMethod.Name;
            ClassName = traceMethod.ClassName;
            Time = $"{traceMethod.Time.TotalMilliseconds} ms";
            Methods = traceMethod.Methods.Select(m => new TraceMethodInfo(m)).ToList();
        }
    }
}
