﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int Brandid);
        List<Car> GetCarsByColorId(int Colorid);

    }
}
