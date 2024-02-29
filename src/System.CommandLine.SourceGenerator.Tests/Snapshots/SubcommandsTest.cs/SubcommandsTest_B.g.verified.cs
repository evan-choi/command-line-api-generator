﻿//HintName: SubcommandsTest_B.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class SubcommandsTest_BOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_B> Handler { get; set; }
    }

    public static class SubcommandsTest_BFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.Command Create(SubcommandsTest_BOptions options)
        {
            var symbol = new global::System.CommandLine.Option<global::System.Int32>("--option3", null);
            var handlerAdapter = new SubcommandsTest_BCommandHandlerAdapter(options.Handler, symbol);
            var cmd = new global::System.CommandLine.Command("B", null)
            {
                Handler = handlerAdapter
            };
            cmd.AddOption(symbol);
            return cmd;
        }

        private sealed class SubcommandsTest_BCommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_B> _commandHandler;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Int32> _symbolOption3;

            public SubcommandsTest_BCommandHandlerAdapter(
                ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_B> commandHandler,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Int32> symbolOption3)
            {
                _commandHandler = commandHandler;
                _symbolOption3 = symbolOption3;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_B()
                {
                    Option3 = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Int32>(_symbolOption3, context)
                };
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}