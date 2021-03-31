using Business.Abstract;
using Business.Constant;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return  new SuccessResult( Mesages.Added);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Mesages.Deleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Mesages.Listed);
        }

        public IDataResult<List<BrandDetailDto>> GetBrandDetail()
        {
            return new SuccessDataResult<List<BrandDetailDto>>(_brandDal.GetBrandDetails());
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandId==0)
            {
                return new ErrorResult(Mesages.NotUpdated);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Mesages.Updated);
        }
    }
}
