using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IBookRepository _bookRepository;
        public UserRepository(OnlineLibraryContext context, IBookRepository bookRepository) : base(context)
        {
            _bookRepository = bookRepository;
        }

        public User GetUserWithBooks(Guid id)
        {
            var result = DbSet.Include(u => u.BookUsers)
                .ThenInclude(bu => bu.Book)
                .FirstOrDefault(x => x.Id == id);

            return result;
        }

        public async Task BorrowBook(Guid userId, Guid bookId)
        {
            var user = GetById(userId);
            var book = _bookRepository.GetById(bookId);
            book.QuantityInStock -= 1;
            var borrowedBook = new BookUser { BookId = bookId };
            user.BookUsers.Add(borrowedBook);

            await Context.SaveChangesAsync();
        }

        public async Task ReturnBook(Guid userId, Guid bookId)
        {
            var user = GetById(userId);
            var book = _bookRepository.GetById(bookId);
            book.QuantityInStock += 1;
            var borrowedBook = user.BookUsers.FirstOrDefault(bu => bu.BookId == bookId);
            user.BookUsers.Remove(borrowedBook);

            await Context.SaveChangesAsync();
        }
    }
}
