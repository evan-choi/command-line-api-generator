using System;
using System.IO;
using System.Threading.Tasks;
using System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests;

[RootCommand(Handler = typeof(StructTestHandler))]
public struct StructTest
{
    [Option("--hello")]
    public string Hello { get; set; }
}

public struct StructTestHandler : ICommandHandler<StructTest>
{
    public Task<int> InvokeAsync(StructTest command)
    {
        throw new NotImplementedException();
    }
}