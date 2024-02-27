﻿//HintName: StubSubSub.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public static class StubSubSubFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            var symbol = new global::System.CommandLine.Option<global::System.String>("-A", null);
            var symbol1 = new global::System.CommandLine.Option<global::System.String>("-B", null);
            var cmd = new global::System.CommandLine.Command("sub2", null)
            {
                Handler = new StubSubSubCommandHandler(symbol, symbol1)
            };
            cmd.AddOption(symbol);
            cmd.AddOption(symbol1);
            return cmd;
        }

        private sealed class StubSubSubCommandHandler : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.String> _symbolA;
            private readonly global::System.CommandLine.Binding.IValueDescriptor<global::System.String> _symbolB;

            public StubSubSubCommandHandler(
                global::System.CommandLine.Binding.IValueDescriptor<global::System.String> symbolA,
                global::System.CommandLine.Binding.IValueDescriptor<global::System.String> symbolB)
            {
                _symbolA = symbolA;
                _symbolB = symbolB;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.Stub.StubSub.StubSubSub()
                {
                    A = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.String>(_symbolA, context),
                    B = ValueDesriptorHelper.GetValueForHandlerParameter<global::System.String>(_symbolB, context)
                };
                var handler = new global::System.CommandLine.SourceGenerator.Tests.StubSubSubHandler();
                return handler.InvokeAsync(command);
            }
        }
    }
}
