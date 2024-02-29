using System.Collections.Generic;
using System.Collections.Immutable;
using System.CommandLine.SourceGenerator.CodeAnalysis;
using System.CommandLine.SourceGenerator.Common;
using System.CommandLine.SourceGenerator.Extensions;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Models;

internal class CommandDeclaration
{
    public INamedTypeSymbol TypeSymbol { get; }

    public IAttributeDeclaration<CommandAttribute> Attribute { get; }

    public IPropertyBasedSymbolDeclaration[] SymbolDeclarations { get; }

    public CommandDeclaration[] CommandDeclarations { get; }

    public INamedTypeSymbol HandlerTypeSymbol { get; }

    public GeneratedTypeInfo OptionsType { get; }

    public GeneratedTypeInfo FactoryType { get; }

    public GeneratedTypeInfo CommandHandlerAdapterType { get; }

    public CommandDeclaration(
        INamedTypeSymbol typeSymbol,
        IAttributeDeclaration<CommandAttribute> attribute,
        INamedTypeSymbol handlerTypeSymbol,
        IPropertyBasedSymbolDeclaration[] symbolDeclarations,
        CommandDeclaration[] commandDeclarations)
    {
        TypeSymbol = typeSymbol;
        Attribute = attribute;
        HandlerTypeSymbol = handlerTypeSymbol;
        SymbolDeclarations = symbolDeclarations;
        CommandDeclarations = commandDeclarations;

        OptionsType = new GeneratedTypeInfo(typeSymbol, "Options");
        FactoryType = new GeneratedTypeInfo(typeSymbol, "Factory");
        CommandHandlerAdapterType = new GeneratedTypeInfo(typeSymbol, "CommandHandlerAdapter");
    }

    public static CommandDeclaration Create(TypeLoaderGeneratorSyntaxContext context, INamedTypeSymbol typeSymbol, AttributeData attributeData)
    {
        IPropertyBasedSymbolDeclaration[] symbolDeclarations = GetPropertyBasedSymbolDeclarations(context, typeSymbol).ToArray();
        CommandDeclaration[] commandDeclarations = GetCommandDeclarations(context, typeSymbol, attributeData).ToArray();

        var handlerTypeSymbol = (INamedTypeSymbol)attributeData.NamedArguments
            .FirstOrDefault(x => x.Key == nameof(CommandAttribute.Handler))
            .Value
            .Value;

        if (attributeData.AttributeClass.Is(context.RootCommandAttributeType))
        {
            var attribute = new AttributeDeclaration<RootCommandAttribute>(attributeData);
            attribute.NamedArguments.Remove(nameof(CommandAttribute.Handler));
            attribute.NamedArguments.Remove(nameof(CommandAttribute.Subcommands));

            return new RootCommandDeclaration(typeSymbol, attribute, handlerTypeSymbol, symbolDeclarations, commandDeclarations);
        }
        else
        {
            var attribute = new AttributeDeclaration<CommandAttribute>(attributeData);
            attribute.NamedArguments.Remove(nameof(CommandAttribute.Handler));
            attribute.NamedArguments.Remove(nameof(CommandAttribute.Subcommands));

            return new CommandDeclaration(typeSymbol, attribute, handlerTypeSymbol, symbolDeclarations, commandDeclarations);
        }
    }

    private static IEnumerable<IPropertyBasedSymbolDeclaration> GetPropertyBasedSymbolDeclarations(
        TypeLoaderGeneratorSyntaxContext context,
        INamedTypeSymbol typeSymbol)
    {
        var visited = new HashSet<IPropertySymbol>(SymbolEqualityComparer.Default);

        while (typeSymbol is not null)
        {
            foreach (var property in typeSymbol.GetMembers().OfType<IPropertySymbol>())
            {
                if (!visited.Add(property))
                    continue;

                ImmutableArray<AttributeData> attributes = property.GetAttributes();

                var optionAttribute = attributes
                    .FirstOrDefault(x => x.AttributeClass.Is(context.OptionAttributeType));

                var globalOptionAttribute = attributes
                    .FirstOrDefault(x => x.AttributeClass.Is(context.GlobalOptionAttributeType));

                var argumentAttribute = attributes
                    .FirstOrDefault(x => x.AttributeClass.Is(context.ArgumentAttributeType));

                if (optionAttribute == null && globalOptionAttribute == null && argumentAttribute == null)
                    continue;

                if (property.IsReadOnly)
                    throw new Exception($"Property '{property.Name}' cannot be read-only. Mutable properties are required.");

                if (property.IsOverride)
                    visited.Add(property.OverriddenProperty);

                var argumentArity = attributes
                    .FirstOrDefault(x => x.AttributeClass.Is(context.ArgumentArityAttributeType))
                    ?.Create<ArgumentArityAttribute>();

                if (optionAttribute is not null)
                {
                    var attribute = new AttributeDeclaration<OptionAttribute>(optionAttribute);
                    yield return new OptionDeclaration(property, attribute, argumentArity);
                }
                else if (globalOptionAttribute is not null)
                {
                    var attribute = new AttributeDeclaration<GlobalOptionAttribute>(globalOptionAttribute);
                    yield return new OptionDeclaration(property, attribute, argumentArity);
                }
                else
                {
                    var attribute = new AttributeDeclaration<ArgumentAttribute>(argumentAttribute);
                    yield return new ArgumentDeclaration(property, attribute, argumentArity);
                }
            }

            typeSymbol = typeSymbol.BaseType;
        }
    }

    private static IEnumerable<CommandDeclaration> GetCommandDeclarations(TypeLoaderGeneratorSyntaxContext context, INamedTypeSymbol typeSymbol, AttributeData attributeData)
    {
        var subcommandsTypedConstant = attributeData.NamedArguments
            .FirstOrDefault(x => x.Key == nameof(CommandAttribute.Subcommands))
            .Value;

        IEnumerable<INamedTypeSymbol> subcommads = subcommandsTypedConstant is { Kind: TypedConstantKind.Array }
            ? subcommandsTypedConstant.Values.Select(x => (INamedTypeSymbol)x.Value)
            : Enumerable.Empty<INamedTypeSymbol>();

        foreach (var nestedTypeSymbol in subcommads.Concat(typeSymbol.GetTypeMembers()))
        {
            if (!nestedTypeSymbol.TryGetCusttomAttribute(context.CommandAttributeType, out var subCommadAttributeData))
                continue;

            yield return Create(context, nestedTypeSymbol, subCommadAttributeData);
        }
    }
}
