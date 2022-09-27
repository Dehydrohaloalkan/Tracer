using Tracer.Core;

namespace Tracer.Example.Classes
{
    public class SecondClass
    {
        private readonly FirstClass _firstClass;
        private readonly ITracer _tracer;

        public SecondClass(ITracer tracer)
        {
            _tracer = tracer;
            _firstClass = new FirstClass(_tracer);
        }

        public void Sleep500WithTrace()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _firstClass.Sleep100WithTrace();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }

    }
}
