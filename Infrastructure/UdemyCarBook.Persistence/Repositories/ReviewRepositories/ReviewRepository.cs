﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.ReviewRepositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly CarBookContext _context;

		public ReviewRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<List<Review>> GetReviewsByCarId(int carId)
		{
			return await _context.Reviews.Where(x => x.CarID == carId).ToListAsync();
		}
	}
}
