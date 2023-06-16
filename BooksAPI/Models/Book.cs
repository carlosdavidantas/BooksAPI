namespace BooksAPI.Models
{
    public class Book
    {
        public Book(int id, string title, string status, string author)
        {
            Id = id;
            Title = title;
            Status = status;
            Author = author;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Author { get; set; }
    }
}
