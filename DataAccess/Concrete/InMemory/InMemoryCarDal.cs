using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarId =1,CarName="Passat", ModelYear= "2012", DailyPrice=25000,Descriptions="Fıstık Gibi Araba"},
                new Car {CarId =2,CarName="Toyota", ModelYear= "2020", DailyPrice=125000,Descriptions="En İyi  Gibi Araba"},
                new Car {CarId =3,CarName="kıa", ModelYear= "2006", DailyPrice=25000,Descriptions="Boyasız Araba"},
                new Car {CarId =4, CarName="Doblo",ModelYear= "2003", DailyPrice=12000,Descriptions=" Azkullanılmıs Araba"},
                new Car {CarId =5, CarName="linea",ModelYear= "2015", DailyPrice=20000,Descriptions="cicek Gibi Araba"},
            };
        }

        public void Add(Car car)
        {
             _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }


        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByColorId()
        {
            throw new NotImplementedException();
        }

        public Car GetCarsByColorId(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }

        
    }
}
