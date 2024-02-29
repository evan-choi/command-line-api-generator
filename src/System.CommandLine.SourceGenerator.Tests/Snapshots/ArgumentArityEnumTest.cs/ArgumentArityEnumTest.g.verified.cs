﻿//HintName: ArgumentArityEnumTest.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class ArgumentArityEnumTestOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityEnumTest> Handler { get; set; }
    }

    public static class ArgumentArityEnumTestFactory
    {
        public static global::System.CommandLine.RootCommand Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.RootCommand Create(ArgumentArityEnumTestOptions options)
        {
            var symbol = new global::System.CommandLine.Option<global::System.Boolean>("--Zero", null)
            {
                Arity = global::System.CommandLine.ArgumentArity.Zero
            };
            var symbol1 = new global::System.CommandLine.Option<global::System.Boolean>("--ZeroOrOne", null)
            {
                Arity = global::System.CommandLine.ArgumentArity.ZeroOrOne
            };
            var symbol2 = new global::System.CommandLine.Option<global::System.Boolean>("--ExactlyOne", null)
            {
                Arity = global::System.CommandLine.ArgumentArity.ExactlyOne
            };
            var symbol3 = new global::System.CommandLine.Option<global::System.Boolean>("--ZeroOrMore", null)
            {
                Arity = global::System.CommandLine.ArgumentArity.ZeroOrMore
            };
            var symbol4 = new global::System.CommandLine.Option<global::System.Boolean>("--OneOrMore", null)
            {
                Arity = global::System.CommandLine.ArgumentArity.OneOrMore
            };
            ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityEnumTest> handler = null;
            if (options != null)
                handler = options.Handler;
            global::System.CommandLine.Invocation.ICommandHandler handlerAdapter = null;
            if (handler != null)
                handlerAdapter = new ArgumentArityEnumTestCommandHandlerAdapter(handler, symbol, symbol1, symbol2, symbol3, symbol4);
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = handlerAdapter
            };
            cmd.AddOption(symbol);
            cmd.AddOption(symbol1);
            cmd.AddOption(symbol2);
            cmd.AddOption(symbol3);
            cmd.AddOption(symbol4);
            return cmd;
        }

        private sealed class ArgumentArityEnumTestCommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityEnumTest> _commandHandler;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> _symbolZero;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> _symbolZeroOrOne;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> _symbolExactlyOne;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> _symbolZeroOrMore;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> _symbolOneOrMore;

            public ArgumentArityEnumTestCommandHandlerAdapter(
                ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.ArgumentArityEnumTest> commandHandler,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> symbolZero,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> symbolZeroOrOne,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> symbolExactlyOne,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> symbolZeroOrMore,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.Boolean> symbolOneOrMore)
            {
                _commandHandler = commandHandler;
                _symbolZero = symbolZero;
                _symbolZeroOrOne = symbolZeroOrOne;
                _symbolExactlyOne = symbolExactlyOne;
                _symbolZeroOrMore = symbolZeroOrMore;
                _symbolOneOrMore = symbolOneOrMore;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.ArgumentArityEnumTest()
                {
                    Zero = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Boolean>(_symbolZero, context),
                    ZeroOrOne = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Boolean>(_symbolZeroOrOne, context),
                    ExactlyOne = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Boolean>(_symbolExactlyOne, context),
                    ZeroOrMore = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Boolean>(_symbolZeroOrMore, context),
                    OneOrMore = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.Boolean>(_symbolOneOrMore, context)
                };
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}
