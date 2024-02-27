using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.CommandLine.SourceGenerator.Tests;

public class GeneratorTests
{
    [Test]
    public Task RootCommand()
    {
        string[] sources = ResourceManager.GetResourceNames()
            .Where(x => x.EndsWith(".cs"))
            .Select(ResourceManager.GetString)
            .ToArray();

        Assembly[] referenceAssemblies =
        [
            Assembly.Load(new AssemblyName("netstandard")),
            Assembly.Load(new AssemblyName("System.Runtime")),
            Assembly.Load(new AssemblyName("System.CommandLine")),
            Assembly.Load(new AssemblyName("System.CommandLine.SourceGenerator.Common"))
        ];

        return SourceGeneratorDriver
            .Verify<Generator>(sources, referenceAssemblies)
            .UseDirectory("Snapshots");
    }
}
