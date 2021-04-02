using Core.DataAccess.EntittyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context =new CarContext())
            {
                var result = from c in context.Cars 
                             join b in context.Brands 
                             on c.CarId equals b.BrandId
                             join co in context.Colors
                             on c.CarId equals co.ColorId
                             select new CarDetailDto
                {
                    CarId = c.CarId,
                    ColorName=co.ColorName,
                    BrandName=b.BrandName,
                    CarName=c.CarName,
                    DailyPrice=c.DailyPrice
                };
                return result.ToList();
            }
        }
    }
}
