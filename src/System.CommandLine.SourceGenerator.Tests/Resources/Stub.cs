using System;
using System.IO;
using System.Threading.Tasks;
using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand(Handler = typeof(StubHandler))]
public class Stub
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

    [Argument("Argument")]
    [ArgumentArity(2, 4)]
    public double DoubleProperty { get; set; }

    [Command("sub", Aliases = new[] { "s", "su", "sub" }, Handler = typeof(StubSubHandler))]
    public sealed class StubSub
    {
        [Command("sub2", Handler = typeof(StubSubSubHandler))]
        public struct StubSubSub
        {
            [Option("-A")]
            public string A { get; set; }

            [Option("-B")]
            public string B { get; set; }
        }
    }
}

public class StubHandler : ICommandHandler<Stub>
{
    public Task<int> InvokeAsync(Stub command)
    {
        throw new NotImplementedException();
    }
}

public class StubSubHandler : ICommandHandler<Stub.StubSub>
{
    public Task<int> InvokeAsync(Stub.StubSub command)
    {
        throw new NotImplementedException();
    }
}

public class StubSubSubHandler : ICommandHandler<Stub.StubSub.StubSubSub>
{
    public Task<int> InvokeAsync(Stub.StubSub.StubSubSub command)
    {
        throw new NotImplementedException();
    }
}
