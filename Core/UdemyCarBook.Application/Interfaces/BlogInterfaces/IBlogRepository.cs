using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.BlogInterfaces
{
	public interface IBlogRepository
	{
		Task<List<Blog>> GetLastThreeBlogsWithAuthors();
		Task<List<Blog>> GetAllBlogsWithAuthors();
		Task<List<Blog>> GetBlogByAuthorId(int id);
	}
}
