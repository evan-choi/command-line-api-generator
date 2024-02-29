﻿//HintName: GenericTest_unmanaged.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public static class GenericTest_unmanagedFactory
    {
        public static global::System.CommandLine.RootCommand Create<T>() where T : unmanaged
        {
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = new GenericTest_unmanagedCommandHandler<T>()
            };
            return cmd;
        }

        private sealed class GenericTest_unmanagedCommandHandler<T> : global::System.CommandLine.Invocation.ICommandHandler where T : unmanaged
        {
            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_unmanaged<T>();
                var handler = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_unmanaged_CommandHandler<T>();
                return handler.InvokeAsync(command);
            }
        }
    }
}
