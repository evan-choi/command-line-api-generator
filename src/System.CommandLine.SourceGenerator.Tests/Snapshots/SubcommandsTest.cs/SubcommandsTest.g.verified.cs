﻿//HintName: SubcommandsTest.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class SubcommandsTestOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest> Handler { get; set; }

        public SubcommandsTest_AOptions SubcommandsTest_AOptions { get; set; }
    }

    public static class SubcommandsTestFactory
    {
        public static global::System.CommandLine.RootCommand Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.RootCommand Create(SubcommandsTestOptions options)
        {
            var symbol = new global::System.CommandLine.Option<global::System.Int32>("--option1", null);
            var handlerAdapter = new SubcommandsTestCommandHandlerAdapter(options.Handler, symbol);
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = handlerAdapter
            };
            cmd.AddOption(symbol);
            if (options != null && options.SubcommandsTest_AOptions != null)
            {
                cmd.AddCommand(SubcommandsTest_AFactory.Create(options.SubcommandsTest_AOptions));
            }
            else
            {
                cmd.AddCommand(SubcommandsTest_AFactory.Create());
            }
            return cmd;
        }

        private sealed class SubcommandsTestCommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest> _commandHandler;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Int32> _symbolOption1;

            public SubcommandsTestCommandHandlerAdapter(
                ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest> commandHandler,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Int32> symbolOption1)
            {
                _commandHandler = commandHandler;
                _symbolOption1 = symbolOption1;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest()
                {
                    Option1 = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Int32>(_symbolOption1, context)
                };
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}