using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Models;

internal interface IPropertyBasedSymbolDeclaration
{
    IPropertySymbol PropertySymbol { get; }
}
