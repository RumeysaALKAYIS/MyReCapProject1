using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();

            // BrandTest();

            // JoinTest();
        }

        //private static void JoinTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarDetailDto())
        //    {
        //        Console.WriteLine(car.BrandName + " marka araba " + car.ColorName + "  renginde " + car.DailyPrice + "  birim fiyattadır.");
        //    }
        //}

        //private static void BrandTest()
        //{
        //    CarManager carManager1 = new CarManager(new EfCarDal());
        //    foreach (var car1 in carManager1.GetCarsByBrandId(2))
        //    {
        //        Console.WriteLine(car1.BrandId + "   /   " + car1.Descriptions);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarManager carmanager = new CarManager(new EfCarDal());
        //    foreach (var car in carmanager.GetAll())
        //    {
        //        Console.WriteLine(car.CarId);
        //    }
        //}
    }
}
