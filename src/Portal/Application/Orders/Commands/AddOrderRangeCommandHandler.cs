using MediatR;
using Portal.Domain.Entities;
using Portal.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.Orders.Commands
{
    class AddOrderRangeCommandHandler : IRequestHandler<AddOrderRangeCommand, bool>
    {
        private readonly PortalDbContext _portalDbContext;
        public AddOrderRangeCommandHandler(PortalDbContext portalDbContext)
        {
            _portalDbContext = portalDbContext;
        }
        public async Task<bool> Handle(AddOrderRangeCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Orders)
            {

                var cityId = 0;
                var productId = 0;

                var order = new Order
                {
                    CustomerName = item.CustomerName,
                    CityId = cityId,
                    ProductId = productId
                };

                _portalDbContext.Add(order);
            }

            await _portalDbContext.SaveChangesAsync();

            return true;
        }
    }
}
