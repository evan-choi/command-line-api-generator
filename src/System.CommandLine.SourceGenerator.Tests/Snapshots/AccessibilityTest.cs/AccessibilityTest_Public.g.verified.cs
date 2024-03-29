﻿//HintName: AccessibilityTest_Public.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public class AccessibilityTest_PublicOptions
    {
        public ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.AccessibilityTest_Public> Handler { get; set; }
    }

    public static class AccessibilityTest_PublicFactory
    {
        public static global::System.CommandLine.RootCommand Create()
        {
            return Create(null);
        }

        public static global::System.CommandLine.RootCommand Create(AccessibilityTest_PublicOptions options)
        {
            ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.AccessibilityTest_Public> handler = null;
            if (options != null)
                handler = options.Handler;
            global::System.CommandLine.Invocation.ICommandHandler handlerAdapter = null;
            if (handler != null)
                handlerAdapter = new AccessibilityTest_PublicCommandHandlerAdapter(handler);
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = handlerAdapter
            };
            return cmd;
        }

        private sealed class AccessibilityTest_PublicCommandHandlerAdapter : global::System.CommandLine.Invocation.ICommandHandler
        {
            private readonly ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.AccessibilityTest_Public> _commandHandler;

            public AccessibilityTest_PublicCommandHandlerAdapter(ICommandHandler<global::System.CommandLine.SourceGenerator.Tests.AccessibilityTest_Public> commandHandler)
            {
                _commandHandler = commandHandler;
            }

            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.AccessibilityTest_Public();
                return _commandHandler.InvokeAsync(command);
            }
        }
    }
}
