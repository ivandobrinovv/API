namespace OnlineLibrary.Business.Models.Books
{
    public class CreateBookModel : BaseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int QuantityInStock { get; set; }
    }
}
