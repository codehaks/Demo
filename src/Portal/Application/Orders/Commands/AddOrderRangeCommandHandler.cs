using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.Orders.Commands
{
    class AddOrderRangeCommandHandler : IRequestHandler<AddOrderRangeCommand, bool>
    {
        public Task<bool> Handle(AddOrderRangeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
