using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces.CarInterfaces;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandler.Read
{
	public class GetLastFiveCarWithBrandQueryHandler
	{
		private readonly ICarRepository _repository;

		public GetLastFiveCarWithBrandQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLastFiveCarsWithBrandQueryResults>> Handle()
		{
			var values = await _repository.GetLastFiveCarsWithBrands();
			return values.Select(x => new GetLastFiveCarsWithBrandQueryResults
			{
				BrandID = x.BrandID,
				BigImageUrl = x.BigImageUrl,
				CarID = x.CarID,
				CoverImageUrl = x.CoverImageUrl,
				Fuel = x.Fuel,
				Km = x.Km,
				Luggage = x.Luggage,
				Model = x.Model,
				Seat = x.Seat,
				Transmission = x.Transmission,
				BrandName = x.Brand.BrandName,
			}).ToList();
		}
	}
}
