using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Repositories.Interfaces;

namespace OnlineLibrary.DAL.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(OnlineLibraryContext context) : base(context)
        {

        }
    }
}
