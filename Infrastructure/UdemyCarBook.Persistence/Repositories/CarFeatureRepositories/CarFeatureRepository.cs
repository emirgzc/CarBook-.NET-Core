using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarFeatureRepositories
{
	public class CarFeatureRepository : ICarFeatureRepository
	{
		private readonly CarBookContext _context;

		public CarFeatureRepository(CarBookContext context)
		{
			_context = context;
		}

		public void ChangeCarFeatureAvailableToFalse(int id)
		{
			var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
			values.Available = false;
			_context.SaveChanges();
		}

		public async void ChangeCarFeatureAvailableToTrue(int id)
		{
			var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
			values.Available = true;
			_context.SaveChanges();
		}

        public async Task CreateCarFeatureByCar(CarFeature carFeature)
        {
			var value = await _context.CarFeatures.Where(x => x.CarID == carFeature.CarID && x.FeatureID == carFeature.FeatureID).FirstOrDefaultAsync();
			if (value is null)
			{
				await _context.CarFeatures.AddAsync(carFeature);
				await _context.SaveChangesAsync();
			}
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarId(int carID)
		{
			return await _context.CarFeatures.Include(c => c.Feature).Where(x => x.CarID == carID).ToListAsync();
		}

    }
}
