using Dish_Discovery.Data.Sorting;
using Dish_Discovery.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dish_Discovery.Data.Repositories
{
public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly Dish_DbContext _dbContext;

        public Repository(Dish_DbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Add(entity);
            this._dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Update(entity);
            this._dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            this._dbContext.Set<TEntity>().Remove(entity);
            this._dbContext.SaveChanges();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> filter)
        {
            return this._dbContext.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public TProjection? Get<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection)
        {
            return this._dbContext.Set<TEntity>().Where(filter).Select(projection).FirstOrDefault();
        }

        public TEntity? GetComplete(Expression<Func<TEntity, bool>> filter)
        {
            IEntityType? entityType = this._dbContext.Model.FindEntityType(typeof(TEntity));
            if (entityType is null) throw new InvalidOperationException("Invalid entity type.");

            IEnumerable<string> navigations = entityType.GetNavigations().Select(x => x.Name)
                .Concat(entityType.GetSkipNavigations().Select(x => x.Name));

            return this.GetWithNavigations(filter, navigations);
        }

        public TEntity? GetWithNavigations(Expression<Func<TEntity, bool>> filter, IEnumerable<string> navigations)
        {
            IQueryable<TEntity> query = this._dbContext.Set<TEntity>().Where(filter);

            foreach (string navigation in navigations)
                query = query.Include(navigation);

            return query.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter)
        {
            return this._dbContext.Set<TEntity>().Where(filter).ToList();
        }

        public IEnumerable<TProjection> GetMany<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection)
        {
            return this._dbContext.Set<TEntity>().Where(filter).Select(projection).ToList();
        }

        public IEnumerable<TProjection> GetMany<TProjection>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TProjection>> projection, IEnumerable<IOrderClause<TEntity>> orderClauses)
        {
                return this._dbContext.Set<TEntity>().Where(filter).OrderBy(orderClauses).Select(projection).ToList();
        }
    }
}
