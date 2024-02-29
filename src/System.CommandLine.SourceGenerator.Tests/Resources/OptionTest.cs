using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand]
public class ArgumentTest
{
    [Option("Simple")]
    public string Simple { get; set; }

    [Option(
        "Simple",
        "Description",
        Arity = ArgumentArityEnum.Zero,
        ArgumentHelpName = "ArgumentHelpName",
        AllowMultipleArgumentsPerToken = true,
        IsRequired = true,
        IsHidden = true,
        Aliases = new[] { "Aliases" }
    )]
    public string Full { get; set; }
}
