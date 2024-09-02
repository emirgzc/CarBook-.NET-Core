using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.BlogRepositories
{
	public class BlogRepository : IBlogRepository
	{
		private readonly CarBookContext _context;

		public BlogRepository(CarBookContext context)
		{
			_context = context;
		}

        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).Include(z=>z.Category).OrderByDescending(z => z.CreatedDate).ToListAsync();
            return values;
        }

		public async Task<List<Blog>> GetBlogByAuthorId(int id)
		{
			var values = await _context.Blogs.Include(x => x.Author).OrderByDescending(z => z.CreatedDate).Where(y => y.BlogID == id).ToListAsync();
			return values;
		}

		public async Task<List<Blog>> GetLastThreeBlogsWithAuthors()
		{
			var values = await _context.Blogs.Include(x => x.Author).OrderByDescending(z => z.CreatedDate).Take(3).ToListAsync();
			return values;
		}
	}
}
