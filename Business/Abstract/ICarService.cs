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
        
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandid);
        List<Car> GetCarsByColorId(int colorid);
        List<CarDetailDto> GetCarDetailDto();

    }
}
