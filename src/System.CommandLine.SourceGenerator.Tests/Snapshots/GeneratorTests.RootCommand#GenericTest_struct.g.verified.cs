﻿//HintName: GenericTest_struct.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public static class GenericTest_structFactory
    {
        public static global::System.CommandLine.RootCommand Create<T>() where T : struct
        {
            var cmd = new global::System.CommandLine.RootCommand("")
            {
                Handler = new GenericTest_structCommandHandler<T>()
            };
            return cmd;
        }

        private sealed class GenericTest_structCommandHandler<T> : global::System.CommandLine.Invocation.ICommandHandler where T : struct
        {
            public int Invoke(global::System.CommandLine.Invocation.InvocationContext context)
            {
                return InvokeAsync(context).Result;
            }

            public global::System.Threading.Tasks.Task<int> InvokeAsync(global::System.CommandLine.Invocation.InvocationContext context)
            {
                var command = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_struct<T>();
                var handler = new global::System.CommandLine.SourceGenerator.Tests.GenericTest_struct_CommandHandler<T>();
                return handler.InvokeAsync(command);
            }
        }
    }
}
