using System.Reflection;

namespace Tracer.Serialization
{
    public class PluginLoader
    {
        private string Path { get; }

        public PluginLoader(string path)
        {
            Path = path;
        }

        public List<T> GetPlugins<T>()
        {
            var plugins = new List<T>();
            var directory = new DirectoryInfo(Path);
            
            if (!directory.Exists)
            {
                directory.Create();
                return plugins;
            } 

            var files = directory.GetFiles("*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file.Name);
                var types = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(T)));
                foreach (var type in types)
                {
                    var plugin = Activator.CreateInstance(type);
                    if (plugin != null)
                        plugins.Add((T)plugin);
                }
            }

            return plugins;
        }
    }
}
