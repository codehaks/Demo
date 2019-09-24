using MediatR;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using Portal.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portal.Application.Cities.Queries
{
    public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, IList<City>>
    {
        private readonly PortalDbContext _db;
        public GetCityListQueryHandler(PortalDbContext db)
        {
            _db = db;
        }
        public async Task<IList<City>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
        {
            return await _db.Cities.ToListAsync();
        }
    }
}
