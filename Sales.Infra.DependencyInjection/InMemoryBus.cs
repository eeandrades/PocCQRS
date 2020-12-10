using Aeon.Domain;
using MediatR;
using System.Threading.Tasks;

namespace Sales.Infra.DependencyInjection
{
    public sealed class InMemoryBus : ICommandMediator
    {
        private readonly IMediator _mediator;
        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        async Task<TCommandResponse> ICommandMediator.SendCommand<TCommandResponse>(IRequest<TCommandResponse> command)
        {
            return await this._mediator.Send<TCommandResponse>(command);
        }
    }
}