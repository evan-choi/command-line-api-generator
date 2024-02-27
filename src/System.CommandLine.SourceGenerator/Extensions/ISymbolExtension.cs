using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Extensions;

internal static class ISymbolExtension
{
    public static string ToFullyQualifiedDisplayString(this ISymbol s, bool globalNamespace = false)
    {
        if (s == null || IsRootNamespace(s))
            return string.Empty;

        var format = new SymbolDisplayFormat(
            typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
            globalNamespaceStyle: globalNamespace ? SymbolDisplayGlobalNamespaceStyle.Included : SymbolDisplayGlobalNamespaceStyle.Omitted
        );

        return s.ToDisplayString(format);
    }

    private static bool IsRootNamespace(ISymbol symbol)
    {
        return symbol is INamespaceSymbol { IsGlobalNamespace: true };
    }
}
