﻿using AutoMapper;
using OnlineLibrary.Business.Models.Books;
using OnlineLibrary.Business.Services.Interfaces;
using OnlineLibrary.DAL.Entites;
using OnlineLibrary.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineLibrary.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public List<BookModel> GetAll(Expression<Func<BookModel, bool>> filter = null)
        {
            var repoFilter = _mapper.Map<Expression<Func<Book, bool>>>(filter);

            var result = _bookRepository.GetAll(repoFilter);

            return _mapper.Map<List<BookModel>>(result);
        }

        public BookModel GetById(Guid id)
        {
            var result = _bookRepository.GetById(id);

            return _mapper.Map<BookModel>(result);
        }

        public async Task InsertAsync(CreateBookModel model)
        {
            var entity = _mapper.Map<Book>(model);

            await _bookRepository.InsertAndSaveAsync(entity);
        }

        public async Task UpdateAsync(BookModel model)
        {
            var entity = _mapper.Map<Book>(model);

            await _bookRepository.UpdateAndSaveAsync(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _bookRepository.RemoveAndSaveAsync(id);
        }
    }
}
