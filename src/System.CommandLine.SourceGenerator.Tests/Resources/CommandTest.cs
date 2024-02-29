using System.CommandLine.SourceGenerator.Common;
using System.Threading.Tasks;

namespace System.CommandLine.SourceGenerator.Tests;

[Command(
    "Name",
    "Description",
    TreatUnmatchedTokensAsErrors = true,
    Aliases = new[] { "Aliases" },
    Handler = typeof(CommandTest_Full_Handler),
    IsHidden = true,
    Subcommands = new[] { typeof(CommandTest_Simple) }
)]
public class CommandTest_Full
{
}

[Command("Name")]
public class CommandTest_Simple
{
}

public class CommandTest_Full_Handler : ICommandHandler<CommandTest_Full>
{
    public Task<int> InvokeAsync(CommandTest_Full command)
    {
        throw new NotImplementedException();
    }
}
