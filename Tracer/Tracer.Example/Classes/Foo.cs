using Tracer.Core;

namespace Tracer.Example.Classes
{
    public class Foo
    {
        private readonly Bar _bar;
        private readonly ITracer _tracer;

        public Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(200);
            _bar.InnerMethod();
            Thread.Sleep(200);
            _tracer.StopTrace();
        }

    }
}
