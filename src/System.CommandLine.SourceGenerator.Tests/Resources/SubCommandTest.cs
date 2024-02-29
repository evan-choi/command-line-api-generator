using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[Command("A", Subcommands = new[] { typeof(SubCommandTest_Sub) })]
public class SubCommandTest_A
{
}

[Command("B", Subcommands = new[] { typeof(SubCommandTest_Sub) })]
public class SubCommandTest_B
{
}

[Command("Sub")]
public class SubCommandTest_Sub
{
}
