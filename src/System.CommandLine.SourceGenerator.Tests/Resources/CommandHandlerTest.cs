using System;
using System.IO;
using System.Threading.Tasks;
using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand(Handler = typeof(CommandHandlerTest_CommandHandler))]
public class CommandHandlerTest
{
    [GlobalOption("--global")]
    public bool GlobalProperty { get; set; }

    [Option("--string")]
    public string StringProperty { get; set; }

    [Option("--string-array")]
    public string[] StringArrayProperty { get; set; }

    [Option(
        "--int",
        "Description: IntProperty",
        Aliases = new[] { "--int32", "-i" },
        Arity = ArgumentArityEnum.ZeroOrOne,
        AllowMultipleArgumentsPerToken = true,
        ArgumentHelpName = "ArgumentHelpName: IntProperty",
        Description = "Description2: IntProperty",
        IsHidden = true,
        IsRequired = true,
        Name = "--int2"
    )]
    public int IntProperty { get; set; }

    [Option(
        description: "Description: NullableIntProperty",
        name: "--nullable-int"
    )]
    public int? NullableIntProperty { get; set; }

    [Argument("Argument", Description = "Description: DoubleProperty")]
    [ArgumentArity(2, 4)]
    public double DoubleProperty { get; set; }

    [Command("sub", Aliases = new[] { "s", "su", "sub" }, Handler = typeof(CommandHandlerTest_Sub_CommandHandler))]
    public sealed class Sub
    {
        [Command("sub2", Handler = typeof(CommandHandlerTest_Sub_Sub2_CommandHandler))]
        public struct Sub2
        {
            [Option("-A")]
            public string A { get; set; }

            [Option("-B")]
            public string B { get; set; }
        }
    }
}

public class CommandHandlerTest_CommandHandler : ICommandHandler<CommandHandlerTest>
{
    public Task<int> InvokeAsync(CommandHandlerTest command)
    {
        throw new NotImplementedException();
    }
}

public class CommandHandlerTest_Sub_CommandHandler : ICommandHandler<CommandHandlerTest.Sub>
{
    public Task<int> InvokeAsync(CommandHandlerTest.Sub command)
    {
        throw new NotImplementedException();
    }
}

public class CommandHandlerTest_Sub_Sub2_CommandHandler : ICommandHandler<CommandHandlerTest.Sub.Sub2>
{
    public Task<int> InvokeAsync(CommandHandlerTest.Sub.Sub2 command)
    {
        throw new NotImplementedException();
    }
}
