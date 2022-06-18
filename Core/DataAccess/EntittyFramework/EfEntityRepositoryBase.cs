
using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntittyFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class ,IEntity, new()
        where TContext:DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var addedEntity = carContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                carContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var deletedEntity = carContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                carContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext carContext = new TContext())
            {
                return carContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public TEntity GetCarsByColorId(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext carContext = new TContext())
            {
                return carContext.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext carContext = new TContext())
            {
                var updateEntity = carContext.Entry(entity);
                updateEntity.State = EntityState.Modified;
                carContext.SaveChanges();
            }
        }
    }
}
