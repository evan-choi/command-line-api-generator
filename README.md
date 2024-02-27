[![NuGet](https://img.shields.io/nuget/v/Evan.System.CommandLine.Tools)](https://www.nuget.org/packages/Evan.System.CommandLine.Tools)

# System.CommandLine.Tools
Enhance your .NET CLI applications with dynamic command-line interface (CLI) capabilities using `System.CommandLine.Tools`. This package leverages the power of source generators to automatically create robust RootCommand code, simplifying the development of complex CLI tools.

## Getting Started

To incorporate `System.CommandLine.Tools` into your project, simply install the package via NuGet:

```powershell
Install-Package Evan.System.CommandLine.Tools
```

## Defining Commands

```csharp
[RootCommand(Handler = typeof(AppCommandHandler))]
class AppCommand
{
    [Option('v', "verbose", Required = false, Description = "Set output to verbose messages.")]
    public bool Verbose { get; set; }

    [Command("config")]
    class Config
    {
        [Command("get", Handler = typeof(ConfigGetCommandHandler))]
        class GetCommand
        {
            [Argument("key", Description = "The configuration key to retrieve.")]
            public string Key { get; set; }
        }
    }
}
```

## Implementing Command Handlers

Implement handlers for your commands to define the logic executed when commands are invoked:


```csharp
class AppCommandHandler : ICommandHandler<AppCommand>
{
    public Task<int> InvokeAsync(AppCommand command)
    {
        // Implementation logic here...
    }
}

class ConfigGetCommandHandler : ICommandHandler<AppCommand.Config.GetCommand>
{
    public Task<int> InvokeAsync(AppCommand.Config.GetCommand command)
    {
        // Implementation logic here...
    }
}
```

## Execution

Bootstrap and run your application by invoking the command handler from your program's entry point:


```csharp
static async Task Main(string[] args)
{
    Environment.ExitCode = await AppCommandExecutor.InvokeAsync(args);
}
```
