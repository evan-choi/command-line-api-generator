using System.CommandLine.SourceGenerator.Common;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Models;

internal sealed class RootCommandDeclaration : CommandDeclaration
{
    public RootCommandDeclaration(
        INamedTypeSymbol typeSymbol,
        IAttributeDeclaration<RootCommandAttribute> attribute,
        INamedTypeSymbol handlerTypeSymbol,
        IPropertyBasedSymbolDeclaration[] symbolDeclarations,
        CommandDeclaration[] commandDeclarations)
        : base(typeSymbol, attribute, handlerTypeSymbol, symbolDeclarations, commandDeclarations)
    {
    }
}
