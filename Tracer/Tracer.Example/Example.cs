using Tracer.Example.Classes;

var tracer = new Tracer.Core.Tracer();

var foo = new Foo(tracer);
var bar = new Bar(tracer);

var thread1 = new Thread(() =>
{
    foo.MyMethod();
});
thread1.Start();

var thread2 = new Thread(() =>
{
    bar.InnerMethod();
});
thread2.Start();

thread1.Join();
thread2.Join();

var traceResult = tracer.GetTraceResult();
