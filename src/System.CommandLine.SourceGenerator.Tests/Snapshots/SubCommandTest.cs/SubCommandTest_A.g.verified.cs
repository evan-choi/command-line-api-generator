﻿//HintName: SubCommandTest_A.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class SubCommandTest_AOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubCommandTest_A> Handler { get; set; }

        public SubCommandTest_SubOptions SubCommandTest_SubOptions { get; set; }
    }

    public static class SubCommandTest_AFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.Command Create(SubCommandTest_AOptions options)
        {
            ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubCommandTest_A> handler = null;
            if (options != null)
                handler = options.Handler;
            global::System.CommandLine.Invocation.ICommandHandler handlerAdapter = null;
            if (handler != null)
                handlerAdapter = new SubCommandTest_ACommandHandlerAdapter(handler);
            var cmd = new global::System.CommandLine.Command("A", null)
            {
                Handler = handlerAdapter
            };
            if (options != null && options.SubCommandTest_SubOptions != null)
            {
                cmd.AddCommand(SubCommandTest_SubFactory.Create(options.SubCommandTest_SubOptions));
            }
            else
            {
                cmd.AddCommand(SubCommandTest_SubFactory.Create());
            }
            return cmd;
        }

        private sealed class SubCommandTest_ACommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubCommandTest_A> _commandHandler;

            public SubCommandTest_ACommandHandlerAdapter(ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubCommandTest_A> commandHandler)
            {
                _commandHandler = commandHandler;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.SubCommandTest_A();
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}