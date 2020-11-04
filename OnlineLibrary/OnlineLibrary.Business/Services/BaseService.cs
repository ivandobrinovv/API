using AutoMapper;
using OnlineLibrary.Business.Models;
using OnlineLibrary.Business.Services.Interfaces;
using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.Business.Services
{
    public class BaseService<TEntity, TModel> : IBaseService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel 
    {
        protected readonly IBaseRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null)
        {
            var entityFilter = Mapper.Map<Expression<Func<TEntity, bool>>>(filter);
            var result = Repository.GetAll(entityFilter);

            return Mapper.Map<List<TModel>>(result);
        }

        public TModel GetById(Guid id)
        {
            var result = Repository.GetById(id);

            return Mapper.Map<TModel>(result);
        }

        public async Task InsertAsync(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);

            await Repository.InsertAndSaveAsync(entity);
        }

        public async Task UpdateAsync(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);

            await Repository.UpdateAndSaveAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            await Repository.RemoveAndSaveAsync(id);
        }
    }
}
