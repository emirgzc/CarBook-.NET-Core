using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandler.Read
{
	public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarPricingWithCars();
			return values.Select(x => new GetCarPricingWithCarQueryResult
			{
				Amount = x.Amount,
				CarPricingID = x.CarPricingID,
				Brand = x.Car.Brand.BrandName,
				CoverImageUrl = x.Car.CoverImageUrl,
				Model = x.Car.Model,
				CarID = x.CarID
			}).ToList();
		}
	}
}
