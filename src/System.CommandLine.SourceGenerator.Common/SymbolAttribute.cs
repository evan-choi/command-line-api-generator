namespace System.CommandLine.SourceGenerator.Common;

public abstract class SymbolAttribute : Attribute
{
    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsHidden { get; set; }
}