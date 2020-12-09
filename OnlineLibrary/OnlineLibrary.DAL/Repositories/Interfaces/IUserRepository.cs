using OnlineLibrary.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task BorrowBook(Guid userId, Guid bookId);
        Task ReturnBook(Guid userId, Guid bookId);
        User GetUserWithBooks(Guid id);
        IEnumerable<User> GetAllUsersWithBooks(Expression<Func<User, bool>> filter = null);
        User GetUserByEmail(string email);
    }
}
