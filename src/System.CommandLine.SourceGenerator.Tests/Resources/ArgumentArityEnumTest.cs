using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand]
public class ArgumentArityEnumTest
{
    [Option("--Zero", Arity = ArgumentArityEnum.Zero)]
    public bool Zero { get; set; }

    [Option("--ZeroOrOne", Arity = ArgumentArityEnum.ZeroOrOne)]
    public bool ZeroOrOne { get; set; }

    [Option("--ExactlyOne", Arity = ArgumentArityEnum.ExactlyOne)]
    public bool ExactlyOne { get; set; }

    [Option("--ZeroOrMore", Arity = ArgumentArityEnum.ZeroOrMore)]
    public bool ZeroOrMore { get; set; }

    [Option("--OneOrMore", Arity = ArgumentArityEnum.OneOrMore)]
    public bool OneOrMore { get; set; }
}
