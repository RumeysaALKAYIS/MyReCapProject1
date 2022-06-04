using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //GetCarsByBrandIdTest(2);
            // CarDetailTes();
            //AddTest();
            //Car car = new Car { CarId=10,CarName = "Passat", ModelYear = 2012, DailyPrice =1200 , Descriptions = "Fıstık Gibi Araba", BrandId = 2, ColorId = 3 };
            //UpdateTest(car);
            Car car = new Car { ModelYear= "2012", CarName = "Strogen",};
            UpdateTest(car);
            //DeleteTest(car);
            CarTest();
        }
        private static void DeleteTest(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Delete(car);
        }
        private static void UpdateTest(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(car);
        }
        private static void AddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car {  CarName = "Passat", ModelYear = "2012", DailyPrice = 25000, Descriptions = "Fıstık Gibi Araba" ,BrandId=2,ColorId=2};
            carManager.Add(car);
        }
        private static void CarDetailTes()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetailDto().Data)
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.CarName);
                Console.WriteLine(car.ColorName);
                Console.WriteLine(car.ModelYear);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.BrandName);
                Console.WriteLine("*********************");
            }
        }

        private static void GetCarsByBrandIdTest(int brandid)
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car1 in carManager1.GetCarsByBrandId(brandid).Data)
            {
                Console.WriteLine(car1.CarId);
                Console.WriteLine(car1.BrandId);
                Console.WriteLine(car1.CarName);
                Console.WriteLine(car1.ColorId);
                Console.WriteLine(car1.DailyPrice);
                Console.WriteLine(car1.Descriptions);
                Console.WriteLine("*********************");
            }
        }

        private static void CarTest()
        {
            CarManager carmanager = new CarManager(new EfCarDal());
            foreach (var car in carmanager.GetAll().Data)
            {
                Console.WriteLine(car.CarId);
                Console.WriteLine(car.BrandId);
                Console.WriteLine(car.CarName);
                Console.WriteLine(car.ColorId);
                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.Descriptions);
                Console.WriteLine("*********************");
            }
        }
    }
}
