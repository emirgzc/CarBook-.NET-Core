using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarDescriptionDtos
{
	public class ResultCarDescriptionByCarIdDto
	{
		public int CardDescriptionID { get; set; }
		public string Details { get; set; }
		public int CardID { get; set; }
	}
}
