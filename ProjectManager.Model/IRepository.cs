using System;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManager.Model
{
    public interface IRepository<EntityType>
        where EntityType : class, IEntity
    {
        void Create(EntityType entity);
        void Update(EntityType entity, EntityType modifiedEntity);
        void Update(int id, EntityType modifiedEntity, params Expression<Func<EntityType, object>>[] excludes);
        void Delete(EntityType entity);
        void Delete(int id);


        EntityType Get(int id);
        IQueryable<EntityType> Query(params Expression<Func<EntityType, object>>[] includes);
    }
}
