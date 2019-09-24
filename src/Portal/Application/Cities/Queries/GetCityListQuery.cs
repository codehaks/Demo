using MediatR;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Cities.Queries
{
    public class GetCityListQuery:IRequest<IList<City>>
    {
    }
}
