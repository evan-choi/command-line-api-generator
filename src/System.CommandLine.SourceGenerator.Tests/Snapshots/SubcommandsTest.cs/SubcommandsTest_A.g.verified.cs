﻿//HintName: SubcommandsTest_A.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class SubcommandsTest_AOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_A> Handler { get; set; }

        public SubcommandsTest_BOptions SubcommandsTest_BOptions { get; set; }
    }

    public static class SubcommandsTest_AFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.Command Create(SubcommandsTest_AOptions options)
        {
            var symbol = new global::System.CommandLine.Option<global::System.Int32>("--option2", null);
            ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_A> handler = null;
            if (options != null)
                handler = options.Handler;
            global::System.CommandLine.Invocation.ICommandHandler handlerAdapter = null;
            if (handler != null)
                handlerAdapter = new SubcommandsTest_ACommandHandlerAdapter(handler, symbol);
            var cmd = new global::System.CommandLine.Command("A", null)
            {
                Handler = handlerAdapter
            };
            cmd.AddOption(symbol);
            if (options != null && options.SubcommandsTest_BOptions != null)
            {
                cmd.AddCommand(SubcommandsTest_BFactory.Create(options.SubcommandsTest_BOptions));
            }
            else
            {
                cmd.AddCommand(SubcommandsTest_BFactory.Create());
            }
            return cmd;
        }

        private sealed class SubcommandsTest_ACommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_A> _commandHandler;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Int32> _symbolOption2;

            public SubcommandsTest_ACommandHandlerAdapter(
                ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_A> commandHandler,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Int32> symbolOption2)
            {
                _commandHandler = commandHandler;
                _symbolOption2 = symbolOption2;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.SubcommandsTest_A()
                {
                    Option2 = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Int32>(_symbolOption2, context)
                };
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}
