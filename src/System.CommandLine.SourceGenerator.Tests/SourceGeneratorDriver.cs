using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using NUnit.Framework;
using VerifyNUnit;
using VerifyTests;

namespace System.CommandLine.SourceGenerator.Tests;

public static class SourceGeneratorDriver
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifySourceGenerators.Initialize();
    }

    public static SettingsTask Verify<T>(IEnumerable<string> sources, IEnumerable<Assembly> referenceAssemblies) where T : IIncrementalGenerator, new()
    {
        sources ??= Enumerable.Empty<string>();
        referenceAssemblies ??= Enumerable.Empty<Assembly>();

        IEnumerable<SyntaxTree> syntaxTrees = sources
            .Select(x => CSharpSyntaxTree.ParseText(x));

        IEnumerable<PortableExecutableReference> references = referenceAssemblies
            .Select(x => MetadataReference.CreateFromFile(x.Location))
            .Prepend(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));

        var compilation = CSharpCompilation.Create(
            "System.CommandLine.SourceGenerator.Tests",
            syntaxTrees,
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );

        var generatorDriver = CSharpGeneratorDriver
            .Create(new T())
            .RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out ImmutableArray<Diagnostic> _);

        var emitResult = outputCompilation.Emit(Stream.Null);

        if (!emitResult.Success)
        {
            foreach (var diagnostic in emitResult.Diagnostics.Where(diag => diag.Severity == DiagnosticSeverity.Error))
                TestContext.Error.WriteLine(diagnostic.ToString());
        }

        Assert.That(emitResult.Success, Is.True);

        return Verifier.Verify(generatorDriver.GetRunResult());
    }
}
