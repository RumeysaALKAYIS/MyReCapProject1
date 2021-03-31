using Core.DataAccess.EntittyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (CarContext context=new CarContext())
            {
                var result = from c in context.Cars
                             join cu in context.Customers
                             on c.CustomerId equals cu.CustomerId
                             select new CustomerDetailDto
                             {
                                 CarId = c.CarId,
                                 CustomerId = cu.CustomerId,
                                 CompanyName = cu.CompanyName,
                             }; 
                return result.ToList();
            }
            
            
        }
    }
}
