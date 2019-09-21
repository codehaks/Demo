using AutoMapper;
using MediatR;
using Portal.Domain.Entities;
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
        //private readonly IMapper _mapper;

        public AddCityListCommandHandler(PortalDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(AddCityListCommand request, CancellationToken cancellationToken)
        {
            foreach (var name in request.CityNames)
            {
                _db.Cities.Add(new City { Name = name });
            }

            await _db.SaveChangesAsync();
            return 1;
        }
    }
}
