using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Data.Repositories;

namespace Dish_Discovery.Core.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class, IIdentifiable
    {
        protected BaseService(IRepository<TEntity> repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        protected IRepository<TEntity> Repository { get; }

        public bool Create(TEntity entity)
        {
            if (!this.IsValid(entity)) return false;

            this.Repository.Create(entity);
            return true;
        }

        public bool Update(TEntity entity)
        {
            if (!this.IsValid(entity)) return false;

            this.Repository.Update(entity);
            return true;
        }

        public bool Delete(Guid id)
        {
            var entity = this.Repository.Get(x => x.Id == id);
            if (entity is null) return false;

            this.Repository.Delete(entity);
            return true;
        }

        public IEnumerable<TEntity> GetByIds(IEnumerable<Guid> ids)
        {
            return this.Repository.GetMany(e => ids.Contains(e.Id));
        }

        public TEntity? GetById(Guid id)
        {
            return this.Repository.Get(e => e.Id == id);
        }

        public TEntity? GetByIdComplete(Guid id)
        {
            return this.Repository.GetComplete(e => e.Id == id);
        }

        public TEntity? GetByIdWithNavigations(Guid id, IEnumerable<string> navigations)
        {
            return this.Repository.GetWithNavigations(e => e.Id == id, navigations);
        }

        protected virtual bool IsValid(TEntity entity) => true;
    }
}
