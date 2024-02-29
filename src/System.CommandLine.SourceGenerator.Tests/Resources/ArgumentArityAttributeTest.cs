using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand]
public class ArgumentArityAttributeTest
{
    [Option("--Option")]
    [ArgumentArity(1, 2)]
    public bool OptionZero { get; set; }

    [Argument("--Argument")]
    [ArgumentArity(1, 2)]
    public bool ArgumentZero { get; set; }
}
