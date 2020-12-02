using AutoMapper;
using OnlineLibrary.Business.Models.Books;
using OnlineLibrary.Business.Models.Users;
using OnlineLibrary.DAL.Entites;
using System.Linq;

namespace OnlineLibrary.Infrastrcture
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, CreateBookModel>().ReverseMap();
            CreateMap<User, UserModel>()
                .ForMember(um => um.Books, u => u.MapFrom(x => x.BookUsers.Select(bu => bu.Book)));
            CreateMap<UserModel, User>()
                .ForMember(u => u.BookUsers, um => um.MapFrom(x => x.Books.Select(b => new BookUser { BookId = b.Id, UserId = x.Id })));
        }
    }
}
