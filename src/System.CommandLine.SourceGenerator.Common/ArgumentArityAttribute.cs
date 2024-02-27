namespace System.CommandLine.SourceGenerator.Common;

[AttributeUsage(AttributeTargets.Property)]
public sealed class ArgumentArityAttribute : Attribute
{
    public int MinimumNumberOfValues { get; }

    public int MaximumNumberOfValues { get; }

    public ArgumentArityAttribute(int minimumNumberOfValues, int maximumNumberOfValues)
    {
        MinimumNumberOfValues = minimumNumberOfValues;
        MaximumNumberOfValues = maximumNumberOfValues;
    }
}
