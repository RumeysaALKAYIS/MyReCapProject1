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
    public class ColorManager : IColorService
    {
        IColorDal _icolorDal;
        public ColorManager(IColorDal colorDal)
        {
            _icolorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            if (color.ColorId==0)
            {
                return new ErrorResult(Mesages.NotAdded);
            }
            _icolorDal.Add(color);
            return new SuccessResult(Mesages.Added);
        }

        public IResult Deleted(Color color)
        {
            _icolorDal.Delete(color);
            return new SuccessResult(Mesages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_icolorDal.GetAll(),Mesages.Listed);
        }

        public IDataResult<List<Color>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>(_icolorDal.GetAll(c => c.ColorId == id));
        }

        public IResult Updated(Color color)
        {
            _icolorDal.Update(color);
            return new  SuccessResult();
        }
    }
}
