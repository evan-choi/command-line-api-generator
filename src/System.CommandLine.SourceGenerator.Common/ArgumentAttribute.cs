namespace System.CommandLine.SourceGenerator.Common;

[AttributeUsage(AttributeTargets.Property)]
public sealed class ArgumentAttribute : SymbolAttribute
{
    public ArgumentArityEnum Arity
    {
        get => ArityInternal ?? default;
        set => ArityInternal = value;
    }

    internal ArgumentArityEnum? ArityInternal { get; set; }

    public string HelpName { get; set; }

    public ArgumentAttribute()
    {
    }

    public ArgumentAttribute(string name, string description = null)
    {
        Name = name;
        Description = description;
    }
}
