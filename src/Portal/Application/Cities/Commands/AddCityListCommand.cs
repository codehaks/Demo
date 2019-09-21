using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Cities.Commands
{
    public class AddCityListCommand : IRequest<int>
    {
        public IList<string> CityNames { get; set; }
    }
}
