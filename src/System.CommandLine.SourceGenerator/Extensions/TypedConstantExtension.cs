using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.Extensions;

internal static class TypedConstantExtension
{
    public static object ToValueIfAvailable(this TypedConstant typedConstant)
    {
        try
        {
            return typedConstant.ToValue();
        }
        catch
        {
            return typedConstant;
        }
    }

    public static object ToValue(this TypedConstant typedConstant)
    {
        switch (typedConstant.Kind)
        {
            case TypedConstantKind.Primitive:
                return typedConstant.Value;

            case TypedConstantKind.Enum:
                var enumType = GetType(typedConstant.Type);
                return Enum.ToObject(enumType, typedConstant.Value!);

            case TypedConstantKind.Type:
                return GetType((ISymbol)typedConstant.Value);

            case TypedConstantKind.Array
                when typedConstant.Type is IArrayTypeSymbol { IsSZArray: true, Rank: 1 } arrayTypeSymbol:
            {
                var elementType = GetType(arrayTypeSymbol.ElementType);
                var array = Array.CreateInstance(elementType, typedConstant.Values.Length);

                for (int i = 0; i < array.Length; i++)
                    array.SetValue(typedConstant.Values[i].ToValue(), i);

                return array;
            }

            case TypedConstantKind.Array:
                throw new NotSupportedException("Array TypedConstant support only szied array");

            case TypedConstantKind.Error:
                return null;

            default:
                throw new NotSupportedException($"Unsupported TypedConstant kind: {typedConstant.Kind}");
        }
    }

    private static Type GetType(ISymbol symbol)
    {
        var typeName = $"{symbol.ToFullyQualifiedDisplayString()}, {symbol.ContainingAssembly}";
        return Type.GetType(typeName, true);
    }
}
