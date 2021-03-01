using DataAccess.Abstract;
using Entities.Concrete;
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
                new Car {Id =1, ModelYear= 2012, DailyPrice=25000,Description="Fıstık Gibi Araba"},
                new Car {Id =2, ModelYear= 2020, DailyPrice=125000,Description="En İyi  Gibi Araba"},
                new Car {Id =3, ModelYear= 2006, DailyPrice=25000,Description="Boyasız Araba"},
                new Car {Id =4, ModelYear= 2003, DailyPrice=12000,Description=" Azkullanılmıs Araba"},
                new Car {Id =5, ModelYear= 2015, DailyPrice=20000,Description="cicek Gibi Araba"},
            };
        }

        public void Add(Car car)
        {
             _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.Id==car.Id);
            _cars.Remove(carToDelete);
        }


        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.Id == carId).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
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
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        List<Car> IEntityRepository<Car>.GetAll(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
