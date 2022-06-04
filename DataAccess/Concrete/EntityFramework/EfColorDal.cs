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
    public class EfColorDal : EfEntityRepositoryBase<Color, CarContext>, IColorDal
    {
        public List<ColorDetailDto> GetColorDetail()
        {
            using (CarContext context = new CarContext()) 
            {
                var result = from c in context.Cars
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new ColorDetailDto
                             {
                                 CarId = c.CarId,
                                 ColorId = co.ColorId,
                                 ColorName=co.ColorName,
                                 Descriptions=c.Descriptions,
                                 //ModelYear=Convert.ToInt38( c.ModelYear)
                             };
                return result.ToList();

            }
        }
    }
}
