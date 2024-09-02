using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<List<CarPricing>> GetCarPricingWithCars()
		{
			var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(z => z.PricingID == 3).ToListAsync();
			return values;
		}

		public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod()
		{
			var query = from carPricing in _context.CarPricings
						join car in _context.Cars on carPricing.CarID equals car.CarID
						join brand in _context.Brands on car.BrandID equals brand.BrandID
						select new
						{
							car.Model,
							carPricing.PricingID,
							carPricing.Amount,
							car.CoverImageUrl,
							brand.BrandName
						};

			var data = await query.ToListAsync();
			var pivotData = data
				.GroupBy(d => new { d.BrandName, d.CoverImageUrl, d.Model })
				.Select(g => new CarPricingViewModel
				{
					Model = g.Key.Model,
					BrandName = g.Key.BrandName,
					CoverImageUrl = g.Key.CoverImageUrl,
					Amounts = g.OrderBy(x => x.PricingID)
							   .Select(x => x.Amount)
							   .ToList()
				})
				.ToList();
			return pivotData;
		}
	}
}
