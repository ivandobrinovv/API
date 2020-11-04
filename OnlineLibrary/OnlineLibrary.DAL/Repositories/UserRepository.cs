using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Repositories.Interfaces;

namespace OnlineLibrary.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OnlineLibraryContext context) : base(context)
        {

        }
    }
}
