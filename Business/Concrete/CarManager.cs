using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>2)
            {
                 _icarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Eklediginiz araba ismi ve fiyati olmalidir!!");
            }
        }

       

        public List<Car> GetAll()
        {
            return _icarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int Brandid)
        {
            return _icarDal.GetAll();
        }

        public List<Car> GetCarsByColorId(int Colorid)
        {
            throw new NotImplementedException();
        }

        
    }
}
