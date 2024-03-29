﻿//HintName: ArgumentArityAttributeTest.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class ArgumentArityAttributeTestOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityAttributeTest> Handler { get; set; }
    }

    public static class ArgumentArityAttributeTestFactory
    {
        public static global::System.CommandLine.RootCommand Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.RootCommand Create(ArgumentArityAttributeTestOptions options)
        {
            var symbol = new global::System.CommandLine.Option<global::System.Boolean>("--Option", null)
            {
                Arity = new global::System.CommandLine.ArgumentArity(1, 2)
            };
            var symbol1 = new global::System.CommandLine.Argument<global::System.Boolean>("--Argument", null)
            {
                Arity = new global::System.CommandLine.ArgumentArity(1, 2)
            };
            ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityAttributeTest> handler = null;
            if (options != null)
                handler = options.Handler;
            global::System.CommandLine.Invocation.ICommandHandler handlerAdapter = null;
            if (handler != null)
                handlerAdapter = new ArgumentArityAttributeTestCommandHandlerAdapter(handler, symbol, symbol1);
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = handlerAdapter
            };
            cmd.AddOption(symbol);
            cmd.AddArgument(symbol1);
            return cmd;
        }

        private sealed class ArgumentArityAttributeTestCommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityAttributeTest> _commandHandler;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> _symbolOptionZero;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> _symbolArgumentZero;

            public ArgumentArityAttributeTestCommandHandlerAdapter(
                ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityAttributeTest> commandHandler,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> symbolOptionZero,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> symbolArgumentZero)
            {
                _commandHandler = commandHandler;
                _symbolOptionZero = symbolOptionZero;
                _symbolArgumentZero = symbolArgumentZero;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.ArgumentArityAttributeTest()
                {
                    OptionZero = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Boolean>(_symbolOptionZero, context),
                    ArgumentZero = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Boolean>(_symbolArgumentZero, context)
                };
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}
