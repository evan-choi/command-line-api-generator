using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Extensions;

internal static class AttributeDataExtension
{
    public static T Create<T>(this AttributeData data) where T : Attribute
    {
        var arguments = data.ConstructorArguments
            .Select(x => x.ToValue())
            .ToArray();

        var attribute = (T)Activator.CreateInstance(typeof(T), arguments);

        foreach (KeyValuePair<string, TypedConstant> namedArgument in data.NamedArguments)
        {
            var property = typeof(T).GetProperty(namedArgument.Key)
                           ?? throw new Exception($"Property '{namedArgument.Key}' not found in '{typeof(T)}'");

            property.SetValue(attribute, namedArgument.Value.ToValue());
        }

        return attribute;
    }
}
