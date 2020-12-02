using OnlineLibrary.DAL.Entites;
using System;
using System.Threading.Tasks;

namespace OnlineLibrary.DAL.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task BorrowBook(Guid userId, Guid bookId);
        Task ReturnBook(Guid userId, Guid bookId);
        User GetUserWithBooks(Guid id);
    }
}
