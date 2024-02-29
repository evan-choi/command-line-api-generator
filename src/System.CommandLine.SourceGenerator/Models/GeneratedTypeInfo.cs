using System.CommandLine.SourceGenerator.Extensions;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Models;

internal sealed class GeneratedTypeInfo
{
    public INamedTypeSymbol TypeSymbol { get; }

    public string Suffix { get; }

    public string Name => TypeSymbol.Name + Suffix;

    public string QualifiedName => TypeSymbol.ContainingNamespace.IsGlobalNamespace
        ? $"global::{Name}"
        : TypeSymbol.ContainingNamespace.ToFullyQualifiedDisplayString(true) + '.' + Name;

    public GeneratedTypeInfo(INamedTypeSymbol typeSymbol, string suffix)
    {
        TypeSymbol = typeSymbol;
        Suffix = suffix;
    }

    public string GetQualifiedNameBy(INamedTypeSymbol targetTypeSymbol)
    {
        var thisNamespace = TypeSymbol.ContainingNamespace;
        var targetNamespace = targetTypeSymbol.ContainingNamespace;

        return SymbolEqualityComparer.Default.Equals(thisNamespace, targetNamespace)
            ? Name
            : QualifiedName;
    }
}
