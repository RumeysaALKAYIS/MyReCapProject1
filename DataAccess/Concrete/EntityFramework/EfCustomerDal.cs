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
       
    }
}
