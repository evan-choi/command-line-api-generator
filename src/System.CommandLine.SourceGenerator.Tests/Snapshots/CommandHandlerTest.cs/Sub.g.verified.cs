﻿//HintName: Sub.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class SubOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.CommandHandlerTest.Sub> Handler { get; set; }

        public Sub2Options Sub2Options { get; set; }
    }

    public static class SubFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.Command Create(SubOptions options)
        {
            var handler = options.Handler;
            if (handler == null)
                handler = new global::System.CommandLine.SourceGenerator.Tests.CommandHandlerTest_Sub_CommandHandler();
            var handlerAdapter = new SubCommandHandlerAdapter(handler);
            var cmd = new global::System.CommandLine.Command("sub", null)
            {
                Handler = handlerAdapter
            };
            cmd.AddAlias("s");
            cmd.AddAlias("su");
            cmd.AddAlias("sub");
            if (options != null && options.Sub2Options != null)
            {
                cmd.AddCommand(Sub2Factory.Create(options.Sub2Options));
            }
            else
            {
                cmd.AddCommand(Sub2Factory.Create());
            }
            return cmd;
        }

        private sealed class SubCommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.CommandHandlerTest.Sub> _commandHandler;

            public SubCommandHandlerAdapter(ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.CommandHandlerTest.Sub> commandHandler)
            {
                _commandHandler = commandHandler;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.CommandHandlerTest.Sub();
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}
