using AutoMapper;
using MediatR;
using Portal.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.Cities.Commands
{
    public class AddCityListCommandHandler : IRequestHandler<AddCityListCommand, int>
    {
        private readonly PortalDbContext _db;
        private readonly IMapper _mapper;

        public AddCityListCommandHandler(PortalDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddCityListCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
