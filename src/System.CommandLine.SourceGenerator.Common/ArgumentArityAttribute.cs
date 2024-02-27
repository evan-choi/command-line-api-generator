namespace System.CommandLine.SourceGenerator.Common;

[AttributeUsage(AttributeTargets.Property)]
public sealed class ArgumentArityAttribute : Attribute
{
    public ArgumentArity Arity { get; }

    public ArgumentArityAttribute(int minimumNumberOfValues, int maximumNumberOfValues)
    {
        Arity = new ArgumentArity(minimumNumberOfValues, maximumNumberOfValues);
    }
}
