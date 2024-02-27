namespace System.CommandLine.SourceGenerator.Common;

public sealed class GlobalOptionAttribute : OptionAttribute
{
    public GlobalOptionAttribute(string name, string description = null) : base(name, description)
    {
    }

    public GlobalOptionAttribute(string[] aliases, string description = null) : base(aliases, description)
    {
    }
}
