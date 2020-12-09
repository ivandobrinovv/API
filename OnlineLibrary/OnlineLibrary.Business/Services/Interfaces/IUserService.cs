using OnlineLibrary.Business.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.Business.Services.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter = null);
        UserModel GetById(Guid id);
        Task InsertAsync(CreateUserModel model);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(EditUserModel model);
        Task BorrowBook(Guid userId, Guid bookId);
        Task ReturnBook(Guid userId, Guid bookId);
        UserModel GetUserWithBooks(Guid id);
        List<UserModel> GetAllUsersWithBooks(Expression<Func<UserModel, bool>> filter = null);
        UserAuthModel GetUserByEmail(string email);
    }
}