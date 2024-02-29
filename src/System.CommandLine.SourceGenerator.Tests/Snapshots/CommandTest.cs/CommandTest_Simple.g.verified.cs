﻿//HintName: CommandTest_Simple.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class CommandTest_SimpleOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.CommandTest_Simple> Handler { get; set; }
    }

    public static class CommandTest_SimpleFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.Command Create(CommandTest_SimpleOptions options)
        {
            ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.CommandTest_Simple> handler = null;
            if (options != null)
                handler = options.Handler;
            global::System.CommandLine.Invocation.ICommandHandler handlerAdapter = null;
            if (handler != null)
                handlerAdapter = new CommandTest_SimpleCommandHandlerAdapter(handler);
            var cmd = new global::System.CommandLine.Command("Name", null)
            {
                Handler = handlerAdapter
            };
            return cmd;
        }

        private sealed class CommandTest_SimpleCommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.CommandTest_Simple> _commandHandler;

            public CommandTest_SimpleCommandHandlerAdapter(ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.CommandTest_Simple> commandHandler)
            {
                _commandHandler = commandHandler;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.CommandTest_Simple();
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}
