using OnlineLibrary.Business.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.Business.Services.Interfaces
{
    public interface IBookService
    {
        List<BookModel> GetAll(Expression<Func<BookModel, bool>> filter = null);
        BookModel GetById(Guid id);
        Task InsertAsync(CreateBookModel model);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(BookModel model);
    }
}