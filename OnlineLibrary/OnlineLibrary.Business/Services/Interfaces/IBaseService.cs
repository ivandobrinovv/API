using OnlineLibrary.Business.Models;
using OnlineLibrary.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.Business.Services.Interfaces
{
    public interface IBaseService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseModel
    {
        IEnumerable<TModel> GetAll(Expression<Func<TModel, bool>> filter = null);
        TModel GetById(Guid id);
        Task InsertAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task RemoveAsync(Guid id);
    }
}
