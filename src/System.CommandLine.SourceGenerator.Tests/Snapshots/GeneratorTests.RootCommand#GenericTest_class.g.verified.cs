﻿//HintName: GenericTest_class.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public static class GenericTest_classFactory
    {
        public static global::System.CommandLine.RootCommand Create<T>() where T : class
        {
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = new GenericTest_classCommandHandler<T>()
            };
            return cmd;
        }

        private sealed class GenericTest_classCommandHandler<T> : global::System.CommandLine.Invocation.ICommandHandler where T : class
        {
            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_class<T>();
                var handler = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_class_CommandHandler<T>();
                return handler.InvokeAsync(command);
            }
        }
    }
}
