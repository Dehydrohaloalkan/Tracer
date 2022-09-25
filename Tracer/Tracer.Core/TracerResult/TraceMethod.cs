namespace Tracer.Core.TracerResult
{
    public class TraceMethod
    {
        public TraceMethod(string name, string className, TimeSpan time, IReadOnlyList<TraceMethod> methods)
        {
            Name = name;
            ClassName = className;
            Time = time;
            Methods = methods;
        }

        public TraceMethod()
        {
            Name = string.Empty;
            ClassName = string.Empty;
            Time = TimeSpan.Zero;
            Methods = new List<TraceMethod>();
        }

        public string Name { get; internal set; }
        public string ClassName { get; internal set; }
        public TimeSpan Time { get; internal set; }
        public IReadOnlyList<TraceMethod> Methods { get; }

    }
}
