using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _icarDal;
        public CarManager(ICarDal iCarDal)
        {
            _icarDal = iCarDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _icarDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _icarDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult< List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenansTime);
            }
            return new SuccessDataResult<List<Car>>(_icarDal.GetAll(), Messages.Listed);
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

        public IResult Update(Car car)
        {
            _icarDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
