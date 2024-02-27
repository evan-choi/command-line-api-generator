namespace System.CommandLine.SourceGenerator.Common;

public static class ValueDesriptorHelper
{
    public static T GetValueForHandlerParameter<T>(
        Binding.IValueDescriptor<T> symbol,
        Invocation.InvocationContext context)
    {
        return symbol switch
        {
            Binding.IValueSource valueSource when valueSource.TryGetValue(symbol, context.BindingContext, out var boundValue) && boundValue is T value => value,
            Option<T> option => context.ParseResult.RootCommandResult.GetValueForOption(option),
            Argument<T> argument => context.ParseResult.RootCommandResult.GetValueForArgument(argument),
            _ => throw new ArgumentOutOfRangeException(nameof(symbol))
        };
    }
}
