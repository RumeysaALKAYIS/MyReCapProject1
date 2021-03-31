using Core.DataAccess.EntittyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarContext>, IBrandDal
    {
        public List<BrandDetailDto> GetBrandDetails()
        {
            using (CarContext context=new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new BrandDetailDto
                             {
                                 BrandId = b.BrandId,
                                 CarId=c.CarId,
                                 Descriptions=c.Descriptions,
                                 BrandName=b.BrandName,
                                 CarName= c.CarName
                                 

                             };
                return result.ToList();
            }
        }
    }
}
