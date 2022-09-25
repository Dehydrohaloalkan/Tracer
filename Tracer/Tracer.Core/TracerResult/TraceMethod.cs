using Tracer.Core.TracerInfo;

namespace Tracer.Core.TracerResult
{
    public class TraceMethod
    {
        public string Name { get; init; }
        public string ClassName { get; init; }
        public TimeSpan Time { get; init; }
        public IReadOnlyList<TraceMethod> Methods { get; init; }

        public TraceMethod(string name, string className, TimeSpan time, IReadOnlyList<TraceMethod> methods)
        {
            Name = name;
            ClassName = className;
            Time = time;
            Methods = methods;
        }

        internal TraceMethod(MethodInfo methodInfo)
        {
            Name = methodInfo.Name;
            ClassName = methodInfo.ClassName;
            Time = methodInfo.Stopwatch.Elapsed;
            Methods = (IReadOnlyList<TraceMethod>)methodInfo.Methods.Select(m => new TraceMethod(m));
        }
    }
}
