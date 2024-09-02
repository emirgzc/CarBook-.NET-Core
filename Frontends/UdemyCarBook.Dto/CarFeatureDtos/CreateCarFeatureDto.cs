using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Dto.FeatureDtos;

namespace UdemyCarBook.Dto.CarFeatureDtos
{
    public class CreateCarFeatureDto
    {
        public List<ResultFeatureWithStatusDto> Features { get; set; }
        public int CarID { get; set; }
    }
}
