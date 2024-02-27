namespace System.CommandLine.SourceGenerator.Common;

public abstract class IdentifierSymbolAttribute : SymbolAttribute
{
    public string[] Aliases { get; set; }

    protected IdentifierSymbolAttribute(string description = null)
    {
        Description = description;
    }

    protected IdentifierSymbolAttribute(string name, string description = null)
    {
        Name = name;
        Description = description;
    }
}
