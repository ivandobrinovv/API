using AutoMapper;
using OnlineLibrary.Business.Models.Books;
using OnlineLibrary.Business.Models.Users;
using OnlineLibrary.DAL.Entites;

namespace OnlineLibrary.Infrastrcture
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, CreateBookModel>().ReverseMap();
        }
    }
}
