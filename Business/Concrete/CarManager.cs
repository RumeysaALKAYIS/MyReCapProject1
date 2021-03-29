using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _icarDal;
        public CarManager(ICarDal iCarDal)
        {
            _icarDal = iCarDal;
        }

        

        

        public List<Car> GetAll()
        {
            return _icarDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetailDto()
        {
            return _icarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandid)
        {
            return _icarDal.GetAll(c=>c.BrandId==brandid);
        }

        public List<Car> GetCarsByColorId(int colorid)
        {
            return _icarDal.GetAll(c => c.ColorId == colorid);
        }

    }
}
