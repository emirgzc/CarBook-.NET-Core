using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.BlogDtos
{
	public class CreateBlogDto
	{
		public string Title { get; set; }
		public int AuthorID { get; set; }
		public string CoverImageUrl { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public int CategoryID { get; set; }
	}
}
