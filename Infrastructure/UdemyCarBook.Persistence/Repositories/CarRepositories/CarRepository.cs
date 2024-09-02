using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepository
{
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _context;

		public CarRepository(CarBookContext context)
		{
			_context = context;
		}

        public int GetCarCount()
        {
			var value = _context.Cars.Count();
			return value;
        }

        public async Task<List<Car>> GetCarsListWithBrands()
		{
			var values = await _context.Cars.Include(x => x.Brand).ToListAsync();
			return values;
		}	

		public async Task<List<Car>> GetLastFiveCarsWithBrands()
		{
			var values = await _context.Cars.Include(x => x.Brand).OrderByDescending(z => z.CarID).Take(5).ToListAsync();
			return values;
		}
	}
}
