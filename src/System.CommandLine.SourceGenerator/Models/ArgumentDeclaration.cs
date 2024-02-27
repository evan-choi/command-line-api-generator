using System.CommandLine.SourceGenerator.Common;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Models;

internal sealed class ArgumentDeclaration : IPropertyBasedSymbolDeclaration
{
    public IPropertySymbol PropertySymbol { get; }

    public IAttributeDeclaration<ArgumentAttribute> Attribute { get; }

    public ArgumentArityAttribute Arity { get; }

    public ArgumentDeclaration(IPropertySymbol propertySymbol, IAttributeDeclaration<ArgumentAttribute> attribute, ArgumentArityAttribute arity)
    {
        PropertySymbol = propertySymbol;
        Attribute = attribute;
        Arity = arity;
    }
}
