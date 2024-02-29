using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand]
public class ArgumentArityEnumTest
{
    [Option("--Option-Zero", Arity = ArgumentArityEnum.Zero)]
    public bool OptionZero { get; set; }

    [Option("--Option-ZeroOrOne", Arity = ArgumentArityEnum.ZeroOrOne)]
    public bool OptionZeroOrOne { get; set; }

    [Option("--Option-ExactlyOne", Arity = ArgumentArityEnum.ExactlyOne)]
    public bool OptionExactlyOne { get; set; }

    [Option("--Option-ZeroOrMore", Arity = ArgumentArityEnum.ZeroOrMore)]
    public bool OptionZeroOrMore { get; set; }

    [Option("--Option-OneOrMore", Arity = ArgumentArityEnum.OneOrMore)]
    public bool OptionOneOrMore { get; set; }
    
    [Argument("--Argument-Zero", Arity = ArgumentArityEnum.Zero)]
    public bool ArgumentZero { get; set; }

    [Argument("--Argument-ZeroOrOne", Arity = ArgumentArityEnum.ZeroOrOne)]
    public bool ArgumentZeroOrOne { get; set; }

    [Argument("--Argument-ExactlyOne", Arity = ArgumentArityEnum.ExactlyOne)]
    public bool ArgumentExactlyOne { get; set; }

    [Argument("--Argument-ZeroOrMore", Arity = ArgumentArityEnum.ZeroOrMore)]
    public bool ArgumentZeroOrMore { get; set; }

    [Argument("--Argument-OneOrMore", Arity = ArgumentArityEnum.OneOrMore)]
    public bool ArgumentOneOrMore { get; set; }
}
