using System.Threading.Tasks;

namespace System.CommandLine.SourceGenerator.Common;

public interface ICommandHandler<in TCommand>
{
    Task<int> InvokeAsync(TCommand command);
}
