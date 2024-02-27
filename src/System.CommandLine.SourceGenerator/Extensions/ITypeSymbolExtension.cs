using System.Linq;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Extensions;

internal static class ITypeSymbolExtension
{
    public static bool Is(this ITypeSymbol x, ITypeSymbol y)
    {
        return SymbolEqualityComparer.Default.Equals(x, y);
    }

    public static bool IsAssignableFrom(this ITypeSymbol x, ITypeSymbol y)
    {
        while (y is not null)
        {
            if (SymbolEqualityComparer.Default.Equals(x, y))
                return true;

            y = y.BaseType;
        }

        return false;
    }

    public static bool TryGetCusttomAttribute(this ITypeSymbol typeSymbol, ITypeSymbol attributeTypeSymbol, out AttributeData attributeData)
    {
        attributeData = typeSymbol
            .GetAttributes()
            .SingleOrDefault(x => attributeTypeSymbol.IsAssignableFrom(x.AttributeClass));

        return attributeData is not null;
    }
}
