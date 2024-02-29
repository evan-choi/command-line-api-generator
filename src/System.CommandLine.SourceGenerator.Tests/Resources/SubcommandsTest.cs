using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand(Subcommands = new[] { typeof(SubcommandsTest_A) })]
public class SubcommandsTest
{
    [Option("--option1")]
    public int Option1 { get; set; }
}

[Command("A", Subcommands = new[] { typeof(SubcommandsTest_B) })]
public class SubcommandsTest_A
{
    [Option("--option2")]
    public int Option2 { get; set; }
}

[Command("B")]
public class SubcommandsTest_B
{
    [Option("--option3")]
    public int Option3 { get; set; }
}