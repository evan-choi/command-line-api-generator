using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand]
public class ArgumentTest
{
    [Argument]
    public string Simple { get; set; }

    [Argument(
        "Name",
        "Description",
        Arity = ArgumentArityEnum.Zero,
        HelpName = "HelpName",
        IsHidden = true
    )]
    public string Full { get; set; }
}
