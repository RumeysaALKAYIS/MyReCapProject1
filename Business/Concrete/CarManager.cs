using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
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

        

        

        public IDataResult< List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Mesages.MaintenansTime);
            }
            return new SuccessDataResult<List<Car>>(_icarDal.GetAll(), Mesages.Listed);
        }

        public IDataResult< List<CarDetailDto>> GetCarDetailDto()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_icarDal.GetCarDetails());
        }

        public IDataResult< List<Car>> GetCarsByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Car>>( _icarDal.GetAll(c=>c.BrandId==brandid));
        }

        public IDataResult< List<Car>> GetCarsByColorId(int colorid)
        {
            return new SuccessDataResult<List<Car>>( _icarDal.GetAll(c => c.ColorId == colorid));
        }

    }
}
