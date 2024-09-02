using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class RentACar
    {
        public int RentACarID { get; set; }
        [ForeignKey("Location")]
        public int PickUpLocationID { get; set; }
        public Location Location { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public bool Available { get; set; }
    }
}
