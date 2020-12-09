using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Business.Models.Users;
using OnlineLibrary.Business.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public UsersController(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAllUsersWithBooks();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _userService.GetUserWithBooks(id);

            if(result == null)
            {
                return NotFound("Object with the provided id does not exist");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserModel model)
        {
            await _userService.InsertAsync(model);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(EditUserModel model)
        {
            var result = _userService.GetById(model.Id);

            if (result == null)
            {
                return BadRequest("Object with the provided id does not exist");
            }

            await _userService.UpdateAsync(model);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = _userService.GetById(id);

            if (result == null)
            {
                return BadRequest("Object with the provided id does not exist");
            }

            await _userService.RemoveAsync(id);

            return Ok();
        }

        [HttpGet("{userId}/books")]
        public IActionResult GetUserBooks(Guid userId)
        {
            var user = _userService.GetUserWithBooks(userId);

            if(user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user.Books);
        }

        [HttpPost("{userId}/books/{bookId}")]
        public async Task<IActionResult> BorrowBook(Guid userId, Guid bookId)
        {
            var user = _userService.GetUserWithBooks(userId);
            var book = _bookService.GetById(bookId);

            if(user == null)
            {
                return NotFound("User not found");
            }

            if (book == null)
            {
                return NotFound("Book not found");
            }

            if(book.QuantityInStock <= 0)
            {
                return BadRequest("There are not enough books in stock");
            }

            if (user.Books.Any(b => b.Id == bookId))
            {
                return BadRequest("The user has already borrowed that book");
            }

            await _userService.BorrowBook(userId, bookId);

            return Ok();
        }

        [HttpDelete("{userId}/books/{bookId}")]
        public async Task<IActionResult> ReturnBook(Guid userId, Guid bookId)
        {
            var user = _userService.GetUserWithBooks(userId);
            var book = _bookService.GetById(bookId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (book == null)
            {
                return NotFound("Book not found");
            }

            if (!user.Books.Any(b => b.Id == bookId))
            {
                return BadRequest("The user has not borrowed that book yet");
            }

            await _userService.ReturnBook(userId, bookId);

            return Ok();
        }
    }
}
