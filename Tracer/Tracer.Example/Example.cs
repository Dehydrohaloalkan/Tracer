using Tracer.Example.Classes;
using Tracer.Serialization;
using Tracer.Serialization.Abstraction;

var tracer = new Tracer.Core.Tracer();
var second = new SecondClass(tracer);
var first = new FirstClass(tracer);

var thread1 = new Thread(() =>
{
    second.Sleep500WithTrace();
});
thread1.Start();

var thread2 = new Thread(() =>
{
    first.Sleep100WithTrace();
});
thread2.Start();

thread1.Join();
thread2.Join();

var traceResult = tracer.GetTraceResult();

var pluginLoader = new PluginLoader("Plugins");
var plugins = pluginLoader.GetPlugins<ITraceResultSerializer>();
SerializersManager.SerializeToFiles(plugins, traceResult, "Result");