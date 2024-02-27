namespace System.CommandLine.SourceGenerator.Common;

public sealed class RootCommandAttribute : CommandAttribute
{
    public RootCommandAttribute(string description = "") : base(null, description)
    {
    }
}
