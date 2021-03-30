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
        //void Add(Car car);
        //void İnsert(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        
        IDataResult< List<Car>> GetAll();
        IDataResult< List<Car>> GetCarsByBrandId(int brandid);
        IDataResult< List<Car>> GetCarsByColorId(int colorid);
        IDataResult< List<CarDetailDto>> GetCarDetailDto();

    }
}
