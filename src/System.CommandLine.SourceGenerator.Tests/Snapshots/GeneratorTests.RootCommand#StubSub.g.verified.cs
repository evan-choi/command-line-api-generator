﻿//HintName: StubSub.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public static class StubSubFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            var cmd = new global::System.CommandLine.Command("sub", null)
            {
                Handler = new StubSubCommandHandler()
            };
            cmd.AddAlias("s");
            cmd.AddAlias("su");
            cmd.AddAlias("sub");
            cmd.AddCommand(global::System.CommandLine.SourceGenerator.Tests.StubSubSubFactory.Create());
            return cmd;
        }

        private sealed class StubSubCommandHandler : global::System.CommandLine.Invocation.ICommandHandler
        {
            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.Stub.StubSub();
                var handler = new global::System.CommandLine.SourceGenerator.Tests.StubSubHandler();
                return handler.InvokeAsync(command);
            }
        }
    }
}
