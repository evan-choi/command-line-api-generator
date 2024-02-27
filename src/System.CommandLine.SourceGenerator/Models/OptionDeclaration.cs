using System.CommandLine.SourceGenerator.Common;
using System.Diagnostics;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Models;

[DebuggerDisplay("{PropertySymbol.Type.Name} {PropertySymbol.MetadataName}")]
internal sealed class OptionDeclaration : IPropertyBasedSymbolDeclaration
{
    public IPropertySymbol PropertySymbol { get; }

    public IAttributeDeclaration<OptionAttribute> Attribute { get; }

    public ArgumentArityAttribute Arity { get; }

    public OptionDeclaration(IPropertySymbol propertySymbol, IAttributeDeclaration<OptionAttribute> attribute, ArgumentArityAttribute arity)
    {
        PropertySymbol = propertySymbol;
        Attribute = attribute;
        Arity = arity;
    }
}
