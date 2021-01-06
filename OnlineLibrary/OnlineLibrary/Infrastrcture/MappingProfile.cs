using AutoMapper;
using OnlineLibrary.Business.Models.Books;
using OnlineLibrary.Business.Models.Users;
using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Enums;
using System.Linq;

namespace OnlineLibrary.Infrastrcture
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginModel>().ReverseMap();
            CreateMap<User, UserAuthModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Book, CreateBookModel>().ReverseMap();

            CreateMap<User, CreateUserModel>()
                .ForMember(um => um.IsAdmin, u => u.MapFrom(x => x.Role == UserRoles.Admin));

            CreateMap<CreateUserModel, User>()
                .ForMember(u => u.Role, um => um.MapFrom(x => x.IsAdmin ? UserRoles.Admin : UserRoles.User));

            CreateMap<User, EditUserModel>()
                .ForMember(um => um.IsAdmin, u => u.MapFrom(x => x.Role == UserRoles.Admin));

            CreateMap<EditUserModel, User>()
                .ForMember(u => u.Role, um => um.MapFrom(x => x.IsAdmin ? UserRoles.Admin : UserRoles.User));

            CreateMap<User, UserModel>()
                .ForMember(um => um.Books, u => u.MapFrom(x => x.BookUsers.Select(bu => bu.Book)))
                .ForMember(um => um.IsAdmin, u => u.MapFrom(x => x.Role == UserRoles.Admin));

            CreateMap<UserModel, User>()
                .ForMember(u => u.BookUsers, um => um.MapFrom(x => x.Books.Select(b => new BookUser { BookId = b.Id, UserId = x.Id })))
                .ForMember(u => u.Role, um => um.MapFrom(x => x.IsAdmin ? UserRoles.Admin : UserRoles.User));
        }
    }
}
