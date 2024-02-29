using System.Collections.Generic;
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
                    static (node, _) => IsSemanticTargetForGeneration(node),
                    static (ctx, _) => GetSemanticTargetForGeneration(ctx)
                )
                .Where(x => x is not null)
                .Collect();

        context.RegisterSourceOutput(
            context.CompilationProvider.Combine(commandDeclarationsProvier),
            (spc, arg) => Execute(spc, arg.Left, arg.Right)
        );
    }

    private static bool IsSemanticTargetForGeneration(SyntaxNode node)
    {
        switch (node)
        {
            // class ~~          : O
            // sealed class ~~   : O
            // abstract class ~~ : X
            case ClassDeclarationSyntax { AttributeLists.Count: > 0 } classDeclarationSyntax when
                !classDeclarationSyntax.Modifiers.Any(x => x.IsKind(SyntaxKind.AbstractKeyword)):

            // struct ~~          : O
            // readonly struct ~~ : X
            // ref struct ~~      : X
            case StructDeclarationSyntax { AttributeLists.Count: > 0 } structDeclarationSyntax when
                !structDeclarationSyntax.Modifiers.Any(x => x.IsKind(SyntaxKind.ReadOnlyKeyword) || x.IsKind(SyntaxKind.RefKeyword)):
                return true;

            default:
                return false;
        }
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
        var reduce = new Dictionary<INamedTypeSymbol, CommandDeclaration>(SymbolEqualityComparer.Default);

        foreach (var command in commandDeclarations.SelectMany(Flatten))
            reduce[command.TypeSymbol] = command;

        foreach (var (hintName, sourceText) in reduce.Values.Select(CommandLineGenerator.Generate))
            context.AddSource(hintName, sourceText);

        static IEnumerable<CommandDeclaration> Flatten(CommandDeclaration command)
        {
            yield return command;

            foreach (var subCommand in command.CommandDeclarations.SelectMany(Flatten))
                yield return subCommand;
        }
    }

    private static CommandDeclaration ResolveCommandDeclaration(TypeLoaderGeneratorSyntaxContext context, AttributeSyntax syntax)
    {
        if (context.Node is not (ClassDeclarationSyntax or StructDeclarationSyntax))
            return null;

        if (context.SemanticModel.GetSymbolInfo(syntax) is not { Symbol: IMethodSymbol attributeSymbol })
            return null;

        if (!context.CommandAttributeType.IsAssignableFrom(attributeSymbol.ContainingType))
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
