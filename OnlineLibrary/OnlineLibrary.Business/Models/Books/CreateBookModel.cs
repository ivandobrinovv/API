using DataAnnotationsExtensions;

namespace OnlineLibrary.Business.Models.Books
{
    public class CreateBookModel : BaseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }

        [Min(0)]
        public int QuantityInStock { get; set; }
    }
}
