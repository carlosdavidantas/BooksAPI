namespace BooksAPI.Models
{
    public class Book
    {
        public Book(int id, string title, string status)
        {
            Id = id;
            Title = title;
            Status = status;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
    }
}
