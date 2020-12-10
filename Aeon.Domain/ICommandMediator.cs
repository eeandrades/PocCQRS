using MediatR;
using System.Threading.Tasks;

namespace Aeon.Domain
{
    public interface ICommandMediator
    {
        Task<TCommandResponse> SendCommand<TCommandResponse>(IRequest<TCommandResponse> command)
            where TCommandResponse : CommandResponse;
    }
}
