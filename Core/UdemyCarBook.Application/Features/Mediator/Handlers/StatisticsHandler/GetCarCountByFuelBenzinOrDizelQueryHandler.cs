using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticsHandler
{
    public class GetCarCountByFuelBenzinOrDizelQueryHandler : IRequestHandler<GetCarCountByFuelBenzinOrDizelQuery, GetCarCountByFuelBenzinOrDizelQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelBenzinOrDizelQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelBenzinOrDizelQueryResult> Handle(GetCarCountByFuelBenzinOrDizelQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelBenzinOrDizel();
            return new GetCarCountByFuelBenzinOrDizelQueryResult
            {
                GetCarCountByFuelBenzinOrDizel = value
            };
        }
    }
}
