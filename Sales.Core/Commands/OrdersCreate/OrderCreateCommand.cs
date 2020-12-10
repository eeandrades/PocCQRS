using Aeon.Domain;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Sales.Commands.OrdersCreate
{
    public class OrderCreateCommand : Command
    {
        public Guid OrderId { get; init; }
        public Guid CustumerId { get; init; }
        public DateTime Date { get; set; }
        public IEnumerable<OrderDetailCommand> Details { get; init; } = new OrderDetailCommand[0];
        protected override ValidationResult DoValidate() => new OrderCreateCommandValidator().Validate(this);
    }
}
