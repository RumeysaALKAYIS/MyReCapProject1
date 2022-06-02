using Business.Abstract;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carımageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carımageDal = carImageDal;
        }

        public IResult AddImage(CarImage carImage, IFormFile file)
        {
            carImage.Date = DateTime.Now;

            IResult result = BusinessRules.Run(CheckCountCarimage(carImage));
            if (result != null)
            {
                return result;
            }

            var filAdded = _fileHelper.Add(file);
            if (!filAdded.Success)
            {
                return new ErrorResult();
            }
            _carımageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult DeleteImage(CarImage carImageId)
        {
            IResult result = BusinessRules.Run(CheckImageNull(carImageId));
            if (result != null)
            {
                return result;
            }
            _carımageDal.Delete(carImageId);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carımageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            return new SuccessDataResult<List<CarImage>>();
        }

        public IResult UbdateImage(CarImage carImage, IFormFile file)
        {
            var image = _carımageDal.GetAll(c => c.CarId == carImage.CarId);
            if (image == null)
            {
                return new ErrorResult();
            }
            var updatefile = _fileHelper.Update(file, carImage.ImagePath);
            if (!updatefile.Success)
            {
                return new ErrorResult();
            }
            _carımageDal.Update(carImage);
            return new SuccessResult();

        }

        private IResult CheckCountCarimage(CarImage carImage)
        {
            var ImageCount = _carımageDal.GetAll(c => c.CarId == carImage.CarId).Count;
            if (ImageCount <= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckImageNull(CarImage carImage)
        {
            var imageId = _carımageDal.GetAll(c => c.CarImageId == carImage.CarImageId);
            if (imageId == null)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string defaultpath = @"\images\logo.jpg";
                var result = _carımageDal.GetAll(c => c.CarId == carId).Any();
                if (result)
                {

                    return new SuccessDataResult<List<CarImage>>(_carımageDal.GetAll(i => i.CarId == carId));
                }
                else
                {
                    List<CarImage> defaulthImage = new List<CarImage>();
                    defaulthImage.Add(new CarImage { CarId = carId, ImagePath = defaultpath, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(defaulthImage);
                }
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<CarImage>>();
            }

           
        }
        
    }

       
    }

