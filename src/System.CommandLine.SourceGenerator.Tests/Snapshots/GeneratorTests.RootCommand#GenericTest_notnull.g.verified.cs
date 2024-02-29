﻿//HintName: GenericTest_notnull.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public static class GenericTest_notnullFactory
    {
        public static global::System.CommandLine.RootCommand Create<T>() where T : notnull
        {
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = new GenericTest_notnullCommandHandler<T>()
            };
            return cmd;
        }

        private sealed class GenericTest_notnullCommandHandler<T> : global::System.CommandLine.Invocation.ICommandHandler where T : notnull
        {
            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_notnull<T>();
                var handler = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_notnull_CommandHandler<T>();
                return handler.InvokeAsync(command);
            }
        }
    }
}
