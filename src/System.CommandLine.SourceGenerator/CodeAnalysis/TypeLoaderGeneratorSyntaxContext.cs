using Microsoft.CodeAnalysis;

namespace System.CommandLine.SourceGenerator.CodeAnalysis;

internal sealed class TypeLoaderGeneratorSyntaxContext : TypeLoaderContext
{
    public SyntaxNode Node => _context.Node;

    public SemanticModel SemanticModel => _context.SemanticModel;

    private readonly GeneratorSyntaxContext _context;

    public TypeLoaderGeneratorSyntaxContext(GeneratorSyntaxContext context) : base(context.SemanticModel.Compilation)
    {
        _context = context;
    }
}
