using Aeon.Domain;
using Sales.Queries.Finds;
using Sales.Repositories;
using System;
using System.Linq;


namespace Sales.Queries
{

    public class OrderQueryHandler : CommandHandler<OrderFindQueryFilter, Response<OrderFindQuery[]>>
    {
        private readonly IOrderRepository _repository;

        public OrderQueryHandler(IOrderRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected override Response<OrderFindQuery[]> DoExecute(OrderFindQueryFilter command)
        {
            var orders =
                this._repository.FindAll()
                .Where(o => !command.StartDate.HasValue || o.CreatedDateTime >= command.StartDate)
                .Where(o => !command.FinishDate.HasValue || o.CreatedDateTime <= command.FinishDate);

            var result = orders.Select(o => new OrderFindQuery()
            {

            }).ToArray();

            return new Response<OrderFindQuery[]>(result);
        }
    }
}
