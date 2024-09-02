using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.RentACarDtos
{
	public class FilterRentACarDto
	{
        public int carID { get; set; }
		public string brandName { get; set; }
		public string model { get; set; }
		public string coverImageUrl { get; set; }
		public decimal amount { get; set; }
	}
}
