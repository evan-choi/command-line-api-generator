using System.Collections.Generic;

namespace System.CommandLine.SourceGenerator.Models;

internal interface IAttributeDeclaration<out T> where T : Attribute
{
    T Value { get; }

    object[] ConstructorArguments { get; }

    IDictionary<string, object> NamedArguments { get; }
}
