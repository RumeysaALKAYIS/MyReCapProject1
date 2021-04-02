using Core.DataAccess.EntittyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        //public List<RentalDetailDto> GetRentalDetails()
        //{
        //    using (CarContext context =new CarContext())
        //    {
        //        var result = from cu in context.Customers
        //                     join r in context.Rentals
        //                     on cu.CustomerId equals r.CustomerId
        //                     join c in context.Cars on cu.CustomerId equals c.CustomerId
        //                     select new RentalDetailDto
        //                     {
        //                         CarId = c.CarId,
        //                         CustomerId = cu.CustomerId,
        //                         Descriptions = c.Descriptions,
        //                         RentalId = r.RentalId,
        //                         DailyPrice = c.DailyPrice,
        //                         RentDate = r.RentDate,
        //                         ReturnDate = r.ReturnDate
        //                     };
        //        return result.ToList();
                           
        //    }
        //}
    }
}
