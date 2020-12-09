using AutoMapper;
using OnlineLibrary.Business.Models.Users;
using OnlineLibrary.Business.Services.Interfaces;
using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserModel> GetAll(Expression<Func<UserModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<User, bool>>>(filter);

            var result = _userRepository.GetAll(repoFilter);

            return _mapper.Map<List<UserModel>>(result);
        }

        public UserModel GetById(Guid id)
        {
            var result = _userRepository.GetById(id);

            return _mapper.Map<UserModel>(result);
        }

        public async Task InsertAsync(CreateUserModel model)
        {
            var entity = _mapper.Map<User>(model);

            entity.Password = AuthService.HashPassword(entity.Password);

            await _userRepository.InsertAndSaveAsync(entity);
        }

        public async Task UpdateAsync(EditUserModel model)
        {
            var entity = _mapper.Map<User>(model);

            entity.Password = AuthService.HashPassword(entity.Password);

            await _userRepository.UpdateAndSaveAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _userRepository.RemoveAndSaveAsync(id);
        }

        public List<UserModel> GetAllUsersWithBooks(Expression<Func<UserModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<User, bool>>>(filter);

            var result = _userRepository.GetAllUsersWithBooks(repoFilter);

            return _mapper.Map<List<UserModel>>(result);
        }

        public UserModel GetUserWithBooks(Guid id)
        {
            var dbUser = _userRepository.GetUserWithBooks(id);

            return _mapper.Map<UserModel>(dbUser);
        }

        public async Task BorrowBook(Guid userId, Guid bookId)
        {
            await _userRepository.BorrowBook(userId, bookId);
        }

        public async Task ReturnBook(Guid userId, Guid bookId)
        {
            await _userRepository.ReturnBook(userId, bookId);
        }

        public UserAuthModel GetUserByEmail(string email)
        {
            var result = _userRepository.GetUserByEmail(email);

            return _mapper.Map<UserAuthModel>(result);
        }
    }
}
