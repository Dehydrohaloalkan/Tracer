using System.Diagnostics;

namespace Tracer.Core.TracerInfo
{
    internal class MethodInfo
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public List<MethodInfo> Methods { get; set; }

        public MethodInfo()
        {
            Name = String.Empty;
            ClassName = String.Empty;
            Stopwatch = new Stopwatch();
            Methods = new List<MethodInfo>();
        }
    }
}
