using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.RentACarQueries;
using UdemyCarBook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.RentACarHandler
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{
		private readonly IRentACarRepository _repository;

		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByFilterAsync(x => x.PickUpLocationID == request.LocationID && x.Available == request.Available);
			return values.Select(x => new GetRentACarQueryResult
			{
				CarID = x.CarID,
				BrandName = x.Car.Brand.BrandName,
				Model = x.Car.Model,
				CoverImageUrl = x.Car.CoverImageUrl
			}).ToList();
		}
	}
}
