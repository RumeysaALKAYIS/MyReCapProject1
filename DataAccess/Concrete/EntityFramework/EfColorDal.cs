using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (CarContext carContext=new CarContext())
            {
                var addedEntity = carContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (CarContext carContext =new CarContext())
            {
                var deletedEntity = carContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                carContext.SaveChanges();
            }
        }       

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            using (CarContext carContext =new CarContext())
            {
                return carContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        

        public Color GetCarsByColorId(Expression<Func<Color, bool>> filter)
        {
            using(CarContext carContext = new CarContext())
            {
                return carContext.Set<Color>().SingleOrDefault(filter);
            }
        }

        public void Update(Color entity)
        {
            using (CarContext carContext =new CarContext())
            {
                var updatedEntity = carContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }

       List<Color> IEntityRepository<Color>.GetAll(Expression<Func<Color, bool>> filter)
        {
            using (CarContext carContext=new CarContext())
            {
                return filter == null
                    ? carContext.Set<Color>().ToList()
                    : carContext.Set<Color>().Where(filter).ToList();
            }
                
        }
    }
}
