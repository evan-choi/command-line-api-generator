using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.CommandLine.SourceGenerator.Tests;

public class GeneratorTests
{
    public static IEnumerable<TestCaseData> TestFiles => ResourceManager.GetResourceNames()
        .Where(x => x.EndsWith(".cs"))
        .Select(x => x[(ResourceManager.Directory.Length + 1)..])
        .Select(x => new TestCaseData(x) { TestName = x });

    [TestCaseSource(nameof(TestFiles))]
    public Task Generate(string testFile)
    {
        var source = ResourceManager.GetString(testFile);

        Assembly[] referenceAssemblies =
        [
            Assembly.Load(new AssemblyName("netstandard")),
            Assembly.Load(new AssemblyName("System.Runtime")),
            Assembly.Load(new AssemblyName("System.CommandLine")),
            Assembly.Load(new AssemblyName("System.CommandLine.SourceGenerator.Common"))
        ];

        return SourceGeneratorDriver
            .Verify<Generator>(new[] { source }, referenceAssemblies)
            .UseUniqueDirectory()
            .UseFileName(testFile)
            .UseDirectory("Snapshots");
    }
}
