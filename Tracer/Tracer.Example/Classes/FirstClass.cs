using Tracer.Core;

namespace Tracer.Example.Classes
{
    public class FirstClass
    {
        private readonly ITracer _tracer;

        public FirstClass(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void Sleep100WithTrace()
        {
            _tracer.StartTrace();
            Thread.Sleep(100);
            _tracer.StopTrace();
        }

    }
}
