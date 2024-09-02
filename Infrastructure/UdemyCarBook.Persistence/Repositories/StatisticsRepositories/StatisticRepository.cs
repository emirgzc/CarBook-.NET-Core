using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var value = _context.Comments.GroupBy(x => x.BlogID).
                                    Select(y => new
                                    {
                                        blogID = y.Key,
                                        Count = y.Count()
                                    }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();

            string blogName = _context.Blogs.Where(x => x.BlogID == value.blogID).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }

        public string GetBrandNameByMaxCar()
        {
            var value = _context.Cars.GroupBy(x => x.BrandID).
                                    Select(y => new
                                    {
                                        BrandID = y.Key,
                                        Count = y.Count()
                                    }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();

            string brandName = _context.Brands.Where(x => x.BrandID == value.BrandID).Select(y => y.BrandName).FirstOrDefault();
            return brandName;
        }
        
        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingId).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.BrandName + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.BrandName + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            return _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForMothnly()
        {
            return _context.CarPricings.Where(w => w.PricingID ==
            (_context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault())
            ).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            return _context.CarPricings.Where(w => w.PricingID ==
            (_context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault())
            ).Average(x => x.Amount);
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelBenzinOrDizel()
        {
            return _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
        }

        public int GetCarCountByFuelElectric()
        {
            return _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            return _context.Cars.Where(x => x.Km <= 10000).Count();
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            return _context.Cars.Where(z => z.Transmission == "Otomatik").Count();
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
