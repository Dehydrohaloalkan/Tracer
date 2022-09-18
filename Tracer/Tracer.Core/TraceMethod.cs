using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Core
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

        public String Name { get; init; }
        public String ClassName { get; init; }
        public TimeSpan Time { get; init; }
        public IReadOnlyList<TraceMethod> Methods { get; }

    }
}
