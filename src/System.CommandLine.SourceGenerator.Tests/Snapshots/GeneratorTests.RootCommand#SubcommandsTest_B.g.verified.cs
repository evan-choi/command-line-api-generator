﻿//HintName: SubcommandsTest_B.g.cs
// <auto-generated/>
using global::System.CommandLine.SourceGenerator.Common;

namespace System.CommandLine.SourceGenerator.Tests
{
    public static class SubcommandsTest_BFactory
    {
        public static global::System.CommandLine.Command Create()
        {
            var symbol = new global::System.CommandLine.Option<global::System.Int32>("--option3", null);
            var cmd = new global::System.CommandLine.Command("B", null);
            cmd.AddOption(symbol);
            return cmd;
        }
    }
}