using System.CommandLine.SourceGenerator.Common;
using System.Threading.Tasks;

namespace System.CommandLine.SourceGenerator.Tests;

// notnull

[RootCommand(Handler = typeof(GenericTest_notnull_CommandHandler<>))]
public class GenericTest_notnull<T> where T : notnull
{
}

public class GenericTest_notnull_CommandHandler<T> : ICommandHandler<GenericTest_notnull<T>> where T : notnull
{
    public Task<int> InvokeAsync(GenericTest_notnull<T> command)
    {
        throw new NotImplementedException();
    }
}

// struct

[RootCommand(Handler = typeof(GenericTest_struct_CommandHandler<>))]
public class GenericTest_struct<T> where T : struct
{
}

public class GenericTest_struct_CommandHandler<T> : ICommandHandler<GenericTest_struct<T>> where T : struct
{
    public Task<int> InvokeAsync(GenericTest_struct<T> command)
    {
        throw new NotImplementedException();
    }
}

// class

[RootCommand(Handler = typeof(GenericTest_class_CommandHandler<>))]
public class GenericTest_class<T> where T : class
{
}

public class GenericTest_class_CommandHandler<T> : ICommandHandler<GenericTest_class<T>> where T : class
{
    public Task<int> InvokeAsync(GenericTest_class<T> command)
    {
        throw new NotImplementedException();
    }
}

// unmanaged

[RootCommand(Handler = typeof(GenericTest_unmanaged_CommandHandler<>))]
public class GenericTest_unmanaged<T> where T : unmanaged
{
}

public class GenericTest_unmanaged_CommandHandler<T> : ICommandHandler<GenericTest_unmanaged<T>> where T : unmanaged
{
    public Task<int> InvokeAsync(GenericTest_unmanaged<T> command)
    {
        throw new NotImplementedException();
    }
}

// IDisposable, new()

[RootCommand(Handler = typeof(GenericTest_complex_CommandHandler<,>))]
public class GenericTest_complex<T, T2>
    where T : class, System.IDisposable, new() 
    where T2 : T
{
}

public class GenericTest_complex_CommandHandler<T, T2> : ICommandHandler<GenericTest_complex<T, T2>> 
    where T : class, System.IDisposable, new()
    where T2 : T
{
    public Task<int> InvokeAsync(GenericTest_complex<T, T2> command)
    {
        throw new NotImplementedException();
    }
}
