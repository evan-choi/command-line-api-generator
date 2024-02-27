using System.CommandLine.SourceGenerator.Common;
using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.CodeAnalysis;

internal abstract class TypeLoaderContext
{
    public INamedTypeSymbol OptionAttributeType => _lazyOptionAttributeType.Value;

    public INamedTypeSymbol GlobalOptionAttributeType => _lazyGlobalOptionAttributeType.Value;

    public INamedTypeSymbol ArgumentAttributeType => _lazyArgumentAttributeType.Value;

    public INamedTypeSymbol CommandAttributeType => _lazyCommandAttributeType.Value;

    public INamedTypeSymbol RootCommandAttributeType => _lazyRootCommandAttributeType.Value;

    public INamedTypeSymbol ArgumentArityAttributeType => _lazyArgumentArityAttributeType.Value;

    private readonly Lazy<INamedTypeSymbol> _lazyOptionAttributeType;
    private readonly Lazy<INamedTypeSymbol> _lazyGlobalOptionAttributeType;
    private readonly Lazy<INamedTypeSymbol> _lazyArgumentAttributeType;
    private readonly Lazy<INamedTypeSymbol> _lazyCommandAttributeType;
    private readonly Lazy<INamedTypeSymbol> _lazyRootCommandAttributeType;
    private readonly Lazy<INamedTypeSymbol> _lazyArgumentArityAttributeType;

    protected TypeLoaderContext(Compilation compilation)
    {
        _lazyOptionAttributeType = CreateLazyGetType(compilation, typeof(OptionAttribute).FullName);
        _lazyGlobalOptionAttributeType = CreateLazyGetType(compilation, typeof(GlobalOptionAttribute).FullName);
        _lazyArgumentAttributeType = CreateLazyGetType(compilation, typeof(ArgumentAttribute).FullName);
        _lazyCommandAttributeType = CreateLazyGetType(compilation, typeof(CommandAttribute).FullName);
        _lazyRootCommandAttributeType = CreateLazyGetType(compilation, typeof(RootCommandAttribute).FullName);
        _lazyArgumentArityAttributeType = CreateLazyGetType(compilation, typeof(ArgumentArityAttribute).FullName);
    }

    private static Lazy<INamedTypeSymbol> CreateLazyGetType(Compilation compilation, string fullyQualifiedMetadataName)
    {
        return new Lazy<INamedTypeSymbol>(
            () => compilation.GetTypeByMetadataName(fullyQualifiedMetadataName)
                  ?? throw new TypeLoadException($"Type '{fullyQualifiedMetadataName}' not found.")
        );
    }
}
