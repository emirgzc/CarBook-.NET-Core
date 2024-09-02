using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int getCarCount { get; set; }
        public int getLocationCount { get; set; }
        public int getAuthorCount { get; set; }
        public int getBlogCount { get; set; }
        public int getBrandCount { get; set; }
        public decimal getAvgRentPriceForDaily { get; set; }
        public decimal getAvgRentPriceForWeekly { get; set; }
        public decimal getAvgRentPriceForMothnly { get; set; }
        public int getCarCountByTransmissionIsAuto { get; set; }
        public string brandNameByMaxCar { get; set; }
        public string blogTitleByMaxBlogComment { get; set; }
        public int getCarCountByKmSmallerThan1000 { get; set; }
        public int getCarCountByFuelBenzinOrDizel { get; set; }
        public int getCarCountByFuelElectric { get; set; }
        public string getCarBrandAndModelByRentPriceDailyMax { get; set; }
        public string getCarBrandAndModelByRentPriceDailyMin { get; set; }
    }
}
