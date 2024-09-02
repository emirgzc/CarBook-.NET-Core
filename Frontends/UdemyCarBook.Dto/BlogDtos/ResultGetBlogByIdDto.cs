using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.BlogDtos
{
	public class ResultGetBlogByIdDto
	{
		public int blogID { get; set; }
		public string title { get; set; }
		public int authorID { get; set; }
		public string coverImageUrl { get; set; }
		public DateTime createdDate { get; set; }
		public int categoryID { get; set; }
		public string Description { get; set; }
	}
}
