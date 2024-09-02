using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarPricingInterfaces
{
	public interface ICarPricingRepository
	{
		Task<List<CarPricing>> GetCarPricingWithCars();
		Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod();
	}
}
