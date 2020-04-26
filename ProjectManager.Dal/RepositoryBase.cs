using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using ProjectManager.Model;
using ProjectManager.Model.Exceptions;

namespace ProjectManager.Dal
{
    abstract class RepositoryBase<EntityType> : IRepository<EntityType>
        where EntityType : class, IEntity
    {
        protected readonly ProjectManagerContext dbContext;

        protected RepositoryBase(ProjectManagerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(EntityType entity)
        {
            dbContext.Set<EntityType>().Add(entity);
        }

        public void Delete(EntityType entity)
        {
            var entry = dbContext.Entry(entity);
            if (entry?.State == EntityState.Detached)
            {
                dbContext.Set<EntityType>().Attach(entity);
            }
            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(int id)
        {
            var entity = dbContext.Set<EntityType>().Find(id);
            if (entity == null)
                throw new EntityNotFoundException();

            dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public EntityType Get(int id)
        {
            var entity = dbContext.Set<EntityType>().Find(id);
            if (entity != null)
            {
                var entry = dbContext.Entry(entity);
                if (entry != null && entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Detached;
                }
            }
            return entity;
        }

        public IQueryable<EntityType> Query(params Expression<Func<EntityType, object>>[] includes)
        {
            IQueryable<EntityType> query = dbContext.Set<EntityType>().AsNoTracking();
            for (int i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]);
            }

            return query;
        }

        public void Update(EntityType entity, EntityType modifiedEntity)
        {
            var entry = dbContext.Entry(entity);
            if (entry?.State == EntityState.Detached)
            {
                dbContext.Set<EntityType>().Attach(entity);
                dbContext.Entry(entity).CurrentValues.SetValues(modifiedEntity);
            }
            else
            {
                entry.CurrentValues.SetValues(modifiedEntity);
            }
        }

        public void Update(int id, EntityType modifiedEntity, params Expression<Func<EntityType, object>>[] excludes)
        {
            var entity = dbContext.Set<EntityType>().Find(id);
            if (entity == null)
                throw new EntityNotFoundException();

            var entry = dbContext.Entry(entity);
            entry.CurrentValues.SetValues(modifiedEntity);

            var entryAgain = this.dbContext.Entry(entity);
            foreach (var exclude in excludes)
            {
                entryAgain.Property(exclude).IsModified = false;
            }
        }
    }
}
