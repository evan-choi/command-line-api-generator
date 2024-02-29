namespace System.CommandLine.SourceGenerator.Common;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
public class CommandAttribute : IdentifierSymbolAttribute
{
    public bool TreatUnmatchedTokensAsErrors { get; set; }

    public Type Handler { get; set; }

    public Type[] Subcommands { get; set; }

    public CommandAttribute(string name, string description = null) : base(name, description)
    {
    }
}
