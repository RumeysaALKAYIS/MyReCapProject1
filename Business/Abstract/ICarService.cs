using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        
        IDataResult< List<Car>> GetAll();
        IDataResult< List<Car>> GetCarsByBrandId(int brandid);
        IDataResult< List<Car>> GetCarsByColorId(int colorid);
        IDataResult< List<CarDetailDto>> GetCarDetailDto();

    }
}
