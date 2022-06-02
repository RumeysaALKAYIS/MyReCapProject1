using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddImage(CarImage carImage, IFormFile file);
        IResult UbdateImage(CarImage carImage, IFormFile file);
        IResult DeleteImage(CarImage carImageId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
       
    }
}
