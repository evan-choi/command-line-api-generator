namespace System.CommandLine.SourceGenerator.Common;

[AttributeUsage(AttributeTargets.Property)]
public class OptionAttribute : IdentifierSymbolAttribute
{
    public ArgumentArityEnum Arity
    {
        get => ArityInternal ?? default;
        set => ArityInternal = value;
    }

    internal ArgumentArityEnum? ArityInternal { get; set; }

    public string ArgumentHelpName { get; set; }

    public bool AllowMultipleArgumentsPerToken { get; set; }

    public bool IsRequired { get; set; }

    public OptionAttribute(string name, string description = null) : base(description)
    {
        Name = name;
    }

    public OptionAttribute(string[] aliases, string description = null) : base(description)
    {
        Aliases = aliases;
    }
}
