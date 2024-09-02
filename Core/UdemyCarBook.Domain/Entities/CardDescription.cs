using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class CardDescription
    {
        public int CardDescriptionID { get; set; }
        public string Details { get; set; }
		[ForeignKey("Car")]
		public int CardID { get; set; }
        public Car Car { get; set; }
    }
}
