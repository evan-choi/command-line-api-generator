using System.Collections.Generic;
using System.CommandLine.SourceGenerator.Extensions;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Models;

internal sealed class AttributeDeclaration<T> : IAttributeDeclaration<T> where T : Attribute
{
    public T Value => _lazyValue.Value;

    public object[] ConstructorArguments { get; }

    public IDictionary<string, object> NamedArguments { get; }

    private readonly Lazy<T> _lazyValue;

    public AttributeDeclaration(AttributeData attributeData)
    {
        ConstructorArguments = attributeData.ConstructorArguments
            .Select(x => x.ToValue())
            .ToArray();

        NamedArguments = attributeData.NamedArguments
            .ToDictionary(x => x.Key, x => x.Value.ToValueIfAvailable());

        _lazyValue = new Lazy<T>(Create);
    }

    private T Create()
    {
        var attribute = (T)Activator.CreateInstance(typeof(T), ConstructorArguments);

        foreach (KeyValuePair<string, object> namedArgument in NamedArguments)
        {
            var property = typeof(T).GetProperty(namedArgument.Key)
                           ?? throw new Exception($"Property '{namedArgument.Key}' not found in '{typeof(T)}'");

            property.SetValue(attribute, namedArgument.Value);
        }

        return attribute;
    }
}
