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
    public class GetAvgRentPriceForMothnlyQueryHandler : IRequestHandler<GetAvgRentPriceForMothnlyQuery, GetAvgRentPriceForMothnlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForMothnlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForMothnlyQueryResult> Handle(GetAvgRentPriceForMothnlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForMothnly();
            return new GetAvgRentPriceForMothnlyQueryResult
            {
                GetAvgRentPriceForMothnly = value
            };
        }
    }
}
