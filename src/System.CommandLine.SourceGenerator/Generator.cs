using System.Collections.Immutable;
using System.CommandLine.SourceGenerator.CodeAnalysis;
using System.CommandLine.SourceGenerator.Models;
using System.CommandLine.SourceGenerator.Extensions;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace System.CommandLine.SourceGenerator;

[Generator]
public class Generator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        IncrementalValueProvider<ImmutableArray<CommandDeclaration>> commandDeclarationsProvier
            = context.SyntaxProvider
                .CreateSyntaxProvider(
                    static (node, _) => node
                        is ClassDeclarationSyntax { AttributeLists.Count: > 0 }
                        or StructDeclarationSyntax { AttributeLists.Count: > 0 },
                    static (ctx, _) => GetSemanticTargetForGeneration(ctx)
                )
                .Where(x => x is not null)
                .Collect();

        context.RegisterSourceOutput(
            context.CompilationProvider.Combine(commandDeclarationsProvier),
            (spc, arg) => Execute(spc, arg.Left, arg.Right)
        );
    }

    private static CommandDeclaration GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var syntaxContext = new TypeLoaderGeneratorSyntaxContext(context);
        var node = (MemberDeclarationSyntax)context.Node;

        return node.AttributeLists
            .SelectMany(attributeListSyntax => attributeListSyntax.Attributes)
            .Select(attributeSyntax => ResolveCommandDeclaration(syntaxContext, attributeSyntax))
            .FirstOrDefault();
    }

    private void Execute(SourceProductionContext context, Compilation compilation, ImmutableArray<CommandDeclaration> commandDeclarations)
    {
        foreach (var (hintName, sourceText) in commandDeclarations.SelectMany(CommandLineGenerator.Generate))
            context.AddSource(hintName, sourceText);
    }

    private static CommandDeclaration ResolveCommandDeclaration(TypeLoaderGeneratorSyntaxContext context, AttributeSyntax syntax)
    {
        if (context.Node is not (ClassDeclarationSyntax or StructDeclarationSyntax))
            return null;

        if (context.SemanticModel.GetSymbolInfo(syntax) is not { Symbol: IMethodSymbol attributeSymbol })
            return null;

        if (!attributeSymbol.ContainingType.Is(context.RootCommandAttributeType))
            return null;

        // Resolve ITypeSymbol
        if (context.SemanticModel.GetDeclaredSymbol((BaseTypeDeclarationSyntax)context.Node) is not { } declaredSymbol)
            return null;

        // Resolve AttributeData
        return declaredSymbol.TryGetCusttomAttribute(context.CommandAttributeType, out var attributeData)
            ? CommandDeclaration.Create(context, declaredSymbol, attributeData)
            : null;
    }
}
